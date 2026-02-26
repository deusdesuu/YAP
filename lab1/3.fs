(*
Задача:
2. Создайте собственные функции для выполнения основных операций над списками (добавление/
удаление/поиск элемента, сцепка двух списков, получение элемента по номеру).

Реализация:
- функции для работы со списками
- пример работы функций
*)

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
    let list = [1; 2; 3]
    printfn "Исходный список: %A" list
    let k = 4
    printfn "Список после добавления элемента (4) в начало: %A" (AddFront(list, k))
    printfn "Список после добавления элемента (4) в конец: %A" (AddBack(list, k))
    printfn "Список после удаления элемента (i = 0): %A" (PopAt(list, 0))
    printfn "Список после удаления элемента (i = 1): %A" (PopAt(list, 1))
    printfn "Список после удаления элемента (i = 2): %A" (PopAt(list, 2))
    let list1 = [1; 2; 3; 2]
    printfn "Список для проверки поиска элемента: %A" list1
    printfn "Поиск элемента (2) в списке: %A" (Search(list1, 2))
    printfn "Список после конкатенации: %A" (Concat(list, list1))
    printfn "Элемент списка по индексу (2): %d" (GetAt(list, 2))
    0

(*
Test:
Исходный список: [1; 2; 3]
Список после добавления элемента (4) в начало: [4; 1; 2; 3]
Список после добавления элемента (4) в конец: [1; 2; 3; 4]
Список после удаления элемента (i = 0): [2; 3]
Список после удаления элемента (i = 1): [1; 3]
Список после удаления элемента (i = 2): [1; 2]
Список для проверки поиска элемента: [1; 2; 3; 2]
Поиск элемента (2) в списке: [1; 3]
Список после конкатенации: [1; 2; 3; 1; 2; 3; 2]
Элемент списка по индексу (2): 3
*)