using OpenQA.Selenium.DevTools.V105.Profiler;
using SwagProject.Driver;
using SwagProject.Page;

namespace SwagProject.Test
{
    public class Tests
    {
        LoginPage loginPage;
        ProductPage productPage;
        CardPage cardPage;


        [SetUp]
        public void Setup()
        {
            WebDrivers.Initialize();
            loginPage = new LoginPage();
            productPage = new ProductPage();
            cardPage = new CardPage();
        }

        [TearDown]
        public void Close()
        {
            WebDrivers.CleanUp();
        }

        [Test]
        public void TC01_AddTwoProductInCart_ShoulddispleydTwoProduct()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.AddBackPac.Click();
            productPage.AddT_Shirt.Click();

            Assert.That("2", Is.EqualTo(productPage.Cart.Text));

        }

        [Test]
        public void TC02_SortProductByPrice_ShouldSortByHighPrice()
        {
            loginPage.Login("standard_user", "secret_sauce");

            productPage.SelectOption("Price (high to low)");

            Assert.That(productPage.SortByHighPrice.Displayed);

        }

        [Test]
        public void TC03_GoToAboutPage_ShouldRedactioToNewPage()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.MenuClick.Click();
            productPage.AboutClick.Click();

            Assert.That("https://saucelabs.com/", Is.EqualTo(WebDrivers.Instance.Url));
        }

        [Test]
        public void TC04_ByProduct_ShouldBeFhinishedShopping()
        {
            loginPage.Login("standard_user", "secret_sauce");
            productPage.AddBackPac.Click();
            productPage.AddT_Shirt.Click();
            productPage.ShoppingCardClick.Click();

            cardPage.Checkaut.Click();
            cardPage.FirstName.SendKeys("Bane");
            cardPage.LastName.SendKeys("Jovanovic");
            cardPage.ZiplCode.SendKeys("11000");
            cardPage.ButonContinue.Submit();

            cardPage.Finish.Click();

            Assert.That("THANK YOU FOR YOUR ORDER", Is.EqualTo(cardPage.OrderFinished.Text));

        }
    }
}