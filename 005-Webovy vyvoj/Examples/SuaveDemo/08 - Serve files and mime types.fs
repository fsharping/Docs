open Suave
open System.Net
open Suave.Filters
open Suave.Operators
open Suave.Successful
open Suave.RequestErrors
open System
open Suave.Writers

// DEFAULT
//let defaultMimeTypesMap = function
//  | ".css" -> mkMimeType "text/css" true
//  | ".gif" -> mkMimeType "image/gif" false
//  | ".png" -> mkMimeType "image/png" false
//  | ".htm"
//  | ".html" -> mkMimeType "text/html" true
//  | ".jpe"
//  | ".jpeg"
//  | ".jpg" -> mkMimeType "image/jpeg" false
//  | ".js"  -> mkMimeType "application/x-javascript" true
//  | _      -> None

let myAmazingTypes = defaultMimeTypesMap @@ (function | ".avi" -> mkMimeType "video/avi" false | _ -> None)

// create my own config
let myConfig = { defaultConfig with bindings=[HttpBinding.mk HTTP IPAddress.Any 8083us]; mimeTypesMap = myAmazingTypes}

let myWebpart = 
    choose [
        GET >=> choose [
            path "/" >=> Files.file "split.avi"
        ]
    ]

// run my server
startWebServer myConfig myWebpart
