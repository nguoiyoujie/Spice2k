
[Return to Editor index](../editor.md)

## Main Palette Binary

Key  | Value
--- | ---
File Location | .\data\bin\palette.bin
File Size | Exactly 768 bytes
Description  | Defines 256 colors for indexed 8-bit images


---
The main palette contains 256 colors for rendering 8-bit images. Each color is stored in a 18-bit color XXRRRRRRXXGGGGGGXXBBBBBB format

### File Data

Offset(h) | Size(h) | Size(d) | Data Type | Description
--- | --- | --- | --- | --- 
0x0000 | 0x3 x 256 | 3 x 256 | byte[3][256] | Each byte[3] is an indexed color, stored in 24-bits in a 18-bit format (XXRRRRRRXXGGGGGGXXBBBBBB)


