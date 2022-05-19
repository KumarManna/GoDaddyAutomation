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
            By Back = By.XPath("//*[@aria-label='GoDaddy']");
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
            By op; int k,j;
            string p;
            try
            {
                Move(driver, menu);
                Thread.Sleep(500);
                Mouse_Action(driver, domain);
                Thread.Sleep(500);
                for (int i = 2; i <= list1.Count; i++)
                {
                    k = i;
                    
                    op = By.XPath(a + k.ToString() + "]");
                    Console.WriteLine(a + k.ToString() + "]");
                    if (ElementIs_Clickable(this.driver, op) == true)
                    {
                        Console.WriteLine("Hi");
                        Move(driver, op);
                        Thread.Sleep(1000);
                        p = driver.Title;
                        if (p.Contains(list1[i]))
                        {
                            Thread.Sleep(500);
                            Console.WriteLine("True");
                        }
                        //Assert.Pass("Pass");
                    }
                    else
                        Console.WriteLine("False");

                    Thread.Sleep(1000);
                    Move(driver, Back);
                    Thread.Sleep(500);
                    if (i >list1.Count)
                        break;
                    
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
