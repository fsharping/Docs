#r "packages/FSharp.Data/lib/net40/FSharp.Data.dll"
#r "System.Xml.Linq.dll"

open FSharp.Data
open System.Xml.Linq

/// Basic usage
type Notes = XmlProvider<"Notes.xml">
Notes.GetSample()


/// Change data
let sample = Notes.GetSample()

//sample.From <- "This won`t work"

sample.XElement.SetElementValue(XName.Get("from"), "HA a mam te!")
sample


/// Global parameter
[<Literal>]
let sampleHtml = """
<div id="root">
  <span>Main text</span>
  <div id="first">
    <div>Second text</div>
  </div>
</div>"""

type GlobalFalse = XmlProvider<sampleHtml, Global = false>
GlobalFalse.Div
type GlobalTrue = XmlProvider<sampleHtml, Global = true>
GlobalTrue.Div