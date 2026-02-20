open System
(*
//Сформировать список из названий дней недели
//что-то придумать со списком
//например через ввод номеров дней недели 1 3 2 1 -> пн, ср, вт, пн
let MakeAWeek : string list =
    let week = ["monday"; "tuesday"; "wednesday"; "thursday"; "friday"; "saturday"; "sunday"]
    week
   
[<EntryPoint>]
let main argv =
    let week = MakeAWeek
    for day in week do
        printf "%s  " day
    0
*)
(*
//Возвратить true, если в числе есть цифра k, и false — в противном случае
let rec CheckNum num k: bool =
    if ((num % 10 = k)) then
        true
    elif (num / 10 = 0) then
        false
    else
        CheckNum (num / 10) k

let InputHandle : int*int =
    printf "Введите целое число n: "
    let num = int(Console.ReadLine())
    printf "Введите цифру k: "
    let k = int(Console.ReadLine())
    
    let num =
        if num < 0 then
            -num
        else
            num
    
    if ((k < 0) || (k > 9)) then
        raise (System.ArgumentException("k должна быть цифрой от 1 до 9!!!"))
    
    (num, k)

[<EntryPoint>]
let main argv =
    let num, k = InputHandle
    if (CheckNum num k) then
        printfn "Цифра k есть в данном числе!"
    else
        printfn "Цифры k нет в данном числе"
    0
*)
