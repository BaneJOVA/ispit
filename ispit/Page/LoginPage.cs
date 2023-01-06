using OpenQA.Selenium;
using SwagProject.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagProject.Page
{
    public class LoginPage
    {
        private IWebDriver driver = WebDrivers.Instance;

        public IWebElement UserName => driver.FindElement(By.Id("user-name"));
        public IWebElement Password => driver.FindElement(By.Id("password"));

        public IWebElement ButtonLogin => driver.FindElement(By.Id("login-button"));

        public void Login(string user, string pass)
        {
            UserName.SendKeys(user);
            Password.SendKeys(pass);
            ButtonLogin.Submit();
        }
    }
}