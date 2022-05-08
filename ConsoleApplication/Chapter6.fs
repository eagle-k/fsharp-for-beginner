module Chapter6

let _ = [ 1; 2; 3; 4; 5 ]

let _ = 1 :: [ 2; 3; 4; 5 ]

let _ = 1 :: (2 :: [ 3; 4; 5 ])

let _ = 1 :: (2 :: (3 :: [ 4; 5 ]))

let _ = 1 :: (2 :: (3 :: (4 :: [ 5 ])))

let _ = 1 :: (2 :: (3 :: (4 :: (5 :: []))))

let _ = 1 :: 2 :: 3 :: 4 :: 5 :: []

let isEmpty list =
    match list with
    | [] -> true
    | x :: xs -> false

let _ = isEmpty []

let _ = isEmpty [ 1; 2; 3; 4; 5 ]

let skipOne list =
    match list with
    | [] -> []
    | x :: xs -> xs

let _ = skipOne [ 1; 2; 3; 4; 5 ]

let _ = skipOne [ 5 ]

let _ = skipOne ([]: int list)

type IntList =
    | Empty
    | NotEmpty of NotEmptyList

and NotEmptyList = { Head: int; Tail: IntList }

let _ = Empty

let _ = NotEmpty { Head = 0; Tail = Empty }

let _ = NotEmpty { Head = 1; Tail = Empty }

let _ =
    NotEmpty
        { Head = 5
          Tail = NotEmpty { Head = 0; Tail = Empty } }

let isEmpty2 list =
    match list with
    | Empty -> true
    | NotEmpty { Head = head; Tail = tail } -> false

let skipOne2 list =
    match list with
    | Empty -> Empty
    | NotEmpty { Head = head; Tail = tail } -> tail

let rec zeros n =
    if n <= 0 then
        Empty
    else
        NotEmpty { Head = 0; Tail = zeros (n - 1) }

let _ = zeros 0

let _ = zeros 1

let _ = zeros 5

let rec countdown n =
    if n <= 0 then
        Empty
    else
        NotEmpty { Head = n; Tail = countdown (n - 1) }

let _ = countdown 1

let _ = countdown 3

let rec standard list =
    match list with
    | Empty -> []
    | NotEmpty { Head = head; Tail = tail } -> head :: standard tail

let _ = standard (zeros 5)

let _ = standard (countdown 5)

let rec sum list =
    match list with
    | [] -> 0
    | x :: xs -> x + sum xs

let rec foldRight f list empty =
    match list with
    | [] -> empty
    | x :: xs -> f x (foldRight f xs empty)

let sum' list = foldRight (fun x y -> x + y) list 0

let _ = 2 + 3

let _ = (+) 2 3

let _ = (+) 5

let sum'' list = foldRight (+) list 0

let _ = List.foldBack (+) [ 1; 3; 4; 7 ] 0

let _ = List.foldBack (-) [ 1; 3; 4; 7 ] 0

let rec sumLeft acc list =
    match list with
    | [] -> acc
    | x :: xs -> sumLeft (acc + x) xs

let rec foldLeft f acc list =
    match list with
    | [] -> acc
    | x :: xs -> foldLeft f (f acc x) xs

let _ = foldLeft (+) 0 [ 1; 3; 4; 7 ]

let _ = List.fold (+) 0 [ 1; 3; 4; 7 ]

let _ = List.fold (-) 0 [ 1; 3; 4; 7 ]

let _ = List.sum [ 1; 3; 4; 7 ]

let _ = List.sum ([]: int list)

let _ = List.replicate 5 "hello"

let _ = List.replicate 10 0

let _ = sum (List.replicate 100000 0)

let _ = sumLeft 0 (List.replicate 100000 0)

let _ = List.fold (+) 0 (List.replicate 100000 0)

let _ = List.foldBack (+) (List.replicate 100000 0) 0

let rec product list =
    match list with
    | [] -> 1
    | x :: xs -> x * product xs

let product' list =
    List.foldBack (fun x acc -> x * acc) list 1

let _ = product' (List.replicate 100000 1)

let rec productTR acc ys =
    match ys with
    | [] -> acc
    | x :: xs -> productTR (acc * x) xs

