# FilePath
Local file path string parser / descriptor for .NET application.

## help me.
I'm not good at English. English is very difficult desu!

## This library contains...

### class `Filepath`

- static method `Filepath Parse(string? aInput)`
	- parse the input string, and returns a `Filepath` instance.
	- `Filepath` can parse...
		- simple UNIX path
			- ex) `"/foo/bar/baz.ext"`
		- trasitional DOS path
			- ex) `@"c:\Program Files\Some\File.ext"` (back slash)
			- ex) `@"c:/Program Files/Some/File.ext"` (normal slash)
		- DOS device path
			- ex) `@"\\.\VOLUME{ASDFASDF}\directory\file.ext"`
			- ex) `@"\\?\C$\directory\file.ext"`
			- ex) `@"\\?\UNC\server\share-name\directory\file.ext"`
		- UNC
			- ex) `@"//server/share-name/directory/file.ext"`
- Property `IPathPrefix Prefix`
	- opaque object, represents a drive letter, server and share-name, and so on...
- Property `bool Absolute`
	- `true` if the input string represents an absolute path.
- Property `string[] Items`
	- directories and file name.
- Property `string LastItem`
	- the last item of the `Items`, or `string.Empty` if `Items` is empty.
- Property `bool HasExtension`
	- equivalent to `System.IO.Path.HasExtension`
	- note: for example, `".git"` does not have an extension.
- Property `string Extension`
	- equivalent to `System.IO.Path.GetExtension`
- Property `string LastItemWithoutExtension`
	- equivalent to `System.IO.Path.GetFileNameWithoutExtension`
- Property `Filepath Parent`
	- gets a parent directory path object.
	- equivalent to `this.Ascend(1)`
	- equivalent to `this.Slice(0, -1)`
- Method `Filepath Ascend(int aLevel = 1)`
	- (TODO)
- Method `Filepath Canonicalize()`
	- omits `"."`, resolves `".."`, and returns a new instance.
	- maybe equivalent to `PathCanonicalize()` of `shlwapi.dll` (I believe so)
- Method `Filepath Combine(string aOther)`
- Method `Filepath Combine(Filepath aOtherPath)`
	- combines another path string.
- Method `Filepath Slice(int aStart, int aCount = int.MaxValue)`
	- (TODO)
- Method `string ToString(string directorySeparator)`
	- builds the path string, joining directory names with `directorySeparator`
- overridden Method `string ToString()`
	- equivalent to `ToString(System.IO.Path.DirectorySeparatorChar.ToString())`


## sample app
Build the sample application
```
PS > cd .\src\Tkuri2010.Filepath.Xmp
PS > dotnet build
 (building..)
```

and you can run it:
```
PS > cd .\bin\Debug\netcoreapp3.1
PS > Tkuri2010.Filepath.Xmp.exe   x:\some\dir\and\file.dat
```
shows:
```
input path = x:\some\dir\and\file.dat
=======================================================
     prefix : x:
is absolute?: True
     item 0 : some
     item 1 : dir
     item 2 : and
     item 3 : file.dat
  last item : file.dat
    has ext?: True
  last item without ext: file
  extension : .dat
```

another example:
```
PS > Tkuri2010.Filepath.Xmp.exe   //?/UNC/server/share-name/dir/file
input path = \\?\UNC\server\share-name\dir\file
=======================================================
     prefix : \\?\UNC\server\share-name
is absolute?: True
     item 0 : dir
     item 1 : file
  last item : file
    has ext?: False
  last item without ext: file
  extension :
```
