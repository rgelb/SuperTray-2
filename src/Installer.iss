[Setup]
AppName=SuperTray/2
AppVerName=SuperTray/2
AppCopyright=Copyright (C) 1995-2019 Robert Gelb
AppPublisher=Robert Gelb
DefaultDirName={userpf}\SuperTray2
DisableDirPage=yes
DisableProgramGroupPage=yes
DisableReadyPage=yes
;DefaultGroupName=Super Tray/2
UninstallDisplayIcon={app}\SuperTray2.exe
OutputBaseFilename=SuperTray2
AppID=SuperTray/2
PrivilegesRequired=lowest

[Files]
Source: "bin\release\SuperTray2.exe"; DestDir: "{app}"
Source: "bin\release\SuperTray2.exe.config"; DestDir: "{app}"
Source: "bin\release\Newtonsoft.Json.dll"; DestDir: "{app}"

[Icons]
Name: "{userstartup}\SuperTray2"; Filename: "{app}\SuperTray2.exe"; 

[Run]
Filename: "{app}\SuperTray2.exe"; Description: "Launch SuperTray/2"; Flags: postinstall nowait skipifsilent

[UninstallRun]
Filename: "{cmd}"; Parameters: "/C ""taskkill /im SuperTray2.exe /f /t"