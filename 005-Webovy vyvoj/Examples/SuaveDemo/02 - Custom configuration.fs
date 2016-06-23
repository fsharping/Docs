open Suave
open System.Net

// create my own config
let myConfig = { defaultConfig with bindings=[HttpBinding.mk HTTP IPAddress.Any 8083us] }

// run my server
startWebServer myConfig (Successful.OK "Hello World!")