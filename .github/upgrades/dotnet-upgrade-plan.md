# .NET 9.0 Upgrade Plan

## Execution Steps

Execute steps below sequentially one by one in the order they are listed.

1. Validate that a .NET 9.0 SDK required for this upgrade is installed on the machine and if not, help to get it installed.
2. Ensure that the SDK version specified in global.json files is compatible with the .NET 9.0 upgrade.
3. Upgrade SuperTray2.csproj

## Settings

This section contains settings and data used by execution steps.

### Aggregate NuGet packages modifications across all projects

NuGet packages used across all selected projects or their dependencies that need version update in projects that reference them.

| Package Name                        | Current Version | New Version | Description                         |
|:------------------------------------|:---------------:|:-----------:|:------------------------------------|
| Newtonsoft.Json                     |   13.0.1        |  13.0.4     | Security vulnerability              |

### Project upgrade details
This section contains details about each project upgrade and modifications that need to be done in the project.

#### SuperTray2.csproj modifications

Project properties changes:
  - Target framework should be changed from `net472` to `net9.0-windows`
  - Project file needs to be converted to SDK-style format

NuGet packages changes:
  - Newtonsoft.Json should be updated from `13.0.1` to `13.0.4` (*security vulnerability*)

Other changes:
  - Convert project file from old .NET Framework format to modern SDK-style format