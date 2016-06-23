open Suave
open System.Net
open Suave.Filters
open Suave.Operators
open Suave.Successful

// create my own config
let myConfig = { defaultConfig with bindings=[HttpBinding.mk HTTP IPAddress.Any 8083us] }

let myWebpart = 
    choose [
        path "/" >=> OK "It works!!!"
        path "/ahoj" >=> OK "FSharp is cool"
    ]

// run my server
startWebServer myConfig myWebpart