type Person = 
    {
        Name : string
        Age : int
    }
    member x.SayYourName() = sprintf "Hi, my name %s" x.Name // method

let roman = { Name = "Roman"; Age = 34} // Ha! No record type specified
roman.Age // use '.' to access values
roman.SayYourName()

// clonning
let youngerRoman = { roman with Age = 18}
let olderRoman = {roman with Age = 99}

// pattern matching again
let explain record = 
    match record with
    | {Name = "Roman"; Age = 34}                -> "It is him!"
    | {Name = _; Age = age} when age > 80    -> "Oh man, you are old!"
    | xxx -> sprintf "I found %s %d" xxx.Name record.Age

explain roman
explain youngerRoman
explain olderRoman

let {Name = name; Age = _} = roman // pattern matching AGAIN!