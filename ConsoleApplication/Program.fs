open System.IO
open System.Text

let displayFile () =
    File.ReadAllText(@"C:\text\myfile.txt", Encoding.UTF8)
    |> printfn "%s"

displayFile ()