#r "packages/FSharp.Data/lib/net40/FSharp.Data.dll"
#r "packages/FSharp.Charting/lib/net40/FSharp.Charting.dll"

open FSharp.Data
open FSharp.Charting

/// Basic usage
type Users = CsvProvider<"Users.csv">

Users.GetSample().Rows
|> Seq.map (fun row -> row.Name, row.Age)
|> Chart.Bar
|> Chart.WithTitle "Young FSharpers"
|> Chart.Show



/// Custom separator and headers
type CustomSeparator = CsvProvider<
                        "UsersNoHeader.csv", 
                        Separators = "|",
                        HasHeaders = false,
                        //Schema = "Name, Whatever, Age">
                        Schema = "Name, Whatever, Age (float)">
                        //Schema = "Name, Whatever, LastActive (float<second>)">

CustomSeparator.GetSample().Rows
|> Seq.iter (fun row -> printfn "%A" row.Age)



/// Built-in filtering
/// Supported are Filter, Take, TakeWhile, Skip, SkipWhile, and Truncate
Users.GetSample()
    .Filter(fun row -> row.Age > 20.M)
    .Take(2)
    .SaveToString(';')