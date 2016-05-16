let makeResource name = 
    { new System.IDisposable 
        with member this.Dispose() = printfn "%s disposed" name }
let useAndDisposeResources = 
    use r1 = makeResource "first resource"
    printfn "using first resource" 
    for i in [1..3] do
        let resourceName = sprintf "\tinner resource %d" i
        use temp = makeResource resourceName 
        printfn "\tdo something with %s" resourceName 
    use r2 = makeResource "second resource"
    printfn "using second resource" 
    printfn "done." 


















//---Redis
#r @"packages\ServiceStack.Redis.4.0.56\lib\net40\ServiceStack.Redis.dll"
#r @"packages\ServiceStack.Common.4.0.56\lib\net40\ServiceStack.Common.dll"
#r @"packages\ServiceStack.Text.4.0.56\lib\net40\ServiceStack.Text.dll"
#r @"packages\ServiceStack.Interfaces.4.0.56\lib\portable-wp80+sl5+net40+win8+wpa81+monotouch+monoandroid+xamarin.ios10\ServiceStack.Interfaces.dll"

open System 
open System.Collections.Generic 
open ServiceStack.Common
open ServiceStack.Text 
open ServiceStack.Redis

[<CLIMutable>]
type Todo= {Id:int64; Content:string; Order:int; Done:bool} 

let redisClient = new RedisClient("localhost") //6379 
let redisTodos = redisClient.As<Todo>()
let todo= {Id=redisTodos.GetNextSequence();Content = "Learn Redis";Order = 1;Done=false}
redisTodos.Store(todo)
let savedTodo = redisTodos.GetById(todo.Id)






let allTodos = redisTodos.GetAll();; 
assert(allTodos.Count=1);; 
[for i in redisTodos.GetAll() -> i] |> printfn "%A";; 
let savedTodo' = { savedTodo with Done = true };; 
redisTodos.Store(savedTodo');; 
assert( redisTodos.GetAll().Count=1);; 
[for i in redisTodos.GetAll() -> i] |> printfn "%A";; 
let savedTodo2 = redisTodos.GetById(todo.Id);; 
redisTodos.DeleteById(savedTodo.Id);; 
let allTodos2 = redisTodos.GetAll() 
assert(allTodos2.Count=0)

//--JSON
#r @"packages\Newtonsoft.Json.8.0.3\lib\net45\Newtonsoft.Json.dll"

type Record = { Name: string; Age: int }
let r = {Name="BFU"; Age=42}
    
open Newtonsoft.Json
let testJson (x:'t) =
    let json = JsonConvert.SerializeObject(x)
    printfn "%s" json
    let x2:'t = JsonConvert.DeserializeObject<'t>(json)
    x = x2
testJson r

type DU = |Case1 |Case2 of string
testJson Case1
testJson (Case2 "ahoj")









//---RaptorDB
#r @"packages\FsPickler.2.1.0\lib\net45\FsPickler.dll"
#r @"packages\RaptorDB.2.6\lib\net40\RaptorDB.dll"

//[<CLIMutable>]
type TodoRaptor= {Content:string; Order:int; Done:bool} 
let todo= {Content = "Learn Redis";Order = 1;Done=false};; 

open System
module Raptor =
    open RaptorDB

    let serializer = Nessos.FsPickler.BinarySerializer()
    let Create<'k when 'k :> IComparable<'k>> path =
        if System.IO.File.Exists path then System.IO.File.Delete path
        new RaptorDB<'k>(path, false)
    let Set key value (db: KeyStore<_>) = 
        let x = db.Set(key, serializer.Pickle value)
        assert (x > 0)
    let Get<'v> key (db: KeyStore<_>) =
        let (result, x: byte[]) = db.Get(key)
        if result then Some (serializer.UnPickle<'v> x) else None

let rdb = Raptor.Create<Guid> @"C:\Tmp\raptor.db"
let todos = [todo]
let guids = todos |> Seq.map (fun t -> let g = Guid.NewGuid() in rdb |> Raptor.Set g t; t,g) |> dict
let x = rdb |> Raptor.Get<Todo>(guids.[todo])
let x' = { x.Value with Done = true }
rdb |> Raptor.Set guids.[todo] x'
let x'' = rdb |> Raptor.Get<Todo>(guids.[todo])
printfn "%A" (x'')

