module Chapter2

let functionalSum xs =
    let rec loop acc list =
        match list with
        | [] -> acc
        | head :: tail -> loop (acc + head) tail

    loop 0 xs

let imperativeSum (xs: int list) =
    let mutable total = 0

    for x in xs do
        total <- total + x

    total