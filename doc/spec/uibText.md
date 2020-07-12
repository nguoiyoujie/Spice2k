
[Return to Editor index](../editor.md)

## Text UI Binary

Key  | Value
--- | ---
File Location | .\data\UI_DATA\text.uib
Alt File Location | .\data\UI_DATA\text{0}.uib
Alt File Location | .\data\UI_DATA\samples.uib
File Size | Variable
Description  | Maps a key to a text entry for the game's reference


---
The Text UI binary file constains a variable number of text entries of arbitary length. 

### File Data

Offset(h) | Size(h) | Size(d) | Data Type | Description
--- | --- | --- | --- | --- 
0x0000 | 0x4 | 4 | int | Number of entries
0x0004 | variable | 260 | TextData | The list of entries

### Section Data
**TextData**

Offset(h) | Data Type | Name | Description
--- | --- | --- | --- 
0x0000 | ushort | Key Length | The length of the key, including the terminating null byte
0x0002 | variable, null-terminated string | Key | The key string
variable | ushort | Value Length  | The length of the text, including the terminating null byte 
variable | variable, null-terminated string | Value | The text value


### Other research

In the case of briefing text, the use of special characters as new-line is mediated by hardcoded logic in the game. It is not yet known know actual new-line characters are treated in the game.



