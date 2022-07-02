using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.DevTools;

string RandomString(int length)
{
    var random = new Random();
    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    var result = new string(Enumerable.Repeat(chars, length)
      .Select(s => s[random.Next(s.Length)]).ToArray());
    return result;
}

ChromeDriver driver = new ChromeDriver();
IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

string FirstName = RandomString(14);
string LastName = RandomString(14);
string UserName = RandomString(14);

void googleAccountCreator()
{
    driver.Navigate().GoToUrl("https://www.google.com/gmail/about/");
    driver.FindElement(By.XPath("//span[contains(.,\'Get Gmail\')]")).Click();
    driver.FindElement(By.Id("firstName")).SendKeys(FirstName);
    driver.FindElement(By.Id("lastName")).Click();
    driver.FindElement(By.Id("lastName")).SendKeys(LastName);
    driver.FindElement(By.Id("username")).Click();
    driver.FindElement(By.Id("username")).SendKeys(UserName);
    driver.FindElement(By.Name("Passwd")).Click();
    driver.FindElement(By.Name("Passwd")).SendKeys("ENTER_PASSWORD_HERE");
    driver.FindElement(By.Name("ConfirmPasswd")).SendKeys("ENTER_PASSWORD_HERE");
    driver.FindElement(By.XPath("//span[contains(.,\'Next\')]")).Click();
    {
        WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(30));
        wait.Until(driver => driver.FindElements(By.Id("phoneNumberId")).Count > 0);
    }
    driver.FindElement(By.Id("phoneNumberId")).Click();
    driver.FindElement(By.Id("phoneNumberId")).SendKeys("ENTER_PHONENUMBER_HERE");
    driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div[1]/div[2]/div/div/div[2]/div/div[2]/div/div[1]/div/div/button")).Click();
    {
        WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(30));
        wait.Until(driver => driver.FindElements(By.Id("month")).Count > 0);
    }
    driver.FindElement(By.Id("month")).Click();
    {
        var dropdown = driver.FindElement(By.Id("month"));
        dropdown.FindElement(By.XPath("//option[. = 'July']")).Click();
    }
    driver.FindElement(By.Id("day")).Click();
    driver.FindElement(By.Id("day")).SendKeys("14");
    driver.FindElement(By.Id("year")).Click();
    driver.FindElement(By.Id("year")).SendKeys("1983");
    driver.FindElement(By.Id("gender")).Click();
    {
        var dropdown = driver.FindElement(By.Id("gender"));
        dropdown.FindElement(By.XPath("//option[. = 'Male']")).Click();
    }
    driver.FindElement(By.XPath("//button/div[3]")).Click();
    driver.FindElement(By.XPath("//div[@id=\'view_container\']/div/div/div[2]/div/div[2]/div/div/div/div/button/span")).Click();
    Console.WriteLine("________________________");
    Console.WriteLine("FirstName: " + FirstName);
    Console.WriteLine("LastName: " + LastName);
    Console.WriteLine("UserName: " + UserName);
    Console.WriteLine("________________________");
}

googleAccountCreator();