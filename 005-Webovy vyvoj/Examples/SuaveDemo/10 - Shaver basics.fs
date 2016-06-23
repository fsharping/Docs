open Suave
open System.Net
open Suave.Filters
open Suave.Operators
open Suave.Successful
open Suave.RequestErrors
open System
open Suave.Writers
open Suave.Html

type MujModel = {
    Name : string
    Surname : string
}

let showModel = 
    let model = { Name = "Jiří"; Surname = "Krupka"}
    Shaver.Razor.singlePage "Template.html" model

// create my own config
let myConfig = { defaultConfig with bindings=[HttpBinding.mk HTTP IPAddress.Any 8083us];}

let myWebpart = 
    choose [
        GET >=> choose [
            path "/" >=> showModel
        ]
    ]

// run my server
startWebServer myConfig myWebpart