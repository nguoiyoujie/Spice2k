
[Return to Editor index](doc/editor.md)

### Palette Editor

![Image](doc/img/editor/binPalette.png)

The Dune 2000 main palette is a palette carrying 256 18-bit colors, used for the rendering of many images.

This editor can also handle palettes that are exported by the [Image Resources editor](doc/editor/r8r16.md), as they are exported in the same format.

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

#### Copy As Text

For more convenient copying of color information, you may extract part of the palette in text.

![Image](doc/img/editor/binPalette_copyAsText.png)

 - First, select the desired colors to copy by specifying the start and end index. The palette will reveal green boxes around the color to indicate selection.

 - Press the rightward arrow to fill the text box with numeric text. The data is given in {RR GG BB} format in hexadecimal, with FF as the maximum value

 - You may copy or edit these text values as you need. If required, you may change the selection.

 - Press the leftward arrow to transfer your edited information back to the palette.

 - If successful, the palette will have its colors updated.


