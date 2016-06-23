open Suave
open System.Net
open Suave.Filters
open Suave.Operators
open Suave.Successful
open Suave.RequestErrors
open System

// create my own config
let myConfig = { defaultConfig with bindings=[HttpBinding.mk HTTP IPAddress.Any 8083us] }

let currentTime() = DateTime.Now |> string |> OK

let myWebpart = 
    choose [
        GET >=> choose [
            path "/" >=> currentTime()
            //path "/" >=> warbler(fun ctx -> currentTime())
        ]
    ]

// run my server
startWebServer myConfig myWebpart