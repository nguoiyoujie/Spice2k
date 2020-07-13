
[Return to Editor index](../editor.md)

## House Palette Binary

(also known as Colours.bin)

Key  | Value
--- | ---
File Location | .\data\bin\colours.bin
File Size | Exactly 256 bytes
Description  | Defines 16 colors for each house index


---
The house palette contains 16 color for each of the 8 houses. Each color is stored in a 15-bit High Color XRRRRRGGGGGBBBBB format

### File Data

Offset(h) | Size(h) | Size(d) | Data Type | Description
--- | --- | --- | --- | --- 
0x0000 | 0x2 x 16 x 8 | 2 x 16 x 8 | ushort[16][8] | Indexed color, stored in 16-bits (XRRRRRGGGGGBBBBB)


### Other research

The game allocates 256-bytes of space at address 0x00786c48 for storing color information. As bytes after the allocated space are used for other data, garbage colors are seen when a house allocation index of more than 7 is attempted.

It is possible, by moving the location of this address to one with larger memory space, and modification on the function parameter to read more than 0x100 bytes of colours.bin, to support more than 8 colors. 

The minimum space allocation required for a full set of 256 colors (00 - FF) is 2 x 16 x 256 = 8192 bytes.

A minimal demonstration for 16 house colors can be performed with the following edit with a hex editor: 

 - Find and change all hex sequences `48 6c 78 00` to `0b 05 8d 00`. This modifies references to address 0x00786c48 to 0x008d050b (an example).

 - At offset 0x0061160, change `00 01 00 00` to `00 02 00 00`. This makes the game read 0x200 bytes from colours.bin instead of 0x100 bytes. This means 16 house colors.

 - Find and change all hex sequences `58 6c 78 00` to `1b 05 8d 00`. This modifies references to the 8th color (zero-based index). This applies the color for the minimap.

 - Find and change all hex sequences `5a 6c 78 00` to `1d 05 8d 00`. This modifies references to the 9th color (zero-based index). This applies the color for the minimap.
