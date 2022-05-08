module Chapter10

type BinTree<'a> =
    | Leaf of 'a
    | Node of BinTree<'a> * BinTree<'a>

let _ = Node(Node(Leaf 1, Leaf 4), Node(Leaf 6, Leaf 9))

type BinTree2<'a> =
    | Leaf2 of 'a
    | Node2 of BinTree2<'a> * 'a * BinTree2<'a>

let _ = Node2(Node2(Leaf2 1, 2, Leaf2 4), 5, Node2(Leaf2 6, 8, Leaf2 9))

let rec gcd m n = if n = 0 then m else gcd n (m % n)

let _ = gcd 15 24

let _ = gcd -8 12

let _ = gcd 18 -45

let _ = gcd -14 -15

type Op =
    | Add
    | Sub
    | Mul
    | Div

type Fraction = { Numerator: int; Denominator: int }

type Expr =
    | Val of Fraction
    | App of Expr * Op * Expr

let rec toString expr =
    match expr with
    | Val { Numerator = a; Denominator = b } ->
        if b = 1 then
            string a
        else
            $"(%d{a}/%d{b})"
    | App (left, op, right) ->
        let opStr =
            match op with
            | Add -> "+"
            | Sub -> "-"
            | Mul -> "*"
            | Div -> "/"

        $"(%s{toString left}%s{opStr}%s{toString right})"

let rec eval expr =
    match expr with
    | Val n -> Some n
    | App (left, op, right) ->
        match (eval left, eval right) with
        | (Some { Numerator = la; Denominator = lb }, Some { Numerator = ra; Denominator = rb }) ->
            match op with
            | Add ->
                let a = la * rb + lb * ra
                let b = lb * rb
                let g = gcd a b

                Some
                    { Numerator = a / g
                      Denominator = b / g }
            | Sub ->
                let a = la * rb - lb * ra
                let b = lb * rb
                let g = gcd a b

                Some
                    { Numerator = a / g
                      Denominator = b / g }
            | Mul ->
                let a = la * ra
                let b = lb * rb
                let g = gcd a b

                Some
                    { Numerator = a / g
                      Denominator = b / g }
            | Div ->
                if ra = 0 then
                    None
                else
                    let a = la * rb
                    let b = lb * ra
                    let g = gcd a b

                    Some
                        { Numerator = a / g
                          Denominator = b / g }
        | _ -> None

let rec split list =
    match list with
    | [] -> []
    | [ x ] -> []
    | x :: xs ->
        ([ x ], xs)
        :: List.map (fun (ls, rs) -> (x :: ls, rs)) (split xs)

let rec exprs list =
    match list with
    | [] -> []
    | [ x ] -> [ Val x ]
    | xs ->
        split xs
        |> List.collect (fun (ls, rs) ->
            exprs ls
            |> List.collect (fun l ->
                exprs rs
                |> List.collect (fun r ->
                    [ Add; Sub; Mul; Div ]
                    |> List.map (fun op -> App(l, op, r)))))

let rec inserts y list =
    match list with
    | [] -> [ [ y ] ]
    | x :: xs ->
        (y :: x :: xs)
        :: List.map (fun ys -> x :: ys) (inserts y xs)

let rec permutations list =
    match list with
    | [] -> [ [] ]
    | x :: xs -> List.collect (inserts x) (permutations xs)

let solve list =
    list
    |> List.map (fun n -> { Numerator = n; Denominator = 1 })
    |> permutations
    |> List.collect exprs
    |> List.filter (fun expr -> eval expr = Some { Numerator = 10; Denominator = 1 })
    |> List.map toString

let _ = solve [ 3; 4; 7; 8 ]