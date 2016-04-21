let getNegatives list =
    let filtered = List.filter (fun x -> x < 0) list
    if List.length filtered > 0 then Some(filtered) 
    else None

getNegatives [1..10]
let x = getNegatives [-10..1]


x..IsNone
x.IsSome