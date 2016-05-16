namespace Interop

module Module =
    let plus x y = x + y



























open System.Runtime.CompilerServices
[<Extension>]
type public FSharpFuncUtil = 

    [<Extension>] 
    static member ToFSharpFunc<'a,'b> (func:System.Converter<'a,'b>) = fun x -> func.Invoke(x)

    [<Extension>] 
    static member ToFSharpFunc<'a,'b> (func:System.Func<'a,'b>) = fun x -> func.Invoke(x)

    [<Extension>] 
    static member ToFSharpFunc<'a,'b,'c> (func:System.Func<'a,'b,'c>) = fun x y -> func.Invoke(x,y)

    [<Extension>] 
    static member ToFSharpFunc<'a,'b,'c,'d> (func:System.Func<'a,'b,'c,'d>) = fun x y z -> func.Invoke(x,y,z)

type Fun() =
    static member Fun (func:System.Func<'a,'b>) = FSharpFuncUtil.ToFSharpFunc func
    static member Fun (func:System.Func<'a,'b,'c>) = FSharpFuncUtil.ToFSharpFunc func
    static member Fun (func:System.Func<'a,'b,'c,'d>) = FSharpFuncUtil.ToFSharpFunc func












module FSharpTypes =
    type Record = { Name: string; Age: int }
    
    type DU =
        | Case1
        | Case2 of string 

    let (|Positive|Negative|) x =
        if x >= 0 then Positive else Negative



















type FNum(x: int) =
    static member op_Implicit (s: string) = 
        let success, x = s |> System.Int32.TryParse
        FNum(if success then x else 999)
