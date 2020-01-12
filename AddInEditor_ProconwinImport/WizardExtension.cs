using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration.Attributes;
using Scada.AddIn.Contracts;
using Scada.AddIn.Contracts.Variable;

namespace AddInEditorExample
{
  [AddInExtension("ProconWin Import", "Importiert die Variablen aus ProconWin", "Export/Import")]
    public class WizardExtension : IEditorWizardExtension
  {
        public void Run(IEditorApplication context, IBehavior behavior)
        {
              try
              {
                    ImportVars(context, behavior);
              }
              catch (Exception ex)
              {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
              }
        }

        private void ImportVars(IEditorApplication context, IBehavior behavior)
        {
            IVariableCollection variableCollection = context.Workspace.ActiveProject.VariableCollection;


            frmDescription frmSelection = new frmDescription();
            if (frmSelection.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                variableCollection = context.Workspace.ActiveProject.VariableCollection;
                
                //Displays all variable names in the zenon editor
                foreach (IVariable variable in variableCollection)
                {
                    context.DebugPrint("Variable name: " + variable.Name + " / Channel: " + variable.DataBlock, DebugPrintStyle.Standard);
                }

                IDataType myDatatype = context.Workspace.ActiveProject.DataTypeCollection["REAL"];

                // Treiber mappen
                IDriverCollection driverCollection = context.Workspace.ActiveProject.DriverCollection;

                if (driverCollection == null || driverCollection.Count < 1)
                    return;

                IDriver sel_driver = null;
                //Displays all available drivers in zenon
                foreach (IDriver driver in driverCollection)
                {
                    if (driver.Name == "S7TCP32")
                    {
                        sel_driver = driver;
                        context.DebugPrint("Driver ausgewäht = " + sel_driver.Name, DebugPrintStyle.Standard);
                    }
                }

                #region Numerisch
                //Einlesen von CSV für numerische Variablen
                List<GTINumVal> GTINumValues = new List<GTINumVal>();
                try
                {
                    context.DebugPrint("Einlesen von: " + frmSelection.file_numeric, DebugPrintStyle.Standard);
                    GTINumValues = ReadCSV(frmSelection.file_numeric);
                }
                catch (Exception creationException)
                {
                    context.DebugPrint("Reading CSV error: " + creationException.Message, DebugPrintStyle.Error);
                    return;
                }
                if (GTINumValues.Count < 1)
                {
                    context.DebugPrint("Reading CSV error", DebugPrintStyle.Error);
                    return;
                }

                foreach (GTINumVal tempVal in GTINumValues)
                {
                    string myVariableName = tempVal.Name;

                    // Jetzt werden die Variablen erstellt
                    if (variableCollection[myVariableName] == null)
                    {
                        try
                        {
                            switch (tempVal.GtiDatentyp)
                            {
                                case "LW":
                                    myDatatype = context.Workspace.ActiveProject.DataTypeCollection["DINT"];
                                    break;
                                case "FLOAT":
                                    myDatatype = context.Workspace.ActiveProject.DataTypeCollection["REAL"];
                                    break;
                                case "WORT":
                                    myDatatype = context.Workspace.ActiveProject.DataTypeCollection["INT"];
                                    break;
                                case "BCD-DL":
                                    myDatatype = context.Workspace.ActiveProject.DataTypeCollection["INT"];
                                    break;
                                case "S7-BYTE":
                                    myDatatype = context.Workspace.ActiveProject.DataTypeCollection["USINT"];
                                    break;
                                default:
                                    myDatatype = context.Workspace.ActiveProject.DataTypeCollection["REAL"];
                                    break;
                            }

                            variableCollection.Create(myVariableName, sel_driver, ChannelType.DriverVariable, myDatatype);

                            if (variableCollection[myVariableName] == null)
                            {
                                context.DebugPrint("Variable could not be created.", DebugPrintStyle.Error);
                                return;
                            }

                            variableCollection[myVariableName].DataBlock = tempVal.DataBlock;
                            variableCollection[myVariableName].Offset = tempVal.Offset;
                            //variableCollection[myVariableName].Unit = "%";
                            variableCollection[myVariableName].SignalMaximumRange = tempVal.MaxWert;
                            variableCollection[myVariableName].SignalMinimumRange = tempVal.MinWert;
                            variableCollection[myVariableName].MeasuringMaximumRange = tempVal.MaxNorm;
                            variableCollection[myVariableName].MeasuringMinimumRange = tempVal.MinNorm;
                            variableCollection[myVariableName].Digits = tempVal.Komma;
                            variableCollection[myVariableName].NetAddress = tempVal.Netzadresse;
                        }
                        catch (Exception creationException)
                        {

                            context.DebugPrint("Variable creation error: " + creationException.Message, DebugPrintStyle.Error);
                        }
                        context.DebugPrint("Variable " + variableCollection[myVariableName].Name + " has been created.", DebugPrintStyle.Standard);
                    }
                    else
                    {
                        context.DebugPrint("The variable " + variableCollection[myVariableName].Name + " exists already!", DebugPrintStyle.Warning);
                    }
                }
                #endregion

                #region Logisch
                //Einlesen von CSV für numerische Variablen
                List<GTILogVal> GTILogValues = new List<GTILogVal>();
                try
                {
                    context.DebugPrint("Einlesen von: " + frmSelection.file_logic, DebugPrintStyle.Standard);
                    GTILogValues = ReadLogCSV(frmSelection.file_logic);
                }
                catch (Exception creationException)
                {
                    context.DebugPrint("Reading CSV error: " + creationException.Message, DebugPrintStyle.Error);
                    return;
                }
                if (GTINumValues.Count < 1)
                {
                    context.DebugPrint("Reading CSV error", DebugPrintStyle.Error);
                    return;
                }

                foreach (GTILogVal tempVal in GTILogValues)
                {
                    string myVariableName = tempVal.Name;

                    // Jetzt werden die Variablen erstellt
                    if (variableCollection[myVariableName] == null)
                    {
                        try
                        {
                            myDatatype = context.Workspace.ActiveProject.DataTypeCollection["BOOL"];
                            variableCollection.Create(myVariableName, sel_driver, ChannelType.DriverVariable, myDatatype);

                            if (variableCollection[myVariableName] == null)
                            {
                                context.DebugPrint("Variable could not be created.", DebugPrintStyle.Error);
                                return;
                            }

                            variableCollection[myVariableName].DataBlock = tempVal.DataBlock;
                            variableCollection[myVariableName].Offset = tempVal.Offset;
                            variableCollection[myVariableName].BitNumber = tempVal.Bit;
                            variableCollection[myVariableName].NetAddress = tempVal.Netzadresse;
                        }
                        catch (Exception creationException)
                        {

                            context.DebugPrint("Variable creation error: " + creationException.Message, DebugPrintStyle.Error);
                        }
                        context.DebugPrint("Variable " + variableCollection[myVariableName].Name + " has been created.", DebugPrintStyle.Standard);
                    }
                    else
                    {
                        context.DebugPrint("The variable " + variableCollection[myVariableName].Name + " exists already!", DebugPrintStyle.Warning);
                    }
                }
                #endregion

                #region Limits

                //Einlesen von CSV für numerische Variablen
                List<GTIAlert> GTIAlerts = new List<GTIAlert>();
                GTIAlerts = ReadAlertCSV(frmSelection.file_alert);

                context.DebugPrint("Number: " + GTIAlerts.Count(), DebugPrintStyle.Standard);

                foreach (GTIAlert alert in GTIAlerts)
                {
                    context.DebugPrint("Alert: " + alert.Number + " / Name: " + alert.AlarmText + " / Variable: " + alert.Variable, DebugPrintStyle.Standard);
                }

                if (variableCollection == null || variableCollection.Count < 1)
                    return;

                //Alle Variablen als "False" setzten
                foreach (IVariable variable in variableCollection)
                {
                    for (int i = 0; i < variable.EditorLimitValueCount; i++)
                    {
                        variable.DeleteEditorLimitValue(i);
                    }

                    if (GTIAlerts.Where(x => x.Variable == variable.Name).Count() > 0)
                    {
                        variable.CreateEditorLimitValue();
                        IEditorLimitValue limit = variable.GetEditorLimitValue(0);
                        limit.IsActive = true;
                        limit.Text = GTIAlerts.Where(x => x.Variable == variable.Name).FirstOrDefault().AlarmText;
                    }
                }

                #endregion
            }
        }

