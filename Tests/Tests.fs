module Tests.Felenium

open Xunit
open Felenium
open OpenQA.Selenium.Firefox

[<Fact>]
let ``Can open a web page`` () =
    new FirefoxDriver()
    |> Visit "https://github.com/stssk/Felenium"
    |> Close

[<Fact>]
let ``Can search the web`` () =
    new FirefoxDriver()
    |> Visit "https://duckduckgo.com"
    |> Write Id "search_form_input_homepage" "Selenium"
    |> Click Id "search_button_homepage"
    |> Wait 10
    |> Close