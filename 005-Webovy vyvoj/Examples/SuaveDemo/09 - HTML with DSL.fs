open Suave
open System.Net
open Suave.Filters
open Suave.Operators
open Suave.Successful
open Suave.RequestErrors
open System
open Suave.Writers
open Suave.Html

let divId id = divAttr ["id", id]
let h1 xml = tag "h1" [] xml
let aHref href = tag "a" ["href", href]

let index =
    html [
        head [
            title "FSharping Amazing Page"
        ]
        body [
            divId "header" [
                h1 (aHref "/" (text "F# is Cool"))
            ]
            divId "footer" [
                text "built with "
                aHref "http://fsharp.org" (text "F#")
                text " and "
                aHref "http://suave.io" (text "Suave.IO")
            ]
        ]
    ] |> xmlToString

// create my own config
let myConfig = { defaultConfig with bindings=[HttpBinding.mk HTTP IPAddress.Any 8083us];}

let myWebpart = 
    choose [
        GET >=> choose [
            path "/" >=> OK index
        ]
    ]

// run my server
startWebServer myConfig myWebpart
