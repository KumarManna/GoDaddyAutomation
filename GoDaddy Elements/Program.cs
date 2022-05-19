using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using System.Text;
using System.Threading;
using BrowserControl;
namespace GoDaddy_Elements
{
    class Program:Browser
    {
        public void Multi_Title_Check()
        {
            By menu = By.XPath("//*[@class='product-flyout-btn']");

            By domain = By.XPath("//*[@class='product-flyout-btn']//following::li[1]/button"); 

            By List1 = By.XPath("//*[@class='product-flyout-btn']//following::li[1]//child::li");
            By Back1 = By.XPath("//*[@aria-label='GoDaddy']");
            By Back2 = By.XPath("//*[@href=''https://www.godaddy.com/en-in?ci=]");

           // By Back = By.XPath("//*[@href=https://www.godaddy.com/en-in");
            By c = By.XPath("//*[@class='close']");

            List<string> list1 = new List<string>();
            list1.Add("Domain Name Search - Buy and Register Available Domains - GoDaddy IN");
            list1.Add("Domain Transfer | Domain Name Transferring Made Easy - GoDaddy IN");
            list1.Add("Domain Privacy & Protection | Your Domain Is Worth Protecting - GoDaddy IN");
            list1.Add("WHOIS | Lookup Domain Name Availability - GoDaddy IN");
            list1.Add("Domain Auction | Buy & Sell Distinctive Domains - GoDaddy");
            list1.Add("Free Domain Value and Appraisal Tool | What is your domain worth? - GoDaddy IN");
            list1.Add("Domain Investing | Resources to help you get started - GoDaddy IN");
            list1.Add("Premium DNS Hosting | Bullet Proof DNS Security & Hosting - GoDaddy IN");

            IReadOnlyCollection<IWebElement> list = this.driver.FindElements(List1);
            string a = "//*[@class='product-flyout-btn']//following::li[1]//child::li[";
            By op; int j;
            int index = 0;
            
            try
            {
                
                j = 2;
                foreach (string l in list1)
                {
                    Move(driver, menu);
                    Thread.Sleep(500);
                    Mouse_Action(driver, domain);
                    Thread.Sleep(500);
                    op = By.XPath(a + j.ToString() + "]");
                    Console.WriteLine(a + j.ToString() + "]");
                    if (ElementIs_Clickable(this.driver, op))
                    {
                        try
                        {
                            Console.WriteLine("Hi");
                            Move(driver, op);
                            Thread.Sleep(100);
                            Console.WriteLine(driver.Title.Contains(list1[index]));
                            Thread.Sleep(1000);
                            Move(driver, Back1);
                        }
                        catch (Exception)
                        {
                            driver.Navigate().Back();
                        }
                        index++;
                       
                    }
                    else
                    {
                        Move(driver, c);
                    }
                    j++;
                }
                // Assert.Fail("Fail");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Open()
        {
            Open_Url("https://www.godaddy.com/");
        }
        public void Close() { Close_quit(); }

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Open();
            p.Multi_Title_Check();
            p.Close();
        }
    }
}
