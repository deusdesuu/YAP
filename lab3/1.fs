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

let rec inputBinNum(msg:string) : string =
    printf "%s" msg
    let str = Console.ReadLine()
    
    if not (str |> Seq.forall (fun c -> c = '0' || c = '1')) then
        printf "%s не является бинарным числом\n" str
        inputBinNum(msg)
    else
        if (0 < Convert.ToInt32(str, 2) && 
            Convert.ToInt32(str, 2) < 10) then
                str.TrimStart('0')
        else
            printf "%s не является цифрой 1-9\n" str
            inputBinNum(msg)

let input() : seq<string> =
    let n = inputNatural("Введите натуральное число n: ")
    seq {
        for i in 1..n do
            yield inputBinNum(sprintf 
            "%d/%d Введите цифру 1..9 в двоичном виде: " i n)
    }

[<EntryPoint>]
let main _ =
    let sequence = input()

    Seq.map (fun s -> printf "%s " s; Convert.ToInt32(s, 2)) sequence
    |> Seq.iter (printfn "-> %A ")
    0

(*
Test:
Введите натуральное число n: 5
1/5 Введите цифру 1..9 в двоичном виде: 1
1 -> 1 
2/5 Введите цифру 1..9 в двоичном виде: 10
10 -> 2 
3/5 Введите цифру 1..9 в двоичном виде: 100
100 -> 4 
4/5 Введите цифру 1..9 в двоичном виде: 1000
1000 -> 8
5/5 Введите цифру 1..9 в двоичном виде: 101
101 -> 5

*)
