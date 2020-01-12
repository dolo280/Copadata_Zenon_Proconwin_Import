# Copadata_Zenon_Proconwin_Import
Copadata Zenon Addin - Wizard for simple importing of Tags vom GTI Proconwin

## Description
This AddIn was programmed for the Softwaretool - Zenon from the Company Copadata. The AddIn itself is desinged to Import the Variabl-Taglist from the Software ProconWin, also it can handle a autonomous mapping of the AlertList to the PLCTag itself.
The current version is limited to import ProconWin PLCTags that was connected to Siemens S7 Controller. To implement different driver could also be possible. 

# Tutorial of transferring PLC-Tags from ProconWin to Zenon 

## Export in ProconWin

### Export PLC-Tags
The export in ProconWin itself is very easy, no additional configuration has to be done. In ProconWin select "Prozessvariablen" -> "Prozessvariablen bearbeiten", in the new Window select "Datei" -> "Export". A MessageBox apears showing in wich directions the file was exported to.

![Alt text](README_res/Export.png?raw=true "Title")

### Export Alertlist
In Main Programmwindow select "Alarme" -> "Alarmimport/-export". Leafe settings default and Press "Export starten"

![Alt text](README_res/Alarmmeldungen.png?raw=true "Title")

## Use the AddIn to Import to Zenon
The AddIn can be used in two ways: compile itself or use the existing binary publised here in Github.

### Compile the Programcode

There are some Library that a nessessary for compile the code. The Library can be importet via the NuGet-Manager. Use the Package Manager to restore: 
```
Install-Package CsvHelper
Install-Package Microsoft.CSharp
Install-Package System.ValueTuple
```
(If you use a modern Tool like Visual Studio 2019 you may get the suggestion to restore missing packages, you can also to it this way)

Than you can create to AddIn by build the code

![Alt text](README_res/Create.png?raw=true "Title")

## Add the Addin to Copadata Zenon

Next step is to add the AddIn to Zenon, this can easie be done. Open the AddIn Manager:

![Alt text](README_res/manage_addin.png?raw=true "Title")

And Import a new AddIn:

![Alt text](README_res/adde_addin.png?raw=true "Title")

Select the "addin" file you build in the path "...\AddInEditor_ProconwinImport\bin\Debug"

![Alt text](README_res/sel_addin.png?raw=true "Title")

The AddIn is now listed.

![Alt text](README_res/display_addin.png?raw=true "Title")

## Use the Addin

Open the AddIn now via the Dialog

![Alt text](README_res/open_addin.png?raw=true "Title")

AddIn can be found in the Tree at "Import/Export" as "ProconWin"

![Alt text](README_res/open2_addin.png?raw=true "Title")

Now map the Files you created in ProconWin before and Push the Start Button

![Alt text](README_res/open3_addin.png?raw=true "Title")

Now the AddIn automatical read the file and add the PLCTag Step by Step - we spend about three minutes to Import about 7000 Tags.