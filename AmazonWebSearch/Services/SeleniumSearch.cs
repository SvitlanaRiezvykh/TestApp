using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AmazonWebSearch.Services
{
    public class SeleniumSearch : IAmazonSearch, IDisposable
    {
        //todo complete and refactor work with selenium
        IWebDriver _driver;

        public SeleniumSearch()
        {
            _driver = new ChromeDriver();
        }

        public async Task<double> FindPrice(string productCatgoty, string deliveryCountry)
        {
            double price = 0;
            _driver.Url = "https://www.amazon.com";
            //complete page object, search on amazon

            return price;
        }

        public void Dispose()
        {
            _driver.Quit();
        }
    }
}