module Felenium

open OpenQA.Selenium
open OpenQA.Selenium.Remote
open OpenQA.Selenium.Support.UI
open Xunit

type ContentType =
    Button | Div | A | Id | Title | Option | ClassName | Name | XPath
    
let private locate elementType elementText =
    match elementType with
    | Button -> By.XPath <| "//button[contains(., '" + elementText + "')]"
    | Div -> By.XPath <| "//div[contains(., '" + elementText + "')]"
    | A -> By.XPath <| "//a[contains(., '" + elementText + "')]"
    | Id -> By.Id elementText
    | Title -> By.XPath <| @"//*[@title='" + elementText + "']"
    | Option -> By.XPath <| "//option[contains(., '" + elementText + "')]"
    | ClassName -> By.ClassName elementText
    | Name -> By.Name elementText
    | XPath -> By.XPath elementText

let private getElement elementType elementText (driver:RemoteWebDriver) =
    let elements = 
        driver.FindElements 
        <| locate elementType elementText
    Assert.NotNull elements
    Assert.NotEmpty elements
    elements.[0]

let Click elementType elementText (driver:RemoteWebDriver) =
    let e = getElement elementType elementText driver
    e.Click()
    driver

let Write elementType elementText text (driver:RemoteWebDriver) =
    let e = getElement elementType elementText driver
    e.SendKeys text
    driver

let Select elementType elementText innerElementText (driver:RemoteWebDriver) =
    let e = getElement elementType elementText driver
    let selector = new SelectElement(e)
    selector.SelectByText innerElementText
    driver

let Visit (url:string) (driver:RemoteWebDriver) =
    driver.Navigate().GoToUrl(url)
    driver

let Screenshot name (driver:RemoteWebDriver) =
    driver.GetScreenshot().SaveAsFile name
    driver

let ExecuteScript script (driver:RemoteWebDriver) =
    driver.ExecuteScript(script,[])
    |> ignore
    driver

let Wait duration (driver:RemoteWebDriver) = 
    duration * 1000
    |> System.Threading.Thread.Sleep
    driver

let Close (driver:RemoteWebDriver) =
    driver.Close()

let Check elementType text value (driver:RemoteWebDriver) =
    let locator = locate elementType text
    let elements = driver.FindElements locator
    Assert.NotNull elements
    if isNull elements |> not then
        Assert.Equal (elements.[0].Text,value)
    driver

let Maximize (driver:RemoteWebDriver) =
    driver.Manage().Window.Maximize()
    driver
