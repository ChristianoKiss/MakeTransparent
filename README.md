# MakeTransparent
Simple .NET 5 console application that takes an image as argument and applies transparency where colour is magenta.

The `csproj` has been configured to build the application as a stand-alone Windows executable. Just type the following command in the terminal:

`dotnet publish -c Release`

And the executable will be available at `.\bin\Release\net5.0\win-x64\publish\`.

To get a basic help about the application, open a console and type `MakeTransparent.exe /?` to get help.

To perform the conversion, type `MakeTransparent.exe some-image-file.png` to create a transparent version of the file named `some-image-file-converted.png` in the same directory.
