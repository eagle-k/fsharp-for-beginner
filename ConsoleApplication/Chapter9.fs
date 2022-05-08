module Chapter9

let _ = [| 1; 2; 3 |]

let _ = "apple,banana,cherry".Split [| ',' |]

let _ = "Hello, world!" |> Seq.toList

let _ = "Hello, world!" |> Set.ofSeq

let _ = "Hello, world!" |> Set.ofSeq |> Set.count

let _ = Set.union (Set.ofList [ 1; 2; 3 ]) (Set.ofList [ 2; 6 ])

let _ = Set.intersect (Set.ofList [ 1; 2; 3 ]) (Set.ofList [ 2; 6 ])

let fruits =
    Map.ofList [ (1, "Apple")
                 (2, "Banana")
                 (3, "Cherry") ]

let _ = fruits |> Map.tryFind 2

let _ = fruits |> Map.tryFind 4

let _ = [ 1..5 ]

let _ = [| 1..5 |]

let _ = seq { 1..5 }

let _ = set { 1..5 }

let _ = [ 1..2..10 ]

let _ = [ 5..-1..0 ]

let _ = [ 3..100..203 ]

let chars = [ 'a' .. 'z' ]

let _ = chars[3..5]

let _ = chars[8]

let _ = chars[20..]

let _ = chars[..3]

let _ =
    [ for n in [ 1..5 ] do
          yield n * n ]

let _ =
    [ for n in [ 1..5 ] do
          let x = n * n
          yield x ]

let _ =
    [ for n in [ 1..5 ] do
          let x = n * n
          if x < 10 then yield x else yield n ]

let _ =
    [ for n in [ 1..5 ] do
          let x = n * n
          if x < 10 then yield x else () ]

let _ =
    [ for n in [ 1..5 ] do
          let x = n * n
          if x < 10 then yield x ]

let _ =
    [ for n in [ 1..5 ] do
          yield n * n ]

let _ = [ for n in [ 1..5 ] -> n * n ]

let _ = [| for n in [ 1..5 ] -> n * n |]

let _ = seq { for n in [ 1..5 ] -> n * n }

let concat xss =
    [ for xs in xss do
          for x in xs do
              yield x ]

let _ =
    concat [ [ 1; 2 ]
             []
             [ 10; 20; 30 ]
             [ 100 ] ]

let _ =
    concat [ [ 'a'; 'b'; 'c' ]
             [ 'D'; 'E' ] ]

let _ =
    concat [ seq { 1..5 }
             seq { 10..10..50 } ]

let _ =
    concat [ [| "Apple"; "Banana" |]
             [| "Cherry" |] ]

let _ = [| 1..123456789 |]

let _ = seq { 1..123456789 }

let _ = seq { 1..1234567890 }

let _ = seq { 1..123456789 } |> Seq.toArray

let _ = seq { 1..123456789 } |> Seq.take 10 |> Seq.toArray

let _ =
    seq { 1..123456789 }
    |> Seq.toArray
    |> Array.take 10

let _ = System.Int32.MaxValue

let fizzbuzz =
    seq {
        for n in seq { 1 .. System.Int32.MaxValue } do
            if n % 3 = 0 || n % 5 = 0 then yield n
    }

let _ = fizzbuzz |> Seq.take 20 |> Seq.toList

let _ =
    fizzbuzz
    |> Seq.skip 5
    |> Seq.take 10
    |> Seq.toList

let _ =
    fizzbuzz
    |> Seq.takeWhile (fun n -> n < 50)
    |> Seq.toList

let _ =
    fizzbuzz
    |> Seq.skipWhile (fun n -> n < 20)
    |> Seq.takeWhile (fun n -> n < 50)
    |> Seq.toList

let _ = [ 1..5 ] |> List.map (fun n -> n * n)

let _ = [| 1..5 |] |> Array.map (fun n -> n * n)

let _ = seq { 1..5 } |> Seq.map (fun n -> n * n)

let _ = [ 1..5 ] |> Seq.map (fun n -> n * n)

let _ = [| 1..5 |] |> Seq.map (fun n -> n * n)

let _ = [ 1..5 ] |> List.filter (fun n -> n % 2 = 0)

let _ = [| 1..5 |] |> Array.filter (fun n -> n % 2 = 0)

let _ = seq { 1..5 } |> Seq.filter (fun n -> n % 2 = 0)

let _ = [ 1..5 ] |> Seq.filter (fun n -> n % 2 = 0)

let _ = [| 1..5 |] |> Seq.filter (fun n -> n % 2 = 0)

let _ = Some 42 |> Option.map (fun n -> n / 2)

let _ = None |> Option.map (fun n -> n / 2)

let _ = Some 42 |> Option.filter (fun n -> n % 2 = 0)

let _ = Some 42 |> Option.filter (fun n -> n % 2 = 1)

let _ = None |> Option.filter (fun n -> n % 2 = 0)

let _ =
    [ 1..5 ]
    |> List.map (fun n -> n * n)
    |> List.filter (fun x -> x < 10)

let _ = List.collect Seq.toList [ "hello"; "world" ]

let _ = List.collect (fun n -> [ 1..n ]) [ 1..5 ]

let _ =
    [ for x in [ 1..10 ] do
          for y in [ x..10 ] do
              if x + y < 15 then yield (x, y) ]

let _ =
    [ 1..10 ]
    |> List.collect (fun x ->
        [ x..10 ]
        |> List.filter (fun y -> x + y < 15)
        |> List.map (fun y -> (x, y)))

let _ =
    [ for a in [ 1..100 ] do
          for b in [ 1..100 ] do
              for c in [ 1..100 ] do
                  if a * a + b * b = c * c then
                      yield (a, b, c) ]
    |> List.length

let _ =
    [ 1..100 ]
    |> List.collect (fun a ->
        [ 1..100 ]
        |> List.collect (fun b ->
            [ 1..100 ]
            |> List.filter (fun c -> a * a + b * b = c * c)
            |> List.map (fun c -> (a, b, c))))
    |> List.length