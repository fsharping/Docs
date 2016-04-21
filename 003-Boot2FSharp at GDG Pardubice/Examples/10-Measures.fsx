[<Measure>]
type cm

[<Measure>]
type m = 
    static member ConvertToCm(x : float<m>) = float x * 100.0<cm>

m.ConvertToCm(50.0<m>)

let toCm (m:float<m>) = float m * 100.0<cm>
let toM (cm:float<cm>) = float cm / 100.0 * 1.0<m>

let distance = 2<m>
let area = 2<m> * 2<m>

let howFar distance =
    match distance with
    | x when x < 100.0<m> -> "Quite close"
    | _                 -> "Far"

howFar 10.0 // error! No measure!!!
howFar 100.0<cm> // error! Wrong measure!
howFar 50.0<m>

500.0<cm> 
|> toM 
|> howFar


// Prebuilt measures in namespace
//open Microsoft.FSharp.Data.UnitSystems.SI.UnitNames   
//open Microsoft.FSharp.Data.UnitSystems.SI.UnitSymbols

