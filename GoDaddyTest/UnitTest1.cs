using NUnit.Framework;
using BrowserControl;
using OpenQA.Selenium;
using System.Collections.Generic;
using System;
using System.Threading;
namespace GoDaddyTest
{
    public class Tests:Browser
    {
        [OneTimeSetUp]
        public void Setup()
        {
            Open_Url("https://www.godaddy.com/");
        }

        [Test]
        public void Test1()
        {
            Console.WriteLine(url);
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            Console.WriteLine(driver.Title);
            Console.WriteLine(driver.Url);
            Assert.Pass();
        }

        [Test,Category("Validate Page Title")]
        [Parallelizable]
        public void Test3()
        {
            //Assert.AreEqual("Domain Names, Websites, Hosting & Online Marketing Tools - GoDaddy IN", driver.Title);
            //Assert.AreEqual("https://www.godaddy.com/en-in",driver.Url);
            //if(driver.Title.Contains("Domain Names, Websites, Hosting & Online Marketing Tools - GoDaddy IN"))
            //{
            //    Assert.Pass("Title Pass and URL Pass");
            //}
            //else
            //{
            //    Assert.Fail("Title Fail and URL Fail");
            //}
            Assert.AreEqual(driver.Url, "https://www.godaddy.com/en-in","Test Fail");

        }

        [Test, Category("Validate Page Title")]
        [Parallelizable]
        public void Test4()
        {
            if (driver.Url.Contains("https://www.godaddy.com/en-in"))
                Assert.Pass("URL validate pass");
            else
                Assert.Fail();
        }

        [Test, Category("Validate Page Title")]
        [Parallelizable]
        public void Test5()
        {
            string ps;
            try
            {
                ps = driver.PageSource;
                Console.WriteLine(ps);
                if (ps.Contains("Domain Names, Websites, Hosting &amp; Online Marketing Tools - GoDaddy IN"))
                {
                    Assert.Pass("Page source contains title");
                }
                else
                {
                    Assert.Fail();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        [Test]
        public void Test6()
        {
            By menu = By.XPath("//*[@class='product-flyout-btn']");
          
            By domain = By.XPath("//*[@class='product-flyout-btn']//following::li[1]/button");
            
            By DNS = By.XPath("//*[@class='product-flyout-btn']//following::li[1]//child::li[2]");
           
            string page_title = "Domain Name Search - Buy and Register Available Domains - GoDaddy IN";
            try
            {
                Move(driver, menu);
                Mouse_Action(driver, domain);
                Move(driver, DNS);
                Console.WriteLine(driver.Title);
                if (page_title.Contains(driver.Title))
                    Assert.Pass("Pass");
                else
                    Assert.Fail("Fail");
            }
            catch(Exception)
            {
                throw;
            }
        }

        [Test]
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
            string a= "//*[@class='product-flyout-btn']//following::li[1]//child::li[";
            By op; int k;
            try
            {
                Move(driver, menu);
                Mouse_Action(driver, domain);
                for (int i=1;i<=list1.Count;i++)
                {
                    k = i;
                    op = By.XPath(a + k.ToString() + "]");
                    Console.WriteLine(a + k.ToString() + "]");
                    if (ElementIs_Clickable(this.driver,op) == true)
                    {
                        Console.WriteLine("Hi");
                        Move(driver, op);
                        if (driver.Title.Contains(list1[i]))
                            Console.WriteLine("True");
                            //Assert.Pass("Pass");
                    }
                    else
                        Console.WriteLine("False");
                    
                    Thread.Sleep(1000);
                    Move(driver, Back);
                    if (i <= list1.Count)
                        break;
                }
               // Assert.Fail("Fail");
            }
            catch (Exception)
            {
                throw;
            }
        }


        [OneTimeTearDown]
        public void End()
        {
            Close_quit();
        }
    }
}