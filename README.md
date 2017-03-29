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

# <img src="https://raw.githubusercontent.com/alex-gausman/Octicons.TagHelper/alpha/octicon-in-action.gif">

If you want to optimize your page size, use the sprite sheet tag helper.

1. Add this to your layout page
```html
<octicon-sprite-sheet></octicon-sprite-sheet>
````

2. Add use-sprite to the octicon tag. This will reference the svg path in the sprite sheet
```html
<octicon symbol="Octoface" use-sprite></octicon>
```

You can go a step further and use the `<include>` tag to define only those icons that you actually use.
```html
<octicon-sprite-sheet>
    <include symbol="Lock"></include>
    <include symbol="Package"></include>
</octicon-sprite-sheet>
```
The above markup will create an svg tag with Lock and Package being the only icons on your page.