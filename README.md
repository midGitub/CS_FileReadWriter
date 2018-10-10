# CS_FileReadWriter

FileReadWriter provide easy way to read/write file. Ex, when output path has not existing directory, it will be created.

**NOTE:** This project is made by Unity, but it ``FileReadWriter.cs`` works on a native C#.

## Import to Your Project

### Unity

You can import this asset from UnityPackage.

- [FileReadWriter.unitypackage](https://github.com/XJINE/CS_FileReadWriter/blob/master/FileReadWriter.unitypackage)

### C#

Import ``FileReadWriter/FileReadWriter.cs`` to your project.

## How to Use

``FileReadWriter.cs`` is static class. So you can call any method from any place.

```csharp
public string filePath = "~";
public string fileContent = "Sample";
protected string result = "";

result = FileReadWriter.ReadFile(filePath).content;
result = FileReadWriter.WriteFile(filePath, fileContent).content;
```

Default encoding is ``UTF-8`` but you can change the encoding with argument if you need.

And in default, When output path has not existing directory, it will be created.
This is useful to avoid ``Not found exception``.
Also this setting is enabled to change with argument too.