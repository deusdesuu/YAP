(*
Задача:
16. На основе списка, содержащего двоичные значения цифр от 1 до 9, получить их
десятичные представления

Реализация:
- на вход кол-во элементов n, элементы формата 1-1001
- на выход список элементов 1-9
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

let rec InputBinNum(msg:string) : string =
    printf "%s" msg
    let str = Console.ReadLine()
    
    if not (str |> Seq.forall (fun c -> c = '0' || c = '1')) then
        printf "%s не является бинарным числом\n" str
        InputBinNum(msg)
    else
        if (0 < Convert.ToInt32(str, 2) && 
            Convert.ToInt32(str, 2) < 10) then
                str.TrimStart('0')
        else
            printf "%s не является цифрой 1-9\n" str
            InputBinNum(msg)

let Input() : list<string> =
    let n = InputNatural("Введите натуральное число n: ")
    [
        for i in [1..n] do
            yield InputBinNum(sprintf 
            "%d/%d Введите цифру 1..9 в двоичном виде: " i n)
    ]

[<EntryPoint>]
let main _ =
    let lst = Input()
    printfn "Исходный список: %A" lst
    List.map (fun s -> Convert.ToInt32(s, 2)) lst |>
        printfn "Список после List.map: %A"
    0

(*
Test:
Введите натуральное число n: 5
1/5 Введите цифру 1..9 в двоичном виде: asd
asd не является бинарным числом
1/5 Введите цифру 1..9 в двоичном виде: 123
123 не является бинарным числом
1/5 Введите цифру 1..9 в двоичном виде: 000
000 не является цифрой 1-9
1/5 Введите цифру 1..9 в двоичном виде: 1010
1010 не является цифрой 1-9
1/5 Введите цифру 1..9 в двоичном виде: 00001
2/5 Введите цифру 1..9 в двоичном виде: 1001
3/5 Введите цифру 1..9 в двоичном виде: 100
4/5 Введите цифру 1..9 в двоичном виде: 10
5/5 Введите цифру 1..9 в двоичном виде: 101
Исходный список: ["1"; "1001"; "100"; "10"; "101"]
Список после List.map: [1; 9; 4; 2; 5]
*)