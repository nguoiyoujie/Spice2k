##Campaign UI Binary

Key  | Value
--- | ---
File Location  | .\data\UI_DATA\campaign.uib
File Size | Exactly 7800 bytes
Description  | Provides the game with information on setting up each scenario in the single-player campaign, including the global map, the initial music theme, and some elements of the score screen.

---
The Campaign UI binary file constains 30 blocks of scenario data, for 3 houses with 10 scenarios each. 

The first scenario for each house is a non-playable scenario that is used to generate the initial data for the global map of the first mission.

#### File Data

Offset(h) | Size(h) | Size(d) | Data Type | Description
--- | --- | --- | --- 
0x0000 | 0x104 | 260 | CampaignScenarioData | Atreides Initialization
0x0104 | 0x104 | 260 | CampaignScenarioData | Atreides Mission 1
0x0208 | 0x104 | 260 | CampaignScenarioData | Atreides Mission 2
0x030c | 0x104 | 260 | CampaignScenarioData | Atreides Mission 3
0x0410 | 0x104 | 260 | CampaignScenarioData | Atreides Mission 4
0x0514 | 0x104 | 260 | CampaignScenarioData | Atreides Mission 5
0x0618 | 0x104 | 260 | CampaignScenarioData | Atreides Mission 6
0x071c | 0x104 | 260 | CampaignScenarioData | Atreides Mission 7
0x0820 | 0x104 | 260 | CampaignScenarioData | Atreides Mission 8
0x0924 | 0x104 | 260 | CampaignScenarioData | Atreides Mission 9
0x0a28 | 0x104 | 260 | CampaignScenarioData | Harkonnen Initialization
0x0b2c | 0x104 | 260 | CampaignScenarioData | Harkonnen Mission 1
0x0c30 | 0x104 | 260 | CampaignScenarioData | Harkonnen Mission 2
0x0d34 | 0x104 | 260 | CampaignScenarioData | Harkonnen Mission 3
0x0e38 | 0x104 | 260 | CampaignScenarioData | Harkonnen Mission 4
0x0f3c | 0x104 | 260 | CampaignScenarioData | Harkonnen Mission 5
0x1040 | 0x104 | 260 | CampaignScenarioData | Harkonnen Mission 6
0x1144 | 0x104 | 260 | CampaignScenarioData | Harkonnen Mission 7
0x1248 | 0x104 | 260 | CampaignScenarioData | Harkonnen Mission 8
0x134c | 0x104 | 260 | CampaignScenarioData | Harkonnen Mission 9
0x1450 | 0x104 | 260 | CampaignScenarioData | Ordos Initialization
0x1554 | 0x104 | 260 | CampaignScenarioData | Ordos Mission 1
0x1658 | 0x104 | 260 | CampaignScenarioData | Ordos Mission 2
0x175c | 0x104 | 260 | CampaignScenarioData | Ordos Mission 3
0x1860 | 0x104 | 260 | CampaignScenarioData | Ordos Mission 4
0x1964 | 0x104 | 260 | CampaignScenarioData | Ordos Mission 5
0x1a68 | 0x104 | 260 | CampaignScenarioData | Ordos Mission 6
0x1b6c | 0x104 | 260 | CampaignScenarioData | Ordos Mission 7
0x1c70 | 0x104 | 260 | CampaignScenarioData | Ordos Mission 8
0x1d74 | 0x104 | 260 | CampaignScenarioData | Ordos Mission 9

#### Section Data
**CampaignScenarioData**

Offset(h) | Data Type | Name | Description
--- | --- | --- | --- 
0x0000 | byte | Region ID 1 | The first region choice. It makes the corresponding global map region selectable. Awarded to the player house when the mission is won. Setting this to 0 disables the choice.
0x0001 | byte | Region ID 2 | The second region choice. It makes the corresponding global map region selectable. Awarded to the player house when the mission is won. Setting this to 0 disables the choice.
0x0002 | 4 bytes + 1 null byte | Mission ID 1 | The mission file to load when the first region choice is selected. 
0x0007 | 4 bytes + 1 null byte | Mission ID 2 | The mission file to load when the second region choice is selected. 
0x000c | int | Direction 1 (unused) | A 8-point direction (0 = North, 1 = North East, ... 7 = North West). Its use is presently unknown.
0x0010 | int | Direction 1 (unused) | A 8-point direction (0 = North, 1 = North East, ... 7 = North West). Its use is presently unknown.
0x0014 | int | Region 1 Icon Location X  | The X location of the animated icon for region 1. This does not impact the clickable region, which is strictly tied to the region ID.
0x0018 | int | Region 1 Icon Location Y  | The Y location of the animated icon for region 1.
0x001c | int | Region 2 Icon Location X  | The X location of the animated icon for region 2.
0x0020 | int | Region 2 Icon Location Y  | The Y location of the animated icon for region 2.
0x0024 | 3 bytes | Regions to Atreides | When the mission is won, ownership over these regions will be given to House Atreides. Each byte represents a region ID. Limited to 3 regions. A value of zero gives no region, which can be used to provide fewer regions to a House.
0x0027 | 3 bytes | Regions to Harkonnen | When the mission is won, ownership over these regions will be given to House Harkonnen.
0x002a | 3 bytes | Regions to Ordos | When the mission is won, ownership over these regions will be given to House Harkonnen.
0x002d | 3 bytes | Unknown | Its use is presently unknown.
0x0030 | float | Score Multiplier | The multiplier to the total score shared between you and the enemy house in the score screen, when the mission is won. The base score (multiplier 1) is 200.
0x0034 | int | Region Animation Order 1 | In the global map, region ownership transfers are animated to provide a sense of progress. This determines the first House to have its regions animated.
0x0038 | int | Region Animation Order 2 | This determines the second House to have its regions animated.
0x003c | int | Region Animation Order 3 | This determines the third House to have its regions animated.
0x0040 | 60 bytes | SFX 1 | In the global map, a voice updates the player on the campaign progress as regions are animated in. This determines the voice clip (referenced in samples.uib) to use when the first House updates its regions.
0x007c | 60 bytes | SFX 2 | This determines the voice clip (referenced in samples.uib) to use when the second House updates its regions.
0x00b8 | 60 bytes | SFX 3 | This determines the voice clip (referenced in samples.uib) to use when the third House updates its regions.
0x00f4 | 8 bytes | Theme | This determines the starting theme of the mission.
0x00fc | 4 bytes | Unknown | Its use is presently unknown.
0x0100 | int | Enemy House | The enemy house for this scenario. This determines the color of the score bars in the score menu after completing the mission.
0x00fc | ------ | End | End of section



####Other research

Changing the campaign.uib and various image data may allow you to customize your global map. However, you cannot, by those alone, change some features.

**Number of regions**
The game loads exactly 27 regions, referred to by ID 1 - 27.

**Region Polygon**
The polygon data that determines the clickable region (the hotspots that change your cursor into an attack cursor and transfers you to a mission briefing when you click on it). These data are hardcoded in the Dune2000 executable at memory address **0x04BE3FC** (or byte *0x00bd7fc* in a hex editor). The layout of this structure are as follows:

**27 regions x 72 bytes each**

Offset(h) | Data Type | Name | Description
--- | --- | --- | --- 
0x00 | uint | Count | The number of points to draw the region
0x04 | POINT[] | Points | The points that make up the region. Each POINT is a {int x, int y} struct. This array may be of variable length as long as they can fit in 72 bytes. This limits the polygon to 8 points without overflow.

Other data within this struct are presently unknown. 



