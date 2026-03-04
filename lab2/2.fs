(*
Задача:
16. Список содержит символы, обозначающие шестнадцатеричные цифры.
Получить шестнадцатеричное число из этих цифр.


Реализация:
Вход:
    - натуральное n
    - n hex цифр
    -> список
Выход:
    - hex число
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
        |exn ->
            printfn "Число должно быть натуральным!!!\n"
            InputNatural(msg)

let rec InputHexNum(msg:string) : char =
    printf "%s" msg
    let c = Console.ReadLine()[0]
    match c with
    |_ when (c >= '0' && c <= '9') -> c
    |_ when (c >= 'A' && c <= 'F') -> c
    |_ -> (InputHexNum(msg))

let Input() : list<char> =
    let n = InputNatural("Введите натуральное число n: ")
    [
        for i in [1..n] do
            yield InputHexNum(sprintf 
            "%d/%d Введите цифру в шестнадцатеричном виде: " i n)
    ]

[<EntryPoint>]
let main _ =
    let lst = Input()
    printfn "Исходный список: %A" lst
    List.fold (fun acc c -> acc + string c) "" lst
        |> printfn "Шестнадцатеричное число: %s"
    0

(*
Test:
Введите натуральное число n: 5
1/5 Введите цифру в шестнадцатеричном виде: z
1/5 Введите цифру в шестнадцатеричном виде: a
1/5 Введите цифру в шестнадцатеричном виде: a1
1/5 Введите цифру в шестнадцатеричном виде: 1
2/5 Введите цифру в шестнадцатеричном виде: F
3/5 Введите цифру в шестнадцатеричном виде: 0
4/5 Введите цифру в шестнадцатеричном виде: B
5/5 Введите цифру в шестнадцатеричном виде: 3
Исходный список: ['1'; 'F'; '0'; 'B'; '3']
Шестнадцатеричное число: 1F0B3
*)