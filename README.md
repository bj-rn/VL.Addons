# VL.Addons
[![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/VL.Addons?style=flat-square)](https://www.nuget.org/packages/VL.Addons)

A place to gather contributions by the vvvv community that:

- don’t get added to the core libraries for _reasons_
- don’t (yet?) merit their own nuget packages
- get lost in the chat or forum otherwise


## Using the library

As of version __0.5.0__ VL.Addons is split into multiple packages, one for each available category, currently:

* VL.Addons.2D
* VL.Addons.Animation
* VL.Addons.Collections
* VL.Addons.Color
* VL.Addons.Control
* VL.Addons.Math
* VL.Addons.Skia
* VL.Addons.Stride


In order to use one of the packages with VL you have to install the corresponding nuget that is available via nuget.org. For information on how to use nugets with VL, see [Managing Nugets](https://thegraybook.vvvv.org/reference/hde/managing-nugets.html) in the VL documentation. As described there you go to the commandline and then type for example:

    nuget install VL.Addons.Stride

Beware that some help patches from one package might be dependent on another package. If you encounter red nodes just install the missing package.

There is also a *VL.Addons* meta package, installing it will install all available packages in one go. Use the following cmd:

    nuget install VL.Addons

---
### License

### [MIT](https://github.com/bj-rn/VL.Addons/blob/master/LICENSE)
