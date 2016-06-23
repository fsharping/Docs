open Suave
open System.Net
open Suave.Filters
open Suave.Operators
open Suave.Successful
open Suave.RequestErrors

// create my own config
let myConfig = { defaultConfig with bindings=[HttpBinding.mk HTTP IPAddress.Any 8083us] }

let myWebpart = 
    choose [
        GET >=> choose [
            path "/" >=> OK "It works!!!"
            pathScan "/user/%s" (fun user -> OK <| sprintf "ID v path bylo %s" user)
            pathRegex "(.*)\.(css|js|png|otf|eot|svg|ttf|woff|woff2|ico|xml|json)" >=> Files.browseHome
            pathRegex "(.*)" >=> NOT_FOUND "Tady nic neni"
        ]
    ]

// run my server
startWebServer myConfig myWebpart
