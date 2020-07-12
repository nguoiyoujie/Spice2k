
[Return to Editor index](../editor.md)

## Menus UI Binary

Key  | Value
--- | ---
File Location(s)  | .\data\UI_DATA\menus.uib
File Size | Variable
Description  | Maps a key to a menu uil name for the game's reference, as well as parameters


---
The Menus UI binary file constains a variable number of text entries of arbitary length. 

### File Data

Offset(h) | Size(h) | Size(d) | Data Type | Description
--- | --- | --- | --- | --- 
0x0000 | 0x4 | 4 | int | Number of entries
0x0004 | variable | variable | MenuData | The list of entries

### Section Data
**MenuData**

Offset(h) | Data Type | Name | Description
--- | --- | --- | --- 
0x0000 | ushort | Key Length | The length of the key, including the terminating null byte
0x0002 | variable, null-terminated string | Key | The key string
variable | ushort | Menu String Length  | The length of the UIL menu name, including the terminating null byte 
variable | variable, null-terminated string | Value | The UIL menu name
variable | int | Fade In | The fade in behaviour
variable | int | Fade Out | The fade out behaviour


### Other research

As of July 12, the fading mechanism works only at orignal resolution.


