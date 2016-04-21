// comments
let add x y = x + y // HA! No types!
let result = add 10.0 20.0
let lambdaAdd = fun a b -> a + b

// space vs tuples
let normalAdd x y = x + y
let tupledAdd (x,y) = x + y

// automatic generic
let autogeneric x = x

let outerFunc x =
    let innerFunc y = x * 2 // sub function
    let innerFunc y = x / 2
    innerFunc x // last statement

outerFunc 10 // second innerFunc used

innerFunc // OOPS! not visible

// shadowing not allowed
let greeting = "Ahoj"
let greeting = "Cau"