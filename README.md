# Fable.Import.AutosuggestHighlight

This package provides Fable bindings for [autosuggest-highlight](https://github.com/moroshko/autosuggest-highlight).

## Installation

* Install the `autosuggest-highlight` npm package:
  * using npm: `npm install autosuggest-highlight`
  * using yarn: `yarn add autosuggest-highlight`

* Install the bindings:
  * using dotnet: `dotnet add package Fable.Import.AutosuggestHighlight`
  * using paket: `paket add Fable.Import.AutosuggestHighlight`

## Example usage

The easiest way is to use the convenience function `getParts`:

```f#
getParts : (query: string) -> (text: string) -> (string * bool) list
```

This function returns consecutive parts of `text` with a boolean indicating whether the part should be highlighted. How you then use and render this data is entirely up to you.

You can also access the “native” autosuggest-highlight functions (`match` and `parse`) in the `Native` submodule.

The following is a basic example that assumes you have a CSS class called `highlighted` that takes care of styling highlighted parts of the text.

```f#
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

let view =
  div [ ] [
    "Hello, world!"
    |> AutosuggestHighlight.getParts "wo"
    |> List.map (fun (s, hl) -> span [ if hl then yield Class "highlighted" ] [ str s ] )
    |> fragment []
  ]
```

Changelog
---------

#### 1.0.0 (2019-01-12)

* Initial release

## Deployment checklist

1. Make necessary changes to the code
2. Update the changelog
3. Update the version and release notes in the package info, as well as the message stating which `autosuggest-highlight` version the bindings are created for.
4. Commit and tag the commit (this is what triggers deployment from  AppVeyor). For consistency, the tag should ideally be in the format `v1.2.3`.
5. Push the changes and the tag to the repo. If AppVeyor build succeeds, the package is automatically published to NuGet.
