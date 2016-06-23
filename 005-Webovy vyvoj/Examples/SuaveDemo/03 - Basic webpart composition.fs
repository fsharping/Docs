open Suave
open System.Net
open Suave.Filters
open Suave.Operators
open Suave.Successful

// create my own config
let myConfig = { defaultConfig with bindings=[HttpBinding.mk HTTP IPAddress.Any 8083us] }

let myWebpart = OK "Ahoj lidi" >=> OK "Jak se mate" >=> OK "Ulicnici?"
let mySecondPart = OK "A co tohle?" >=> None |> async.Return
    
// run my server
startWebServer myConfig myWebpart