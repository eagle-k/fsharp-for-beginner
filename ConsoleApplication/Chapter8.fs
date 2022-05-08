module Chapter8

let displaySum m n = printfn $"%d{m} + %d{n} = %d{m + n}"

let tripleHello () =
    printfn "Hello"
    printfn "Hello"
    printfn "Hello"

let square x = x * x

let square' x =
    let y = x * x

    y

let tripleHello' () =
    do printfn "Hello"
    do printfn "Hello"
    do printfn "Hello"

    ()

let tripleHello42 () =
    do printfn "Hello"
    do printfn "Hello"
    do printfn "Hello"

    42

let tripleHello42' () =
    printfn "Hello"
    printfn "Hello"
    printfn "Hello"

    42

let tripleHello'' () =
    do printfn "Hello"
    do printfn "Hello"

    printfn "Hello"

let second () =
    stdin.ReadLine() // BAD
    stdin.ReadLine()

let second' () =
    let neverUsed = stdin.ReadLine()
    stdin.ReadLine()

let second'' () =
    let _ = stdin.ReadLine()
    stdin.ReadLine()

let second''' () =
    stdin.ReadLine() |> ignore
    stdin.ReadLine()

let second'''' () =
    do stdin.ReadLine() |> ignore
    stdin.ReadLine()

let printIfLessThan10 n = if n < 10 then printfn $"%d{n}" else ()

let printIfLessThan10' n = if n < 10 then printfn $"%d{n}"

let printIfSome n' =
    match n' with
    | Some n -> printfn $"%d{n}"
    | None -> ()

let displayFile () =
    System.IO.File.ReadAllText(@"C:\text\myfile.txt", System.Text.Encoding.UTF8)
    |> printfn "%s"

let tryParseInt (s: string) =
    let (success, result) = System.Int32.TryParse s
    if success then Some result else None

let program1 () =
    let input = stdin.ReadLine()

    match tryParseInt input with
    | Some n -> printfn $"%d{n} の二乗は %d{n * n} です。"
    | None -> printfn $"%s{input} は数字ではありません。"

let program2 () =
    printf "数字を入力してください > "
    let input = stdin.ReadLine()

    match tryParseInt input with
    | Some n -> printfn $"%d{n} の二乗は %d{n * n} です。"
    | None -> printfn $"%s{input} は数字ではありません。"

let rec program3 () =
    printf "数字を入力してください > "
    let input = stdin.ReadLine()

    match tryParseInt input with
    | Some n -> printfn $"%d{n} の二乗は %d{n * n} です。"
    | None ->
        printfn $"%s{input} は数字ではありません。"
        printfn ""
        program3 ()