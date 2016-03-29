// Option type
type Option<'a> = Some of 'a | None

// Tennis example
type Player = A | B
type Game =
    | Score of int * int
    | Deuce
    | Advantage of Player
    | Win of Player

let getComment game =
    match game with
    | Score(30,30)  -> sprintf "Wow, 30:30! Next ball will be important"
    | Score(x,y)    -> sprintf "Score is %d:%d" x y
    | Deuce         -> sprintf "Wow, it is deuce"
    | Advantage(x)  -> sprintf "%A has advantage" x
    | Win(x)        -> sprintf "Player %A has won" x

getComment (Game.Advantage(Player.B))

// we can add method and properties
type Transaction = 
    | Deposit 
    | Withdraw
    member this.Explain = //this can be replaced with anything
        match this with
        | Deposit -> "I am saving money to bank"       
        | Withdraw -> "I am taking money from bank"

Transaction.Deposit.Explain

// tree structure
type Tree =
    | Leaf of int
    | Node of Tree * Tree

let myTree = Tree.Node(Tree.Leaf(1), Tree.Leaf(2))

// params for union cases can be named
type Access =
    | Named of name : string * surname : string
    | Anonymous

let acc = Access.Named("Jiri", "Krupka")