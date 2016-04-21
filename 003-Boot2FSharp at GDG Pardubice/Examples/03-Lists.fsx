let basic = [0;1;2;3;4;5]
let good = [0..10]
let better = [0..10..100]
let down = [100..-10..0]

List.length better // 11 elements
List.rev better

let greetings = ["Ahoj"; "Cau"; "Nazdar"]
List. (fun x -> sprintf "%s kamarade" x) greetings

Seq.

let list2 = ["Hi"; "Hello"]
list2 @ greetings // join lists

"xxx" :: list2 // prepend to list

// list comprehension
let generatedEvens = 
    [
        for i in 1..10 do 
            if i%2=0 then yield i
    ]

let differentGen = [ for i = 0 to 10 do yield i]
