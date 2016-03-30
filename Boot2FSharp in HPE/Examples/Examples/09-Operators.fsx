// pipe-forward
[1..20] 
|> List.filter (fun x -> x > 10)
|> List.map (fun x -> x + 100)
|> List.map (fun x -> sprintf "%d is in string now" x)
|> List.rev

// pipe-backward
let textFromGeneric num = sprintf "The value is %s" <| num.ToString()

textFromGeneric 42
textFromGeneric "Fourty two"
textFromGeneric ("Answer", 42)

// forward composition
let composed = 
    List.filter (fun x -> x <= 10) 
    >> List.map (fun x -> x * x)
    >> List.rev
composed [1..20]

// backward composition
let add x y = x + y
let times x y = x * y
let add1Times2 = add 1 >> times 2
add1Times2 10 // 22

let times2Add1 = add 1 << times 2
times2Add1 10 // 21 -> used backward composition

// custom operators
let (===) str regex = System.Text.RegularExpressions.Regex.Match(str, regex).Success

"abcd" === "bc" // infix notation (first param before operator)
"abcd" === "de"