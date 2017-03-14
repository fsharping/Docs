#r "packages/FSharp.Data/lib/net40/FSharp.Data.dll"
#r "packages/FSharp.Charting/lib/net40/FSharp.Charting.dll"

open FSharp.Data
open FSharp.Charting

let data = WorldBankData.GetDataContext()

data
    .Countries.``Czech Republic``
    .Indicators
    .``Women who believe a husband is justified in beating his wife when she burns the food (%)``
    //``Unemployment with primary education (% of total unemployment)``
|> Chart.Line
|> Chart.Show