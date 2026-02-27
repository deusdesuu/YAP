(*
Задача:
2. Создайте собственные функции для выполнения основных операций над списками (добавление/
удаление/поиск элемента, сцепка двух списков, получение элемента по номеру).

Реализация:
- функции для работы со списками
- пример работы функций
*)
open System

let rec InputNatural(msg) : int =
    printf "%s" msg
    try
        let num = int(Console.ReadLine())
        if num <= 0 then
                printfn "Число должно быть натуральным!!!\n"
                InputNatural(msg)
        else
            num
    with
        |exn -> printfn "Число должно быть натуральным!!!\n"; InputNatural(msg)
        
let AddFront(list:list<'T>, elem:'T) : list<'T>  = 
    elem::list

let AddBack(list:list<'T>, elem:'T) : list<'T> = 
    list@[elem]

// Delete element at a certain i
let PopAt(list:list<'T>, i:int) : list<'T> =
    [
        for j in 0..(list.Length - 1) do
            if i <> j then
                yield list[j]
    ]
// Get a list of occurence indexes
let Search(list:list<'T>, elem:'T) : list<int> =
    [
        for i in 0..(list.Length - 1) do
            if list[i] = elem then
                yield i
    ]

let Concat(list1:list<'T>, list2:list<'T>) : list<'T> = 
    list1@list2

let GetAt(list:list<'T>, i:int) : 'T = 
    list[i]

[<EntryPoint>]
let main _ =
    printfn "Введите 5 натуральных чисел: "
    let list = [
        for i in 1..5 do
            yield InputNatural (sprintf "Введите натуральное число %d/%d: " i 5)
    ]
    printfn "Исходный список: %A" list
    let k = 4
    printfn "Список после добавления элемента (4) в начало: %A" (AddFront(list, k))
    printfn "Список после добавления элемента (4) в конец: %A" (AddBack(list, k))
    printfn "Список после удаления элемента (i = 0): %A" (PopAt(list, 0))
    printfn "Список после удаления элемента (i = 1): %A" (PopAt(list, 1))
    printfn "Список после удаления элемента (i = 2): %A" (PopAt(list, 2))
    printfn "Список для проверки поиска элемента: %A" list
    printfn "Поиск элемента (2) в списке: %A" (Search(list, 2))
    printfn "Список после конкатенации c самим собой: %A" (Concat(list, list))
    printfn "Элемент списка по индексу (2): %d" (GetAt(list, 2))
    0

(*
Test:
Введите 5 натуральных чисел: 
Введите натуральное число 1/5: asd
Число должно быть натуральным!!!

Введите натуральное число 1/5: 1
Введите натуральное число 2/5: 2
Введите натуральное число 3/5: 3
Введите натуральное число 4/5: 4
Введите натуральное число 5/5: 2
Исходный список: [1; 2; 3; 4; 2]
Список после добавления элемента (4) в начало: [4; 1; 2; 3; 4; 2]
Список после добавления элемента (4) в конец: [1; 2; 3; 4; 2; 4]
Список после удаления элемента (i = 0): [2; 3; 4; 2]
Список после удаления элемента (i = 1): [1; 3; 4; 2]
Список после удаления элемента (i = 2): [1; 2; 4; 2]
Список для проверки поиска элемента: [1; 2; 3; 4; 2]
Поиск элемента (2) в списке: [1; 4]
Список после конкатенации c самим собой: [1; 2; 3; 4; 2; 1; 2; 3; 4; 2]
Элемент списка по индексу (2): 3
*)
