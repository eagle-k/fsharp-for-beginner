module Chapter4

let add x y z = x + y + z

let _ = add 3 4 5

let _ = String.replicate 3 "abc"

let _ = String.replicate 0 "abc"

let square x = x * x

let square' = fun x -> x * x

let add' x y z = x + y + z

let add'' x y = fun z -> x + y + z

let add''' x = fun y -> (fun z -> x + y + z)

let add'''' = fun x -> (fun y -> (fun z -> x + y + z))

let _ = add 1

let _ = (add 1) 2

let _ = ((add 1) 2) 3

let isA c = c = 'a' || c = 'A'

let isA' = fun c -> c = 'a' || c = 'A'

let isA'' c = System.Char.ToUpperInvariant c = 'A'

let _ = String.forall isA "aaAAaA"

let _ = String.forall isA "abcde"

let isAllB = String.forall (fun c -> c = 'b' || c = 'B')

let isAllB' str =
    String.forall (fun c -> c = 'b' || c = 'B') str

let isB c = c = 'b' || c = 'B'

let isAllB'' str = String.forall isB str

let _ = String.filter isA "bcadAfa"

let _ = String.filter isA "aaAAaA"

let countChar x str =
    String.length (String.filter (fun c -> c = x) str)

let _ = countChar 'o' "Hello, world!"

let _ = countChar 'A' "aaAAaA"

let _ = countChar 'a' "Hello, world!"

let countChar' x str =
    str
    |> String.filter (fun c -> c = x)
    |> String.length