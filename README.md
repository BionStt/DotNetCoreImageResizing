# DotNetCoreImageResizing

Image resizing is a common requirement but .NET Core currently does not have System.Drawing or something equivalent for this, so we have to rely on third party libraries.

 I created this repo to demonstrate how to perform image resizing with some of these libraries and to compare their performance in terms of speed and output file size. 

I've included two libraries [Magick.NET](https://github.com/dlemstra/Magick.NET) and [ImageSharp](https://github.com/SixLabors/ImageSharp). Please note my sampling size is small and comparison is by no means conclusive, play with the demo and make your own conclusions.

![magicknet-vs-imagesharp](https://user-images.githubusercontent.com/633119/56047485-55a58100-5cfa-11e9-83af-9ff3f6d32504.png)