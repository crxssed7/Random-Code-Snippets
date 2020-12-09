# C# Code Snippets - Documentation

# Functions:

## CompressImage(string ImageFilePath, int CompressSize)
This function compresses the image stored at the specified path (ImageFilePath).
The CompressSize integer indicates how much the image should be compressed. For example, if CompressSize = 2, then the resulting image will be half the size of the original.
The implementation is very memory efficient as it doesn't keep the files open while used, instead it uses the Windows Forms `Graphics` class to redraw the image into a `Bitmap` object.

## HideScrollBars(Panel panel)
This function hides the ugly scroll bars that are shown in a scrollable control.
The implementation mentioned in `HideScrollBars.cs` does not need to be in a function (of course) and can be used on any scrollable `Control`.
NOTE: In order for the implementation to work, the Controls `AutoScroll` property needs to be set to `false` in the designer.