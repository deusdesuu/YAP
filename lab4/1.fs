(*
Задача:
16 Дерево содержит целые числа. Удалить старший разряд в каждом числе.

Реализация:
    - получаем натуральное n
    - строим дерево из случайных значений
    - применяем рекурсивную самописную ф-ию mapTree (*)
    - выводим результат работы mapTree

(*):
    - рекурсивно обходим дерево в глубину
    - применяем к каждому value ф-ию (в данном случае numMap(**))

(**):
    - вычисляем log от модуля числа (целая часть - кол-во цифр)
    - берем остаток от деления на 10**log
*)

open System


let rec inputNatural(msg) : int =
    printf "%s" msg
    try
        let num = int(Console.ReadLine())
        if num <= 0 then
                printfn "Число должно быть натуральным!!!\n"
                inputNatural(msg)
        else
            num
    with
        |exn ->
            printfn "Число должно быть натуральным!!!\n"
            inputNatural(msg)


type 't BTree =
    | Node of 't * 't BTree * 't BTree
    | Leaf
    

let rec insertValue (tree: 't BTree) (n: 't) : 't BTree =
        match tree with
        | Leaf
             -> Node(n, Leaf, Leaf)
        | Node(data, left, right)
            -> if (n < data) then
                   Node(data, insertValue left n, right)
               elif (n > data) then
                   Node(data, left, insertValue right n)
               else
                   Node(data, left, right)


let rec printTreeIn(tree: 't BTree, t: int) : unit =
    match tree with
    | Node(data, left, right)
        -> for _ in 1..t do
               printf "\t"
           printf "%d\n" data
           printTreeIn(left, t + 1)
           printTreeIn(right, t + 1)
    | Leaf
        -> ()


let printTree(tree: 't BTree) : unit =
    printTreeIn(tree, 0)
    printfn ""


let rec treeMap (func: 't -> 't) (node: 't BTree) : 't BTree =
    match node with
    | Leaf -> Leaf
    | Node(data, left, right)
        -> Node(func data, treeMap func left, treeMap func right)

let numMap (x: int): int =
    match x with
    | _ when Math.Abs(x) <= 10
        -> 0
    | _ when x < 0
        -> -(-x % Convert.ToInt32(10.0 ** Math.Floor(
            Math.Log(Convert.ToDouble(Math.Abs(x)), 10.0))))
    | _ when x > 0
        -> x % Convert.ToInt32(10.0 ** Math.Floor(
            Math.Log(Convert.ToDouble(Math.Abs(x)), 10.0)))


[<EntryPoint>]
let main _ =
    let n = inputNatural("Введите количество чисел: ")
    let rnd = System.Random()
    let sequence = seq{
        for _ in 1..n do
            yield rnd.Next(-150, 150)
    }
    let tree = sequence |> Seq.fold insertValue Leaf
    printfn "\nИсходное дерево:"
    printTree(tree)

    let newtree = treeMap numMap tree
    printfn "Дерево после Map:"
    printTree(newtree)

    0

(*
Test:
Введите количество чисел: 5

Исходное дерево:
-41
        -146
                -122
        129
                52

Дерево после Map:
-1
        -46
                -22
        29
                2

*)
