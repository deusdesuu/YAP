(*
Задача:
16. На основе списка, содержащего двоичные значения цифр от 1 до 9, получить их
десятичные представления

Реализация:
- на вход кол-во элементов n, элементы формата 1-1001
- на выход список элементов 1-9

* Решить с использованием Seq
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

let Input() : seq<string> =
    let n = InputNatural("Введите натуральное число n: ")
    seq {
        for i in 1..n do
            yield InputBinNum(sprintf 
            "%d/%d Введите цифру 1..9 в двоичном виде: " i n)
    }

[<EntryPoint>]
let main _ =
    let sequence = Input()

    Seq.map (fun s -> Convert.ToInt32(s, 2)) sequence
       |> Seq.toList
       |> printfn "Множество после Seq.map: %A"
    0

(*
Test:
Введите натуральное число n: 5
1/5 Введите цифру 1..9 в двоичном виде: 1
2/5 Введите цифру 1..9 в двоичном виде: 10
3/5 Введите цифру 1..9 в двоичном виде: 100
4/5 Введите цифру 1..9 в двоичном виде: 1000
5/5 Введите цифру 1..9 в двоичном виде: 101
Множество после Seq.map: [1; 2; 4; 8; 5]
*)