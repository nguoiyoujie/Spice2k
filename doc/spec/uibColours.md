
[Return to Editor index](../editor.md)

## Colours UI Binary

Key  | Value
--- | ---
File Location(s)  | .\data\UI_DATA\colours.uib
File Size | Variable
Description  | Maps a color name to a RGB color


---
The Colours UI binary file constains a variable number of color entries in RGB format. Alpha appears not to be supported in this format.
### File Data

Offset(h) | Size(h) | Size(d) | Data Type | Description
--- | --- | --- | --- | --- 
0x0000 | 0x4 | 4 | int | Number of entries
0x0004 | variable | variable | ColourData | The list of entries

### Section Data
**ColourData**

Offset(h) | Data Type | Name | Description
--- | --- | --- | --- 
0x0000 | ushort | Key Length | The length of the key, including the terminating null byte
0x0002 | variable, null-terminated string | Key | The key string
variable | byte | The blue value of the color
variable | byte | The green value of the color
variable | byte | The red value of the color
variable | byte | Nothing, always '00'






