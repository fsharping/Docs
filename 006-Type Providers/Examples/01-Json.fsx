#r "packages/FSharp.Data/lib/net40/FSharp.Data.dll"
#r "packages/FSharp.Charting/lib/net40/FSharp.Charting.dll"
open FSharp.Data
open FSharp.Charting

type Repos = JsonProvider<"https://api.github.com/users/dzoukr/repos">

/// Basic queries
for i in Repos.GetSamples() do
    printfn "%s uses %A" i.Name i.Language

let getChartData (providerData:Repos.Root []) =
    query {
        for r in providerData do
        sortBy r.Language
        select (r.Name, defaultArg r.Language "N/A") 
    } 
    |> Seq.countBy snd
    |> Chart.Column
    |> Chart.Show

Repos.GetSamples() |> getChartData


/// Using different Uri
Repos.Load "https://api.github.com/users/jirkapenzes/repos"
|> getChartData

/// Custom sample (with option types)
[<Literal>]
let sample = """
[{
    "name": "Jan",
    "surname": "Novak",
    "age":25
},
{
    "name": "Krupka",
    "surname": "Jiri"
}]
"""

type Sampled = JsonProvider<sample, true>

for i in Sampled.GetSamples() do
    printfn "%s is %A years old" i.Name i.Age

/// Custom sample (from file)
type GithubUser = JsonProvider<"GithubUser.json">
GithubUser.GetSample().Name

/// Custom sample (from file)
type DifferentGithubUser = JsonProvider<"GithubUsers.json", true>
DifferentGithubUser.Load("").Name // expects ONE row, not array (because of true param)

/// Good to know
JsonValue.Parse("") // built-in parser