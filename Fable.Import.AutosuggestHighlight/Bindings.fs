module Fable.Import.AutosuggestHighlight


open Fable.Core


module Native =

  type Result =
    abstract text: string with get, set
    abstract highlight: bool with get, set

  [<Import("default", "autosuggest-highlight/match")>]
  let ``match`` (text: string) (query: string) : ResizeArray<ResizeArray<float>> = jsNative

  [<Import("default", "autosuggest-highlight/parse")>]
  let parse (text: string) (matches: ResizeArray<ResizeArray<float>>) : ResizeArray<Result> = jsNative



/// Splits the text into consecutive parts with a value indicating whether the
/// part should be highlighted.
let getParts query text =
  Native.``match`` text query
  |> Native.parse text
  |> Seq.map (fun r -> r.text, r.highlight)
  |> Seq.toList
