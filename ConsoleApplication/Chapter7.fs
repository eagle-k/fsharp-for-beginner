module Chapter7

let _ = 3, 5

let _ = 7, 3, 1, 1

let _ = 8, "hello", true

let _ = (3, 5)

let _ = (7, 3, 1, 1)

let _ = (8, "hello", true)

let _ = [ 1, 2, 3 ]

let _ = [ 1; 2; 3 ]

let keyMatches key p =
    match p with
    | (k, v) -> k = key

let _ = keyMatches 3 (1, "hello")

let _ = keyMatches 1 (1, "hello")

let keyMatches' key (k, v) = k = key

let keyMatches'' key p =
    let (k, v) = p
    k = key

let keyMatches''' key = fun (k, v) -> k = key

let _ = (1, "hello")

let _ = [ 1; 2 ]

let _ = [ 1; 2; 3 ]

let _ = (1, 2)

let _ = (1, 2, 3)

let _ = []

let _ = [ 42 ]

let _ = ()

let _ = "abcde".PadLeft(10, '*')

let _ = "abcde".ToUpperInvariant()

let parseInt (s: string) =
    let (success, n) = System.Int32.TryParse s

    if success then
        string (n * 2)
    else
        "数字を入力してください。"

let _ = parseInt "1234"

let _ = parseInt "abcde"

let _ = List.pairwise [ 1; 3; 4; 7 ]

let _ = List.partition (fun n -> n % 3 = 0) [ 1; 2; 3; 4; 5; 6; 7 ]

let _ =
    List.zip [ 1; 2; 3 ] [
        "one"
        "two"
        "three"
    ]

let _ =
    List.zip [ 1; 2; 3; 4 ] [
        "one"
        "two"
        "three"
    ]

let _ =
    List.unzip [ (1, "one")
                 (2, "two")
                 (3, "three") ]

let _ = List.groupBy (fun n -> n % 3) [ 1; 2; 3; 4; 5; 6; 7 ]

let _ = List.groupBy String.length [ "Apple"; "Banana"; "Cherry" ]

let isSorted list =
    list
    |> List.pairwise
    |> List.forall (fun (a, b) -> a <= b)

let _ = isSorted [ 1; 3; 4; 7 ]

let _ = isSorted [ 3; 8; 7; 13 ]

let _ = isSorted [ 1; 4; 4; 4 ]

let rec isSorted' list =
    match list with
    | [] -> true
    | x :: [] -> true
    | a :: b :: xs ->
        if a <= b then
            isSorted' (b :: xs)
        else
            false

let rec isSorted'' list =
    match list with
    | [] -> true
    | [ _ ] -> true
    | a :: b :: xs when a <= b -> isSorted'' (b :: xs)
    | _ -> false

let rec insert y list =
    match list with
    | [] -> [ y ]
    | x :: xs ->
        if y < x then
            y :: x :: xs
        else
            x :: insert y xs

let _ = insert 6 [ 1; 3; 4; 7 ]

let rec sort list =
    match list with
    | [] -> []
    | x :: xs -> insert x (sort xs)

let _ = sort [ 3; 1; 6; 8; 3; 2 ]

let rec sort' list =
    match list with
    | [] -> []
    | head :: tail ->
        let (smaller, equalOrLarger) = List.partition (fun x -> x < head) tail
        sort' smaller @ [ head ] @ sort' equalOrLarger

let tryParseInt (s: string) =
    let (success, result) = System.Int32.TryParse s
    if success then Some result else None

let _ = tryParseInt "100"

let _ = tryParseInt "-42"

let _ = tryParseInt "hello"

let _ = tryParseInt "12345678901234567890"

let _ = List.tryHead [ 3; 5; 7 ]

let _ = List.tryHead ([]: int list)