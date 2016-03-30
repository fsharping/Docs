// interface
type ICalculator =
    abstract member Add : int -> int -> int

type MyCalculator() =
    interface ICalculator with
        member this.Add x y = x + y

    interface System.IDisposable with
        member this.Dispose() = printfn "Disposed"

// using instances
let calc = new MyCalculator()
calc.Add // ERROR!
let myCalc = calc :> ICalculator
myCalc.Add 10 20 // Now it works


// inheritance
type ClassA() =
    member this.A = "A"

type ClassB() =
    inherit ClassA()
    member this.B = "B"

let b = ClassB().B

// properties and constructors
type MyClass(myProp) =
    let mutable myProperty = myProp
    member this.MyProperty 
        with get() = myProperty
        and set(value) = myProperty <- value // mutable here!
    member val AutoProperty = "init value" with get, set // autoproperty
    new() = MyClass("init value") // empty constructor
    member private this.PrivateValue = 2
    member internal this.InternalValue = 3
  
MyClass()
MyClass("some value")     