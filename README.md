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
```