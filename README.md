# Mod Manager
Mod Manager is a program for [Hacknet Pathfinder](https://github.com/Arkhist/Hacknet-Pathfinder/releases) that allows you to manage mods from GitHub and on your local computer.

## Installation
Download the latest release and unzip the file into your Hacknet installation folder (typically `C:\Program Files (x86)\Steam\steamapps\common\Hacket`).

## Planned Features
* Dark and light theme
* More supported mod formats
* Mod requirements and includes

## For Mod Authors
Mod Manager has some requirements for reading and storing information about your mod.

* Only GitHub repositories are supported at this time.
* GitHub releases must be packaged as .zip files.
* Mod information is read from a file with the name <modname>.hackmod in JSON format.

### Mod Info JSON
Your mod's .dll file and .hackmod file should have the same name. The .hackmod file should follow a JSON format and should include these attributes (*attributes are case-sensitive*):

* **Title**: Title (does not have to match .dll file)
* **Description**: Description
* **Version**: Version number
* **Homepage**: Homepage URL
* **Repository**: GitHub repository URL
* **Authors**: List of authors
* **Info**: Information about the mod and its usage

Example format:
```json
{
    "Title": "My Mod",
    "Description": "This is my mod",
    "Version": "v1.0",
    "Homepage": "http://www.example.com",
    "Repository": "https://github.com/myname/mymod",
    "Authors": ["myname", "theirname"],
    "Info": "This is my mod for Hacknet."
}
```

## Credits
* [Zortex](https://github.com/Zortex04) for the dark theme (upcoming)
* [oxygencraft](https://github.com/oxygencraft) for the releases window