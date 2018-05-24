module DriverFactory

open System
open OpenQA.Selenium.Firefox
open OpenQA.Selenium.Chrome

let Firefox =
    let service = FirefoxDriverService.CreateDefaultService()
    let options = new FirefoxOptions()
    let time = TimeSpan.FromSeconds 30.0
    new FirefoxDriver(service,options,time)

let Chrome =
    let service = ChromeDriverService.CreateDefaultService()
    let options = new ChromeOptions()
    let time = TimeSpan.FromSeconds 30.0
    new ChromeDriver(service,options,time)
