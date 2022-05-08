module Chapter3

let _ = 42

let _ = 1 + 2 * 3

let _ = 4.2

let _ = 7.0 + 4.2

let _ = 10 / 3

let _ = -10 / 3

let _ = 10.0 / 3.0

let _ = -10.0 / -3.0

let _ = floor 3.5

let _ = round 3.4

let _ = round 3.5

let _ = ceil 3.5

let _ = floor -3.5

let _ = round -3.4

let _ = round -3.5

let _ = ceil -3.5

let _ = round 3.5

let _ = round 4.5

let _ = "Hello, world!"

let _ = 'A'

let _ = "A"

let _ = "abc" + "def"

let _ = "abcde"[0]

let _ = "abcde"[3]

let _ = "abcde"[5]

let _ = "abcde"[0..3]

let _ = "abcde"[3..4]

let _ = "😀"

let _ = "あ😀お"[0]

let _ = "あ😀お"[1..2]

let _ = "あ😀お"[3]

let _ = true

let _ = false

let _ = not true

let _ = not false

let _ = 2 + 3 = 5

let _ = 2 + 3 = 8

let _ = 2 + 3 <> 5

let _ = 2 + 3 <> 8

let _ =
    if 3 + 8 = 9 then
        "equal"
    else
        "not equal"

let _ = (if 3 + 8 <> 9 then "not " else "") + "equal"

let _ = (if 3 + 8 <> 11 then "not " else "") + "equal"

let _ =
    if 3 + 6 = 9 then
        "equal"
    else
        "not equal"

let three = 3

let _ = three + three

let _ = three = 5

let square x = x * x

let _ = square 3

let _ = string 5

let _ = string 5.0

let _ = string 3.5

let _ = int "5"

let _ = float "3.5"

let _ = float 5

let _ = int 5.0

let _ = int 3.5

let _ = int -3.5

let _ = int "hello"

let _ = 2 + 3 * 5

let _ = (2 + 3) * 5

let eq5 n = n = 5

let _ = eq5 5

let _ = eq5 3

let eq5' n = (n = 5)

let _ = String.length "abcde"

let _ = String.length ""

let isShort10 s = String.length s < 10

let drop10 s =
    if String.length s < 10 then
        s
    else
        s[10 .. String.length s - 1]

let drop10' s =
    if isShort10 s then
        s
    else
        s[10 .. String.length s - 1]

let drop10'' s =
    let len = String.length s

    if len < 10 then s else s[10 .. len - 1]

let _ = "abcde"[2..100]

let _ = "abcde"[2..]

let drop10''' s =
    if String.length s < 10 then
        s
    else
        s[10..]

let toMessage n =
    if n > 0 then
        "あなたのIDは " + string n + " です。"
    else
        "IDが正しくありません。"

let _ = toMessage 100

let _ = toMessage 42

let _ = toMessage 0

let toMessage' n =
    if n > 0 then
        $"あなたのIDは {n} です。"
    else
        "IDが正しくありません。"

let isLeapYear year =
    year % 4 = 0 && year % 100 <> 0 || year % 400 = 0

let _ = isLeapYear 2022

let _ = isLeapYear 2024

let _ = isLeapYear 2100

let _ = isLeapYear 2000

let isLeapYear' year =
    (year % 4 = 0) && (year % 100 <> 0)
    || (year % 400 = 0)

let isLeapYear'' year =
    if year % 400 = 0 then true
    elif year % 100 = 0 then false
    elif year % 4 = 0 then true
    else false

let _ = System.DateTime.IsLeapYear 2022

let _ = System.DateTime.IsLeapYear 2024

let _ = System.DateTime.IsLeapYear 2100

let _ = System.DateTime.IsLeapYear 2000