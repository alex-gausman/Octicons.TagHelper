# Octicons TagHelper
An ASP.NET Core Tag Helper for [GitHub's Octicon](https://octicons.github.com/) icon set.

## Setup
1. Install via NuGet
```powershell
Install-Package Octicons.TagHelper -Version 1.0.0-alpha -Pre
```
2. Add the tag helper to your view or `_ViewImports.cshtml` to access from any view.
```csharp
@addTagHelper *, Octicons.TagHelper
```

## Usage
To render a symbol, use the `<octicon>` tag.

<img src="https://raw.githubusercontent.com/alex-gausman/Octicons.TagHelper/alpha/octicon-in-action.gif">