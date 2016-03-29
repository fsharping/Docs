// silly one
let sillyOne x =
    match x with
    | 1 -> "It is one!"
    | 2 -> "It is two!"
    | y -> "Well, it is something else... like " + y.ToString()

sillyOne 3

// a little bit smarter
let smarter x =
    match x with
    |1|2|3 -> "From 1 to 3"
    | y when y > 3 && y < 10 -> "From 4 to 10"
    | _ -> "I don`t care"

smarter 10

// now with tuples
let greetings par =
    match par with
    | ("Roman", 34) -> "Roman with 34 years"
    | ("Roman",_) -> "Any Roman"
    | (x, y) when y > 18 -> sprintf "Hi %s, you are old enough for drink" x
    | (x, y) -> sprintf "Hi %s, you are %d years old" x y

greetings ("Roman", 34)
greetings ("Anna", 2)

// shorter one
let greetingsShorter = function
    | ("Roman", 34) -> "Roman with 34 years"
    | ("Roman",_) -> "Any Roman"
    | (x, y) -> sprintf "Hi %s, you are %d years old" x y

// with options
let addTen x =
    match System.Int32.TryParse(x) with
    | (true, value) -> value + 10
    | (false,_) -> -1  

addTen "90"
addTen "nerosumim cecky"

// even try catch is pattern matching
let divide x y =
    try
        Some(x / y)
    with
    | :? System.DivideByZeroException as ex -> 
        printfn "Catched division by zero %s" ex.Message
        None
    | ex when ex.Message.Contains("Needle") -> None // use when
    | _ -> 
        printfn "Catched different exception"
        None

// it is everywhere!
let a,_,c,d = ("value of A", 42, "value of C", 999)