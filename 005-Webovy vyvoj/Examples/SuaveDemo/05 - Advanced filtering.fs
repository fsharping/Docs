open Suave
open System.Net
open Suave.Filters
open Suave.Operators
open Suave.Successful

// create my own config
let myConfig = { defaultConfig with bindings=[HttpBinding.mk HTTP IPAddress.Any 8083us] }

let myWebpart = 
    choose [
        GET >=> path "/" >=> OK "It works!!!"
        POST >=> path "/ahoj" >=> OK "FSharp is cool"
    ]

let differentWebpart = 
    choose [
        GET >=> choose [
            path "/" >=> OK "GET on root"
            path "/ahoj" >=> OK "GET on /ahoj"
        ]
        POST >=> choose [
            path "/" >=> OK "POST on root"
            path "/ahoj" >=> OK "POST on /ahoj"
        ]
    ]

// run my server
startWebServer myConfig myWebpart