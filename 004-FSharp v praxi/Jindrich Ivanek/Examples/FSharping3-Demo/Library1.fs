namespace FSharping3_Demo

module Module =
    open System.Linq
    let run() =
        let x = ("foo", 1L, 0.2) |> CSharpLibrary.Class1.Method
        [1;2;3].Where(fun i -> i%2=0)
        let c = CSharpLibrary.Class1(1, Field2="ahoj")
        c
        
module TypeInference =
    open System.Linq
    let evens xs = xs |> Seq.filter (fun i -> i%2=0)
    let evensLinq (xs:seq<_>) = xs.Where(fun i -> i%2=0)
    let sd = System.Collections.Generic.SortedDictionary<_,_>([1,"foo"; 2,"goo"] |> dict)

module OutParameter =
    let _ =
        let success, x = "42" |> System.Int32.TryParse
        x

type OptionalParams() =
    static member Method(?x: int, ?printIt: bool) =
        let x = defaultArg x 0
        let printIt = defaultArg printIt false
        if printIt then printfn "%i" x
        x


module WithExtCore =
    open ExtCore
    let d: dict<_,_> = ["foo", 1; "goo", 2] |> dict
    let d2 = d |> Dict.add "hoo" 3
    match d2 |> Dict.tryFind "joo" with
    | None -> printfn "Nope"
    | Some x -> printfn "%i" x































module Implicit =
    open CSharpLibrary
    //MyClass("ahoj") //error
    let x = Num.op_Implicit("42")

    let inline (!!) (x:^a) : ^b = ((^a or ^b) : (static member op_Implicit : ^a -> ^b) x)
    let x2:Num = !!"42"

    let f (c:Num) = ()
    f !!"42"


















module JSON =
    type Record = { Name: string; Age: int }
    let r = {Name="BFU"; Age=42}
    
    open Newtonsoft.Json
    let json = JsonConvert.SerializeObject(r)
    let r2 = JsonConvert.DeserializeObject<Record>(json)
    r = r2

