#r "packages/FSharp.Data.SqlClient/lib/net40/FSharp.Data.SqlClient.dll"

open FSharp.Data
open System

[<Literal>]
let connectionString = 
    @"Data Source=.;Initial Catalog=FSharping;Integrated Security=True"

type GetUsers = SqlCommandProvider<"SELECT Name, Surname FROM Users", connectionString>

let cmd = GetUsers(connectionString) // use different source
cmd.Execute() |> Seq.toList


// SQL files support
let cmdFromFile = new SqlCommandProvider<"GetUsers.sql", connectionString>(connectionString)
cmdFromFile.Execute() |> Seq.toList


// SQL files support
let cmdSearchUsers = new SqlCommandProvider<"GetFilteredUsers.sql", connectionString>(connectionString)
cmdSearchUsers.Execute("prov") |> Seq.toList
//cmdSearchUsers.ToTraceString("e")