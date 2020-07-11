
[Return to Editor index](doc/editor.md)

### UI Menus Table Editor

![Image](img/uibMenus.png)

Like the UI Text table, the UI Menus table is a simple dictionary of key-value pairs, with each key associated with a text entry. 
In addition to a text entry referencing a UIL file to load, two additional values indicate how the menu transitions in and out of visibility (fade actions).

#### Editor Controls

Each editor offers the following basic controls, in order from left to right:

 - File: Contains (Open, Save, Save As, Reload, Unload)

 - Open: Opens a file, and enables the editor.

 - Save: Saves the file.

 - Reload: Reverts the file to its last saved state.

 - Unload: Closes the current file and disables the editor. Prompts if you have unsaved changes.

 - Search: Some editors additionally provide a search option to help seek a particular piece of information.

![Image](img/editorControls.png)

#### Editor State and Unsaved Changes

The color of the tab and title bar indicates if you have unsaved changes (which you will be warned about if the program attempts to close it without saving)
The blue color indicates an opened file without unsaved changes, and the green color indicates the presence of unsaved changes.

![Image](img/editorStates.png)

#### Editing

To edit, simply double click on the relevant entry to edit. The menu transitions take a drop down list.

#### Search Bar

A search function is available by clicking on the magnifying glass icon.
You may specify the column and value to search for.

![Image](img/uib_searchBar.png)




