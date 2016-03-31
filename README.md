# What's this?

This is an extension for Visual Studio "15", adding support for debugging [scriptcs](http://scriptcs.net) scripts, when opening them with "Open Folder".

**Note**: this is a very early preview, and everything might change in the future.

## Information

At [Build 2016](https://build.microsoft.com/), Microsoft announced a new Visual Studio feature called **Open Folder**:

> Open Folder is a convenient way to navigate code bases without projects and solutions. The Solution Explorer has a new button to switch between Solution and Folder views. If MSBuild-based projects exist in the folder, the editor will provide IntelliSense for C# or Visual Basic files, and you can build or debug by using F5 and the file context menu in the Solution Explorer. Python and Node.js scripts can also be debugged after the respective Visual Studio tools are installed. Version control operations are available in the Solution Explorer for folders under Git version control.

![](https://i3-vso.sec.s-msft.com/dynimg/IC850198.png)

## Installation and configuration:

Grab the latest vsix file from the [Releases](../../Releases) page, and double-click it to install in Visual Studio.

Once installed, open Visual Studio "15", select **File > Open > Folder...**, and select a folder containing scriptcs (*.csx) files

Right click on any .csx file, and select **Set as Startup Item**:  

![image](https://cloud.githubusercontent.com/assets/601206/14170386/32a12268-f736-11e5-9d49-3aef4607ed52.png)

Finally, click the dropdown arrow of the Debug button, and select **Customize**:

![image](https://cloud.githubusercontent.com/assets/601206/14170490/c1e802f2-f736-11e5-9a5b-75d70507c0e1.png)

A file called **launch.json** will open. We need to specify the path to **scriptcs.exe** inside the file like this:
 
```
{
  "version": "0.2.0",
  "configurations": [
    {
      "name": "HelloWorld.csx",
      "project": "HelloWorld.csx"
	  "scriptcs_exe" : "C:\\dev\\scriptcs\\src\\ScriptCs\\bin\\Release\\scriptcs.exe"
    }
  ]
}
```

Save the file, and press F5!

![image](https://cloud.githubusercontent.com/assets/601206/14171166/3d7b216c-f73a-11e5-9be9-46aa49bed80b.png)
