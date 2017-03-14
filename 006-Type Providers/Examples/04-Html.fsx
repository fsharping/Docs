#r "packages/FSharp.Data/lib/net40/FSharp.Data.dll"

open FSharp.Data

let [<Literal>] FSharpWiki = 
  "https://en.wikipedia.org/wiki/F_Sharp_(programming_language)"

let wiki = new HtmlProvider<FSharpWiki>()

let versionTable = wiki.Tables.Versions//.Tables.Versions

for row in versionTable.Rows do
    printfn "Version %A released in %A" row.Version row.Date


/// Query data
query {
    for info in wiki.Tables.``F#``.Rows do
    where (info.Column1.Contains("License") || info.Column2.Contains(".NET"))
    select info
} 
|> Seq.toList