let _ = productTR 1 [ 3; 5 ]

let _ = productTR 1 [ 2; 3; 5; 2 ]

let _ = productTR 1 (List.replicate 100000 1)

let product'' list =
    let rec productTR acc ys =
        match ys with
        | [] -> acc
        | x :: xs -> productTR (acc * x) xs

    productTR 1 list

let rec length list =
    match list with
    | [] -> 0
    | x :: xs -> 1 + length xs

let length' list =
    List.foldBack (fun x acc -> 1 + acc) list 0

let length'' list =
    let rec lengthTR acc ys =
        match ys with
        | [] -> acc
        | x :: xs -> lengthTR (acc + 1) xs

    lengthTR 0 list

let rec forall predicate list =
    match list with
    | [] -> true
    | x :: xs -> predicate x && forall predicate xs

let _ = forall (fun n -> n % 3 = 0) [ 3; 12; 9 ]

let _ = forall (fun n -> n % 3 = 0) [ 1; 3; 4; 7 ]

let _ = forall (fun n -> n = 42) (List.replicate 100000 42)

let forall' predicate list =
    let rec forallTR acc ys =
        match ys with
        | [] -> acc
        | x :: xs -> forallTR (acc && predicate x) xs

    forallTR true list

let forall'' predicate list =
    let rec forallTR acc ys =
        match ys with
        | [] -> acc
        | x :: xs ->
            let result = predicate x

            if result then
                forallTR (acc && result) xs
            else
                false

    forallTR true list

let rev list =
    let rec revTR acc ys =
        match ys with
        | [] -> acc
        | x :: xs -> revTR (x :: acc) xs

    revTR [] list

let _ = rev [ 1; 3; 4; 7 ]

let _ = rev [ "Apple"; "Banana"; "Cherry" ]

let rev' list =
    List.fold (fun acc x -> x :: acc) [] list

let foldRight' f list empty =
    List.fold (fun acc x -> f x acc) empty (List.rev list)

let rec append list1 list2 =
    match list1 with
    | [] -> list2
    | x :: xs -> x :: append xs list2

let _ = append [ 1; 2; 3 ] [ 10; 20; 30 ]

let append' list1 list2 =
    List.foldBack (fun x acc -> x :: acc) list2 list1

let _ = [ 1; 2; 3 ] @ [ 10; 20; 30 ]

let _ = [ 1; 2; 3 ] |> List.append [ 10; 20; 30 ]

let _ = [ 1; 2; 3 ] @ [ 4 ]

let _ = 1 :: [ 2; 3; 4 ]

let rec concat lists =
    match lists with
    | [] -> []
    | xs :: xss -> xs @ concat xss

let _ =
    concat [ [ 1; 2 ]
             []
             [ 10; 20; 30 ]
             [ 100 ] ]

let _ =
    concat [ [ 'a'; 'b'; 'c' ]
             [ 'D'; 'E' ] ]

let concat' lists = List.foldBack (@) lists []

let rec tryFind predicate list =
    match list with
    | [] -> None
    | x :: xs ->
        if predicate x then
            Some x
        else
            tryFind predicate xs

let _ = tryFind (fun n -> n % 3 = 0) [ 1; 3; 6; 10 ]

let _ = tryFind (fun n -> n % 3 = 0) [ 1; 4; 7; 10 ]

let rec payment coins n =
    if n < 0 then
        false
    elif n = 0 then
        true
    else
        match coins with
        | [] -> false
        | x :: xs -> payment xs (n - x) || payment xs n

let _ = payment [ 10; 10; 50; 100; 100 ] 170

let _ = payment [ 10; 10; 50; 100; 100 ] 130

let paymentCoins initCoins initN =
    let rec payment answer coins n =
        if n < 0 then
            None
        elif n = 0 then
            Some answer
        else
            match coins with
            | [] -> None
            | x :: xs ->
                payment (x :: answer) xs (n - x)
                |> Option.orElse (payment answer xs n)

    payment [] initCoins initN

let _ = paymentCoins [ 10; 10; 50; 100; 100 ] 170

let _ = paymentCoins [ 10; 10; 50; 100; 100 ] 130