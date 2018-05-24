module DriverFactory

open System
open OpenQA.Selenium.Firefox
open OpenQA.Selenium.Chrome

let Firefox =
    try
        let service = FirefoxDriverService.CreateDefaultService()
        let options = new FirefoxOptions()
        let time = TimeSpan.FromSeconds 30.0
        Some (new FirefoxDriver(service,options,time))
    with
        _ -> printfn "Firefox driver not found on your system"; None

let Chrome =
    try
        let service = ChromeDriverService.CreateDefaultService()
        let options = new ChromeOptions()
        let time = TimeSpan.FromSeconds 30.0
        Some (new ChromeDriver(service,options,time))
    with
        _ -> printfn "Chrome driver not found on your system"; None