        private List<GTINumVal> ReadCSV(string filename)
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("de-DE");

                List<GTINumVal> returnlist = new List<GTINumVal>();

                if (File.Exists(filename))
                {
                    using (TextReader reader = File.OpenText(filename))
                    {
                        CsvReader csv = new CsvReader(reader);
                        csv.Configuration.Delimiter = ";";
                        csv.Configuration.CultureInfo = CultureInfo.InvariantCulture;
                        csv.Configuration.HasHeaderRecord = false;
                        csv.Configuration.MissingFieldFound = null;
                        while (csv.Read())
                        {
                            try
                            {
                                GTINumVal Record = csv.GetRecord<GTINumVal>();

                                if (Record.GtiDriverName == "S5-S7-COMBI RFC1006")
                                {
                                    returnlist.Add(Record);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                            }
                        }
                    }
                }
                else
                {
                    throw new FileNotFoundException();
                    return returnlist;
                }
                return returnlist;
            }

        private List<GTILogVal> ReadLogCSV(string filename)
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("de-DE");

                List<GTILogVal> returnlist = new List<GTILogVal>();

                if (File.Exists(filename))
                {
                    using (TextReader reader = File.OpenText(filename))
                    {
                        CsvReader csv = new CsvReader(reader);
                        csv.Configuration.Delimiter = ";";
                        csv.Configuration.CultureInfo = CultureInfo.InvariantCulture;
                        csv.Configuration.HasHeaderRecord = false;
                        csv.Configuration.MissingFieldFound = null;
                        while (csv.Read())
                        {
                            try
                            {
                                GTILogVal Record = csv.GetRecord<GTILogVal>();

                                if (Record.GtiDriverName == "S5-S7-COMBI RFC1006")
                                {
                                    returnlist.Add(Record);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                            }
                        }
                    }
                }
                else
                {
                    throw new FileNotFoundException();
                    return returnlist;
                }
                return returnlist;
        }

