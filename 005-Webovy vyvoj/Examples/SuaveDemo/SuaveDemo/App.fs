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

type JinyModel = {
    City : string
    Country : string;
    Districts: int
}

let myPage : WebPart =
  [
      ("Menu", Shaver.Razor.partial "Menu.html" None);
      ("Content", Shaver.Razor.partial "Content.html" { Country = "Czech Republic"; City = "Prague"; Districts = 12  })
  ] |> Shaver.Razor.masterPage "Master.html" { Name = "Karel"; Surname = "Karlovic" }


// create my own config
let myConfig = { defaultConfig with bindings=[HttpBinding.mk HTTP IPAddress.Any 8083us];}

let myWebpart = 
    choose [
        GET >=> choose [
            path "/" >=> myPage
        ]
    ]

// run my server
startWebServer myConfig myWebpart
