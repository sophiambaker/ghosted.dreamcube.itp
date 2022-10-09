# DreamCube Boilerplate Project

This program known as the _Pitch_ is the main software component needed to run for the _DreamCube's_ interactive virtual reality room. The main attraction is an arcade-style ball game using a physical ball tracked in three-dimensions. This repo contains two simple example scenes for modes of interaction.

This project relies on [dreamcube.itp.pitch.core](https://github.com/local-projects/dreamcube.itp.pitch.core.unity) repo as a submodule.
Fork this repo and build a new DreamCube experience.

**WARNING: DO NOT make changes to any of the Base Scenes, or Main scene.   
Those are critical for running your project in the DreamCube**



<!-- TOC -->

## Table of Contents

- [DreamCube Boilerplate Project](#dreamcube-boilerplate-project)
  - [Table of Contents](#table-of-contents)
  - [Project Details](#project-details)
    - [Resources](#resources)
    - [Requirments for running (in the DreamCube)](#requirments-for-running-in-the-dreamcube)
    - [Dependencies & Frameworks](#dependencies--frameworks)
  - [Installation](#installation)
  - [Usage in Development](#usage-in-development)
  - [Troubleshooting](#troubleshooting)
  - [Roadmap](#roadmap)
  - [License](#license)
  - [Notes](#notes)

---

<!-- Project Details -->

## Project Details

![preview](/Docs/Images/dreamcube-preview.gif "preview")





### Resources
[DreamCube Boilerplate Documentation](https://docs.google.com/document/d/1qU17cycwCfQY6YHS1GuJ5G8Q9AVFDr5-sjQn6RVZyus/edit?usp=sharing)


### Requirments for running (in the DreamCube)
- Video card with 4 outputs such as Geforce RTX 2060
- Dante multichannel soundcard
- Optitrack tracking system
- RTLS server
- 4 Projectors supporting 1920x1200 resolution
- 

### Dependencies & Frameworks

The following packages are used in compilation.

- JetBrains Rider Editor
- Cinemachine
- ProBuilder
- Test Framework
- TextMeshPro
- Timeline
- Unity Collaborate
- Unity Recorder
- Unity UI
- Universal RP
- Shader Graph
- Visual Effect Graph
- Version Control
- Visual Studio Code Editor
- Visual Studio Editor


The following applications are used in development.

- [Unity 2021.3.6](https://download.unity3d.com/download_unity)
- [Visual Studio 2019](https://visualstudio.microsoft.com/) + [ReSharper](https://www.jetbrains.com/resharper/) or [Rider](https://www.jetbrains.com/rider/)


The following libraries and their dependencies are included in the `Plugins` folder.

- [Google.Protobuf 3.11.4](https://www.nuget.org/packages/Google.Protobuf)
- [DoTween](https://github.com/Demigiant/dotween)
- [Odin - Serializer](https://github.com/TeamSirenix/odin-serializer)


<!-- Installation -->

## Installation

1. Fork the repo
2. Rename the repo (To your project name)
3. Clone your fork `git clone [your forks name]`
4. Load the core submodule `git submodule update --init --recursive`
5. Set the configuration file:

An external settings file is required. It's located at `StreamingAssets\general_config.json`.
If the file does not exist it will be created using the default values at first run.

`DreamCube` - Name of assigned DreamCube <br />
`Debug` - Whether the app is in debug mode <br />
`RTLSLocalIP` - IP of the computer's NIC running this software to which you want to bind RTLS <br />
`RTLSRemoteIP` - IP of the RTLS Server <br />
`RTLSPort` - Port of the RTLS <br />
`UseASIO`- Audio output to the DSP <br />
`ASIODriverIndex`- Audio output Index <br />
`AsioAutoDetectName` - Audio output name <br />
`DSPBufferLength` - DSP Buffer length <br />
`DSPBufferCount` - DSP Buffer Count <br />


```
{
  "DreamCube": "1",
  "Debug": false,
  "UseRTLS": true,
  "RTLSLocalIP": "192.168.x.x",
  "RTLSRemoteIP": "192.168.x.x",
  "RTLSPort": 8282,
  "UseASIO": true,
  "ASIODriverIndex" : 0,
  "AsioAutoDetectName" : "RedNet PCIe",
  "DSPBufferLength" :1024,
  "DSPBufferCount" :8,
}
```

<!-- USAGE -->

## Usage in Development

1. Open the project with [Unity Hub](https://unity3d.com/get-unity/download). It will prompt you to download the correct version of the Unity editor.  
   
2. Open Assets/_DemoApp/Scenes/Main  
   
3. Switch game view to Display 5 or 6  
    
4. Hit play and click on the game view to kick the ball  
   
5. Build the project according to [Unity's documentation](https://docs.unity3d.com/Manual/PublishingBuilds.html).


<!-- TROUBLESHOOTING -->
## Troubleshooting

_The program does not show on the correct displays._<br />
In the Windows or GPU display manager, the displays should be tiled left to right with indices 1-4. Display 1 should set to the `primary screen`.

For more detail, you should refer to the ~~Dreamcube Handbook~~

<!-- ROADMAP -->

## Roadmap


<!-- LICENSE -->

## License

© Copyright 2020 Local Projects, Inc., All Rights Reserved.
_See `LICENSE` for more information._

---

<!-- NOTES -->

## Notes



