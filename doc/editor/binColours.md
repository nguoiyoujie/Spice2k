
[Return to Editor index](doc/editor.md)

### House Palette Editor

![Image](doc/img/editor/binColours.png)

The Dune 2000 color palette is a palette carrying 15-bit color information. Each set of 16 colors represent a house color, and is rendered with sprites of units and buildings alike.

The original game may support only up to 8 house colours, but this could potentially be changed in the future.

#### Editor Controls

Each editor offers the following basic controls, in order from left to right:

 - File: Contains (Open, Save, Save As, Reload, Unload)

 - Open: Opens a file, and enables the editor.

 - Save: Saves the file.

 - Reload: Reverts the file to its last saved state.

 - Unload: Closes the current file and disables the editor. Prompts if you have unsaved changes.

 - Search: Not available in this editor.

![Image](doc/img/editor/editorControls.png)

#### Editor State and Unsaved Changes

The color of the tab and title bar indicates if you have unsaved changes (which you will be warned about if the program attempts to close it without saving)
The blue color indicates an opened file without unsaved changes, and the green color indicates the presence of unsaved changes.

![Image](doc/img/editor/editorStates.png)

#### Editing

To edit, simply click on an square of the palette grid. A color dialog will pop-up, requesting for a new color to replace your selection.
For files containing more than 16 houses, navigate between different palette sections using the left and right arrow buttons above the palette.

#### Copy As Text

For more convenient copying of color information, you may extract part of the palette in text. The process is the same as that of the Palette editor.

![Image](doc/img/editor/binPalette_copyAsText.png)

 - First, select the desired colors to copy by specifying the start and end index. The palette will reveal green boxes around the color to indicate selection.

 - Press the rightward arrow to fill the text box with numeric text. The data is given in {RR GG BB} format in hexadecimal, with FF as the maximum value

 - You may copy or edit these text values as you need. If required, you may change the selection.

 - Press the leftward arrow to transfer your edited information back to the palette.

 - If successful, the palette will have its colors updated.


