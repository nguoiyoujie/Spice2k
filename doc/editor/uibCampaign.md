
[Return to Editor index](doc/editor.md)

### UI Single Player Campaign Editor

![Image](img/uibCampaign.png)

Unlike other UI files, the campaign UI file is uniquely formatted. The campaign UI file determines how the campaign world map is generated. It also controls some aspects of the single-player game such as the initial theme and score.

#### Editor Controls

Each editor offers the following basic controls, in order from left to right:

 - File: Contains (Open, Save, Save As, Reload, Unload)

 - Open: Opens a file, and enables the editor.

 - Save: Saves the file.

 - Reload: Reverts the file to its last saved state.

 - Unload: Closes the current file and disables the editor. Prompts if you have unsaved changes.

 - Search: Not available in this editor.

![Image](img/editorControls.png)

#### Editor State and Unsaved Changes

The color of the tab and title bar indicates if you have unsaved changes (which you will be warned about if the program attempts to close it without saving)
The blue color indicates an opened file without unsaved changes, and the green color indicates the presence of unsaved changes.

![Image](img/editorStates.png)

#### Editing

To edit, simply select the House and Scenario you wish to edit, and double click on the relevant entry to edit.
Changes are preserved between switching houses and scenarios.

#### Preview

To preview your changes, select one of the buttons in the preview screen to view the map state at that point.
![Image](img/uibCampaign_preview.png)



