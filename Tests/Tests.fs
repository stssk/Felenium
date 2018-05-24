module Tests.Felenium

open Xunit
open Felenium
open DriverFactory

[<Fact>]
let ``Can open Firefox`` () =
    match Firefox with
    | Some driver -> 
        driver 
        |> Visit "https://github.com/stssk/Felenium"
        |> Close
    | None -> Assert.True false

[<Fact>]
let ``Can open Chrome`` () =
    match Chrome with
    | Some driver -> 
        driver 
        |> Visit "https://github.com/stssk/Felenium"
        |> Close
    | None -> Assert.True false