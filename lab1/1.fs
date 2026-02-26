(*
Задача:
16 Сформировать список из названий дней недели.

Реализация:
Ввод: номера дней недели 1-7
Вывод: соответствующие номерам дни недели
*)
open System

let week = ["monday"; "tuesday"; "wednesday"; "thursday"; "friday"; "saturday"; "sunday"]

let InputNatural(msg) : int =
    let mutable input = false
    let mutable num = 0

    while not input do
        printf "%s" msg
        input <- 
            try
                num <- int(Console.ReadLine())
                if num <= 0 then
                    printfn "Число должно быть натуральным!!!\n"; false
                else true
            with
                |exn -> printfn "Число должно быть натуральным!!!\n"; false
    num

let Input() : string list =
    let k = InputNatural("Введите желаемое количество дней недели: ")
    let result = [
        let mutable i = 1
        while i < k + 1 do
            let num = InputNatural(sprintf "Введите день недели %d/%d: " i k)
            match num with
            | _ when num < 1 -> printfn "Номер дня должен быть в диапазоне 1-7!!!"; i <- i - 1
            | _ when num > 7 -> printfn "Номер дня должен быть в диапазоне 1-7!!!"; i <- i - 1
            | _ -> yield week[num - 1]
            i <- i + 1
    ]
    result


[<EntryPoint>]
let main _ =
    let mas = Input()
    printfn "\nРезультат работы программы:"
    for elem in mas do
        printf "%s  " elem
    0
(*
Test1:
Введите желаемое количество дней недели: asd
Число должно быть натуральным!!!

Введите желаемое количество дней недели: 5.5
Число должно быть натуральным!!!

Введите желаемое количество дней недели: -5
Число должно быть натуральным!!!

Введите желаемое количество дней недели: 5
Введите день недели 1/5: asd
Число должно быть натуральным!!!

Введите день недели 1/5: 5.5
Число должно быть натуральным!!!

Введите день недели 1/5: -5
Число должно быть натуральным!!!

Введите день недели 1/5: 0
Число должно быть натуральным!!!

Введите день недели 1/5: 8
Номер дня должен быть в диапазоне 1-7!!!
Введите день недели 1/5: 1
Введите день недели 2/5: 2
Введите день недели 3/5: 3
Введите день недели 4/5: 4
Введите день недели 5/5: 5

Результат работы программы:
monday  tuesday  wednesday  thursday  friday
*)