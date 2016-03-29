let add x y = x + y
let result = add 10.0 20.0

let mujTuple = ("Vitejte", 69)
let x,y = mujTuple
let _,x = mujTuple
snd mujTuple

let basic = [1;2;45;6;4]
let generated = [0..10]
[0..10..100]
[100..-1..0]
List.rev generated

List.map (fun x -> x * 2) generated

99 :: generated

let gen =
    [
        for i in 1..10  do
            if i%2=0 then yield i
    ]


//

let normalAdd x y = x + y
let tupledAdd (x, y) = x + y

