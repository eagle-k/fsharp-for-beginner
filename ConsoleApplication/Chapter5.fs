module Chapter5

let _ = String.replicate

let _ = System.Math.PI

let circumference diameter = System.Math.PI * diameter

let circumference' = fun diameter -> System.Math.PI * diameter

let _ = circumference 10.0

type Diameter = float

let circumference'': Diameter -> float = fun diameter -> System.Math.PI * diameter

let _ = circumference'' 10.0

let circumference''' (diameter: Diameter) = System.Math.PI * diameter

type Fullname = { LastName: string; FirstName: string }

let yamada = { LastName = "山田"; FirstName = "太郎" }

let _ = yamada.LastName

let _ = yamada.FirstName

let toString person =
    person.LastName + " " + person.FirstName

let _ = toString yamada

let toString'
    { LastName = lastName
      FirstName = firstName }
    =
    lastName + " " + firstName

type Position = { X: int; Y: int }

let distance { X = x; Y = y } = abs x + abs y

let _ = distance { X = 3; Y = 4 }

let _ = distance { X = 0; Y = 0 }

type News =
    | North
    | East
    | West
    | South

let _ = North

let _ = East

let _ = West

let _ = South

let _ = North = North

let _ = North = East

let toJapaneseString news =
    match news with
    | North -> "北"
    | East -> "東"
    | West -> "西"
    | South -> "南"


let _ = toJapaneseString North

let _ = toJapaneseString West

let toString'' person =
    match person with
    | { LastName = lastName
        FirstName = firstName } -> lastName + " " + firstName

let toString''' =
    fun { LastName = lastName
          FirstName = firstName } -> lastName + " " + firstName

let toString'''' person =
    let { LastName = lastName
          FirstName = firstName } =
        person

    lastName + " " + firstName

let toJapaneseString' =
    fun news ->
        match news with
        | North -> "北"
        | East -> "東"
        | West -> "西"
        | South -> "南"

let toJapaneseString'' =
    function
    | North -> "北"
    | East -> "東"
    | West -> "西"
    | South -> "南"

type Size = { Width: float; Height: float }

type Radius = float

type Shape =
    | Rectangle of Size
    | Circle of Radius

let _ = Rectangle

let _ = Circle

let _ = Rectangle { Width = 3.0; Height = 5.0 }

let _ = Circle 5.0

let area shape =
    match shape with
    | Rectangle { Width = width; Height = height } -> width * height
    | Circle radius -> System.Math.PI * radius * radius

let _ = area (Rectangle { Width = 3.0; Height = 5.0 })

let _ = area (Circle 5.0)

let _ = 8 / 2

let _ = 7 / 2

let _ = 8 / 0

let safeDiv m n =
    if n = 0 then None
    elif m % n = 0 then Some(m / n)
    else None

let _ = safeDiv 8 2

let _ = safeDiv 7 2

let _ = safeDiv 8 0

let distance2 { X = x1; Y = y1 } { X = x2; Y = y2 } = abs (x1 - x2) + abs (y1 - y2)

let _ = distance2 { X = 3; Y = 4 } { X = 0; Y = 0 }

let _ = distance2 { X = 5; Y = -2 } { X = 3; Y = 2 }

let distance2' p1 p2 = abs (p1.X - p2.X) + abs (p1.Y - p2.Y)

let move news position =
    match news with
    | North -> { X = position.X; Y = position.Y + 1 }
    | East -> { X = position.X + 1; Y = position.Y }
    | West -> { X = position.X - 1; Y = position.Y }
    | South -> { X = position.X; Y = position.Y - 1 }

let _ = move North { X = 3; Y = 4 }

let _ = move West { X = 0; Y = 0 }

let move' news { X = x; Y = y } =
    match news with
    | North -> { X = x; Y = y + 1 }
    | East -> { X = x + 1; Y = y }
    | West -> { X = x - 1; Y = y }
    | South -> { X = x; Y = y - 1 }

let move'' news position =
    match news with
    | North -> { position with Y = position.Y + 1 }
    | East -> { position with X = position.X + 1 }
    | West -> { position with X = position.X - 1 }
    | South -> { position with Y = position.Y - 1 }

let _ =
    { X = 0; Y = 0 }
    |> move North
    |> move West
    |> move West
    |> move South

let perimeter shape =
    match shape with
    | Rectangle { Width = width; Height = height } -> 2.0 * (width + height)
    | Circle radius -> 2.0 * System.Math.PI * radius

let _ = perimeter (Rectangle { Width = 3.5; Height = 4.5 })

let _ = perimeter (Circle 5.0)

let orElse x' y' =
    match y' with
    | Some y -> Some y
    | None -> x'

let _ = Some 42 |> orElse (Some 10)

let _ = None |> orElse (Some 10)

let _ = (None: int option) |> orElse None

let flatten x'' =
    match x'' with
    | Some x' -> x'
    | None -> None

let _ = flatten (Some(Some "hello"))

let _ = flatten (Some(Some 42))

let _ = flatten (Some(None: int option))

let _ = flatten (None: int option option)