        private List<GTIAlert> ReadAlertCSV(string filename)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("de-DE");

            List<GTIAlert> returnlist = new List<GTIAlert>();

            if (File.Exists(filename))
            {
                using (TextReader reader = File.OpenText(filename))
                {
                    CsvReader csv = new CsvReader(reader);
                    csv.Configuration.Delimiter = ";";
                    csv.Configuration.CultureInfo = CultureInfo.InvariantCulture;
                    csv.Configuration.HasHeaderRecord = false;
                    csv.Configuration.BadDataFound = x =>
                    {
                        Console.WriteLine($"Bad data: <{x.RawRecord}>");
                    };
                    csv.Configuration.MissingFieldFound = null;
                    while (csv.Read())
                    {
                        try
                        {
                            GTIAlert Record = csv.GetRecord<GTIAlert>();
                            returnlist.Add(Record);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                }
            }
            else
            {
                return returnlist;
            }
            return returnlist;
        }
    }

    // Numerische GTI Variable nach "VAREXPN.CSV"
    public class GTINumVal
    {
        [Index(0)]
        public string Name { get; set; }

        [Index(11)]
        public short Komma { get; set; }

        [Index(12)]
        public double MinWert { get; set; }

        [Index(13)]
        public double MaxWert { get; set; }

        [Index(14)]
        public double MinNorm { get; set; }

        [Index(15)]
        public double MaxNorm { get; set; }

        [Index(19)]
        public string GtiDriverName { get; set; }

        [Index(21)]
        public int Netzadresse { get; set; }

        [Index(23)]
        public int DataBlock { get; set; }

        [Index(24)]
        public int Offset { get; set; }

        [Index(25)]
        public string GtiDatentyp { get; set; }
    }

    // Logische GTI Variable nach "VAREXPL.CSV"
    public class GTILogVal
    {
        [Index(0)]
        public string Name { get; set; }

        [Index(14)]
        public string GtiDriverName { get; set; }

        [Index(16)]
        public int Netzadresse { get; set; }

        [Index(18)]
        public int DataBlock { get; set; }

        [Index(19)]
        public int Offset { get; set; }

        [Index(20)]
        public int Bit { get; set; }
    }

    // Alarm nach GTI nach "ALERTS.CSV"
    public class GTIAlert
    {
        [Index(0)]
        public int Number { get; set; }

        [Index(1)]
        public string AlarmText { get; set; }

        [Index(19)]
        public string Variable { get; set; }
    }
}