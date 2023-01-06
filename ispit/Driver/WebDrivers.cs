using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SwagProject.Driver
{
    public class WebDrivers
    {
        public static IWebDriver? Instance { get; set; }//Instance - zvanje elemenata i setovanje za sta nam trebaju


        public static void Initialize()
        {
            Instance = new ChromeDriver();
            Instance.Manage().Window.Maximize();
            Instance.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);//ImplicitWait - bez ovoga pada test - brzina ucitavanja zavisi od njega
            Instance.Navigate().GoToUrl("https://www.saucedemo.com/");
        }


        public static void CleanUp()
        {
            Instance?.Quit();
        }



    }
}
