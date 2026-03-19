(*
Задача:
16 Дерево содержит строки. Указать узел с максимальным вхождением заданного
символа.

Реализация:
    - формируем дерево из случайных строк
    - строки длины 3-7 из "abcdef" (для упрощения проверки)
    - получаем символ c, который будем искать и считать
    - обходом в глубину ищем максимальное кол-во символов c в одном слове
    - при помощи fold формируем результирующий список
        где все строки содержат максимальное кол-во символов с
*)

open System


let rnd = System.Random()


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


let rec printTreeIn(tree: 't BTree) : unit =
    match tree with
    | Node(data, left, right)
        -> printTreeIn(left)
           printf "%s " data
           printTreeIn(right)
    | Leaf
        -> ()


let printTree(tree: 't BTree) : unit =
    printTreeIn(tree)
    printfn ""


let rndStr(n: int) : string =
    let chars = "abcdef"
    seq{
        for _ in 1..n do
            yield chars[rnd.Next(0, 5)]
    } |> Seq.fold (fun str c -> str + string c) ""


let rec treeFold (func: 'a->'s->'a, acc: 'a, node: 's BTree): 'a=
    match node with
    | Leaf -> acc
    | Node(data, left, right) ->
        let l = treeFold(func, acc, left)
        let acc = func l data
        treeFold(func, acc, right)



let rec readChar(msg: string): char =
    printf "%s" msg
    let to_check = "abcdef"
    let c = Console.ReadLine()[0]
    if to_check.Contains(c) then
        c
    else
        printfn "Символ должен быть в диапазоне a-f!!!\n"
        readChar(msg)


let rec findMax(
    to_find: char,
    node: 't BTree
) : int =
    match node with
    | Leaf -> 0
    | Node(data, left, right) ->
        let check_l = findMax(to_find, left)
        let check_r = findMax(to_find, right)
        let cur_count = 
            data 
            |> Seq.filter ((=) to_find) 
            |> Seq.length
        List.max([check_l; check_r; cur_count])


[<EntryPoint>]
let main _ =
    let n = inputNatural("Введите количество строк: ")
    let strings = seq{
        for _ in 1..n do
            yield rndStr(rnd.Next(3, 7))
    }

    let tree = strings |> Seq.fold insertValue Leaf
    printfn "\nИсходное дерево:"
    printTree(tree)

    let c = readChar("\nВведите символ a-f: ")
    let max = findMax(c, tree)

    printfn "Максимальное кол-во символов '%c' в строке: %d" c max
    
    let foldFunc acc item =
        if item 
           |> Seq.filter ((=) c)
           |> Seq.length = max then
            acc @ [item]
        else
            acc

    let res = treeFold (foldFunc, [], tree)
    printfn "Список искомых строк: %A" res

    0

(*
Test 1:
Введите количество строк: 5

Исходное дерево:
bbacc bbca caeeca ccb dccd

Введите символ a-f: b
Максимальное кол-во символов 'b' в строке: 2
Список искомых строк: ["bbacc"; "bbca"]


Test 2:
Введите количество строк: 5

Исходное дерево:
aaac bceea caa cca eda

Введите символ a-f: f
Максимальное кол-во символов 'f' в строке: 0
Список искомых строк: ["aaac"; "bceea"; "caa"; "cca"; "eda"]
*)