(*
Задача:
16. Получить для подкаталогов заданного каталога список кортежей вида
(название подкаталога, количество файлов в нем). Примечание.
Количество файлов указывается непосредственно для самого
подкаталога, исключая вложенные в него другие каталоги.
*)
open System.IO
open System


let getFiles (path: string) =
    if Directory.Exists(path) then
        Directory.GetDirectories(path)
        |> Array.map (fun dir -> 
            let fileCount = 
                Directory.GetFiles(dir)
                |> Array.length
            (Path.GetFileName(dir), fileCount))
        |> Array.toList
    else
        printfn "Каталог не существует: %s" path
        []

[<EntryPoint>]
let main _ =
    //C:\\Users\\КИТ-1\\Desktop\\YAP-main\\YAP-main\\lab3_test\\
    printfn "Введите путь в формате C:\\\\....\\\\:" 
    let pth = Console.ReadLine()
    printfn "Список подкаталогов с кол-вом файлов: %A"
        (getFiles(pth))
    0

(*
Test:
Введите путь в формате C:\\....\\:
C:\\Users\\КИТ-1\\Desktop\\YAP-main\\YAP-main\\lab3_test\\
Список подкаталогов с кол-вом файлов: [("1", 6); ("2", 5); ("3", 4); ("4", 3)]
*)
