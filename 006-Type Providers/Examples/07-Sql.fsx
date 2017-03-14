#r "packages/SQLProvider/lib/FSharp.Data.SqlProvider.dll"

open FSharp.Data.Sql
open System

[<Literal>]
let connectionString = 
    @"Data Source=.;Initial Catalog=FSharping;Integrated Security=True"

type Sql = SqlDataProvider<
            ConnectionString = connectionString ,
            DatabaseVendor = Common.DatabaseProviderTypes.MSSQLSERVER,
            UseOptionTypes= true>
            

// query for items
query {
    for user in Sql.GetDataContext().Dbo.Users do
    where (user.Age.IsSome && user.Age.Value >= 35)
    select user
} |> Seq.toList

// update item
let ctx = Sql.GetDataContext()
let user = 
    query {
        for user in ctx.Dbo.Users do
        where (user.Id = Guid("ab43bac6-004d-4601-9315-a4325715c13d"))
        select user
    } |> Seq.head

user.Name <- "Romicek" // MUTABLE!
ctx.SubmitUpdates()
/// WHY IT FAILS - GOTCHA #1 - CONTEXT????


/// GOTCHA #2 - DO NOT UPDATE PRIMARY KEY (EVEN NOT WITH SAME VALUE)

// create new order
let createOrder userId =
    let ctx = Sql.GetDataContext()
    let newOrder = ctx.Dbo.Orders.Create()
    newOrder.Id <- Guid.NewGuid()
    newOrder.Amount <- 20
    newOrder.Item <- "Vidle"
    newOrder.UserId <- userId
    ctx.SubmitUpdates()

Guid("ab43bac6-004d-4601-9315-a4325715c13d") |> createOrder

// query by foreign key
let ctx = Sql.GetDataContext()
query {
    for user in ctx.Dbo.Users do
    //join order in ctx.Dbo.Orders on (user.Id = order.UserId)
    for order in user.``dbo.Orders by Id`` do
    select (user.Surname, order.Item, order.Amount)
} |> Seq.toList


/// U CAN USE MAPPING FUNCS
let mappingFunc (user:Sql.dataContext.``dbo.UsersEntity``) =
    user.Name

query {
    for user in Sql.GetDataContext().Dbo.Users do
    select user
} 
|> Seq.map mappingFunc
|> Seq.toList

/// GOTCHA #3 - IF FOREIGN KEY IS NULLABLE, USE (!!)

query {
    for user in Sql.GetDataContext().Dbo.Users do
    for manager in (!!) user.``dbo.Users by Id_1`` do
    select (user.Name, manager.Name)
} |> Seq.toList