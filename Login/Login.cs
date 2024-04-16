using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace learning.Tests
{
    internal class Test
    {
        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("profile.default_content_setting_values.notifications", 2);
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://work.fastdo.vn/");
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("[type='button'][class='button is-link accept-policy']")).Click();
            Thread.Sleep(5000);
        }
        [Test]
        public void testcase1()
        {
            //Test case 01: để trống email và mật khẩu
            driver.FindElement(By.CssSelector("#login > section.login_fr > div > form > button")).Click();
            Thread.Sleep(5000);
            //message
            string errorMessage = driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/div[5]")).Text;
            string expectedErrorMessage = "Tên đăng nhập không được để trống!";
            if (errorMessage == expectedErrorMessage)
            {
                Console.WriteLine("Testcase01 PASSED.");
            }
            else
            {
                Console.WriteLine("Testcase01 FAILDED: Không hiển thị message hoặc hiển thị không đúng yêu cầu.");
            }
            Thread.Sleep(2000);
            driver.Quit();
        }
        [Test]
        public void testcase2()
        {
            //test case 02: Để trống mật khẩu
            driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/div[2]/input")).SendKeys("abc");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/button")).Click();
            Thread.Sleep(5000);
            string errorMessage1 = driver.FindElement(By.CssSelector("#login > section.login_fr > div > form > div.has-text-danger.has-text-centered.is-italic.mb-3")).Text;
            string expectedErrorMessage1 = "Mật khẩu không được để trống!";
            if (errorMessage1 == expectedErrorMessage1)
            {
                Console.WriteLine("Testcase02 PASSED.");
            }
            else
            {
                Console.WriteLine("Testcase02 FAILDED: Không hiển thị message hoặc hiển thị không đúng yêu cầu.");
            }
            Thread.Sleep(2000);
            driver.Quit();
        }
        [Test]
        public void testcase3()
        {
            //testcase3: hiển thị thông báo khi user để trống trường email
            driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/div[3]/input")).SendKeys("abc");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/button")).Click();
            Thread.Sleep(3000);
            string errorMessage = driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/div[5]")).Text;
            string expectedErrorMessage = "Tên đăng nhập không được để trống!";
            if (errorMessage == expectedErrorMessage)
            {
                Console.WriteLine("Testcase03 PASSED.");
            }
            else
            {
                Console.WriteLine("Testcase03 FAILDED: Không hiển thị message hoặc hiển thị không đúng yêu cầu.");
            }
            Thread.Sleep(2000);
            driver.Quit();
        }
        [Test]
        public void testcase4()
        {
            //testcase4: hiển thị thống báo tài khoản không tồn tại khi nhập sai tên email và sai mật khẩu
            //nhập sai email
            driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/div[2]/input")).SendKeys("abc");
            Thread.Sleep(1000);
            //nhập sai mật khẩu
            driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/div[3]/input")).SendKeys("abc");
            Thread.Sleep(1000);
            //click button
            driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/button")).Click();
            Thread.Sleep(3000);
            //kiểm tra hiển thị thông báo lỗi
            string errorMessage = driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/div[5]")).Text;
            string expectedErrorMessage = "Tài khoản không tồn tại!";
            if (errorMessage == expectedErrorMessage)
            {
                Console.WriteLine("Testcase04 PASSED.");
            }
            else
            {
                Console.WriteLine("Testcase04 FAILDED: Không hiển thị message hoặc hiển thị không đúng yêu cầu.");
            }
            Thread.Sleep(2000);
            driver.Quit();
        }
        [Test]
        public void testcase5()
        {
            //testcase5: hiển thị thống báo tài khoản không tồn tại khi nhập thiếu @ vào tên email 
            //nhập email thiếu @
            driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/div[2]/input")).SendKeys("thuonnth.fastdogmail.com");
            Thread.Sleep(1000);
            //nhập mật khẩu
            driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/div[3]/input")).SendKeys("abc");
            Thread.Sleep(1000);
            //click button
            driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/button")).Click();
            Thread.Sleep(3000);
            //kiểm tra hiển thị thông báo lỗi
            string errorMessage = driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/div[5]")).Text;
            string expectedErrorMessage = "Tài khoản không tồn tại!";
            if (errorMessage == expectedErrorMessage)
            {
                Console.WriteLine("Testcase05 PASSED.");
            }
            else
            {
                Console.WriteLine("Testcase05 FAILDED: Không hiển thị message hoặc hiển thị không đúng yêu cầu.");
            }
            Thread.Sleep(2000);
            driver.Quit();
        }
        [Test]
        public void testcase6()
        {
            //testcase6: hiển thị thống báo tài khoản không tồn tại khi nhập sai vào tên email và đúng mật khẩu
            //nhập sai email
            driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/div[2]/input")).SendKeys("thuonnth.fastdogmail.com");
            Thread.Sleep(1000);
            //nhập đúng mật khẩu
            driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/div[3]/input")).SendKeys("fastdo@123");
            Thread.Sleep(1000);
            //click button
            driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/button")).Click();
            Thread.Sleep(3000);
            //kiểm tra hiển thị thông báo lỗi
            string errorMessage = driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/div[5]")).Text;
            string expectedErrorMessage = "Tài khoản không tồn tại!";
            if (errorMessage == expectedErrorMessage)
            {
                Console.WriteLine("Testcase06 PASSED.");
            }
            else
            {
                Console.WriteLine("Testcase06 FAILDED: Không hiển thị message hoặc hiển thị không đúng yêu cầu.");
            }
            Thread.Sleep(2000);
            driver.Quit();
        }
        [Test]
        public void testcase7()
        {
            //testcase7: hiển thị thống báo khi nhập khoảng trắng vào tên email
            //nhập email
            driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/div[2]/input")).SendKeys("        ");
            Thread.Sleep(1000);
            //nhập đúng mật khẩu
            driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/div[3]/input")).SendKeys("abc");
            Thread.Sleep(1000);
            //click button
            driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/button")).Click();
            Thread.Sleep(3000);
            //kiểm tra hiển thị thông báo lỗi
            string errorMessage = driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/div[5]")).Text;
            string expectedErrorMessage = "Tên đăng nhập không được để trống!";
            if (errorMessage == expectedErrorMessage)
            {
                Console.WriteLine("Testcase07 PASSED.");
            }
            else
            {
                Console.WriteLine("Testcase07 FAILDED: Không hiển thị message hoặc hiển thị không đúng yêu cầu.");
            }
            Thread.Sleep(2000);
            driver.Quit();
        }
        [Test]
        public void testcase8()
        {
            //testcase8: hiển thị thống báo khi nhập email có chứa khoảng trắng và đúng mật khẩu
            //nhập email
            driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/div[2]/input")).SendKeys("       thuong.nth.fastdo@gmail.com ");
            Thread.Sleep(1000);
            //nhập đúng mật khẩu
            driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/div[3]/input")).SendKeys("fastdo@123");
            Thread.Sleep(1000);
            //click button
            driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/button")).Click();
            Thread.Sleep(3000);
            //kiểm tra hiển thị thông báo lỗi
            string errorMessage = driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/div[5]")).Text;
            string expectedErrorMessage = "Tài khoản không tồn tại!";
            if (errorMessage == expectedErrorMessage)
            {
                Console.WriteLine("Testcase08 PASSED.");
            }
            else
            {
                Console.WriteLine("Testcase08 FAILDED: Không hiển thị message hoặc hiển thị không đúng yêu cầu.");
            }
            Thread.Sleep(2000);
            driver.Quit();
        }
        [Test]
        public void testcase9()
        {
            //testcase9: hiển thị thống báo khi nhập sai vào tên email và khoảng trắng mật khẩu
            //nhập email
            driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/div[2]/input")).SendKeys("thuongnth.fastdo@gmail.com");
            Thread.Sleep(1000);
            //nhập đúng mật khẩu
            driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/div[3]/input")).SendKeys("       ");
            Thread.Sleep(1000);
            //click button
            driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/button")).Click();
            Thread.Sleep(10000);
            //click button lần 2
            driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/button")).Click();
            Thread.Sleep(3000);
            //kiểm tra hiển thị thông báo lỗi
            string errorMessage = driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/div[5]")).Text;
            string expectedErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng!";
            if (errorMessage == expectedErrorMessage)
            {
                Console.WriteLine("Testcase09 PASSED.");
            }
            else
            {
                Console.WriteLine("Testcase09 FAILDED: Không hiển thị message hoặc hiển thị không đúng yêu cầu.");
            }
            Thread.Sleep(2000);
            driver.Quit();
        }
        [Test]
        public void testcase10()
        {
            //testcase10: hiển thị thông báo "Tên đăng nhập hoặc mật khẩu không đúng ! Thử lại: 14 lần" khi người dùng nhập đúng email và sai mật khẩu
            //thi thoảng gặp bug không thể click button;
            //nhập đúng email
            driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/div[2]/input")).SendKeys("thuongnth.fastdo@gmail.com");
            Thread.Sleep(1000);
            //nhập sai mật khẩu
            driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/div[3]/input")).SendKeys("fastdo");
            Thread.Sleep(8000);
            //click button
            driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/button")).Click();
            Thread.Sleep(3000);
            //click button lần 2
            Thread.Sleep(10000);
            driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/button")).Click();
            Thread.Sleep(3000);
            //kiểm tra hiển thị thông báo lỗi
            string errorMessage = driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/form/div[5]")).Text;
            string expectedErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng ! Thử lại: 14 lần";
            if (errorMessage == expectedErrorMessage)
            {
                Console.WriteLine("Testcase10 PASSED.");
            }
            else
            {
                Console.WriteLine("Testcase10 FAILDED: Không hiển thị message hoặc hiển thị không đúng yêu cầu.");
            }
            Thread.Sleep(2000);
            driver.Quit();
        }
        [Test]
        public void testcase11()
        {
            //testcase11: đăng nhập thành công
            Login();
            Thread.Sleep(3000);
            driver.Quit();

        }
        [Test]
        public void testcase12()
        {
            //testcase12: đăng nhập thành công và đăng xuất
            Login();
            Thread.Sleep(3000);
            Logout();
            Thread.Sleep(3000);
            driver.Quit();
        }
        [Test]
        public void testcase13()
        {
            ////testcase13: đăng nhập thành công và truy cập vào trang demo
            Login();
            Thread.Sleep(3000);
            Access();
            Thread.Sleep(3000);
            driver.Quit();
        }
        [Test]
        public void testcase14()
        {
            //testcasse14: xác minh rằng hiển thị đúng title ở trang chủ login 
            string expect = "Chào mừng đến với Fastdo";
            string message = driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/h1")).Text;
            if (expect == message)
            {
                Console.WriteLine("PASS title");
            }    
            else
            {
                Console.WriteLine("FAILED title");
            }
            driver.Quit();
        }
        [Test]
        public void testcase15()
        {
            //testcase15: xác minh rằng hiển thị đúng lable ở trang login
            string expected = "Tối ưu vận hành với bộ giải pháp công nghệ của Fastdo";
            string message = driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/div[2]")).Text;
            if (expected == message)
            {
                Console.WriteLine("PASSED");
            }
            else
            {
                Console.WriteLine("FAILED");
            }
            driver.Quit();
                
        }
        [Test]
        public void testcase16()
        {
            //testcase16: xác minh rằng hiển thị đúng title khi user đăng nhập thành công 
            Login();
            Thread.Sleep(3000);
            string expected = "Chào mừng! Nguyễn Trần Hoài Thương";
            string message = driver.FindElement(By.XPath("//*[@id='login']/section[1]/div/h1")).Text;
            if (expected == message)
            {
                Console.WriteLine("PASSED");
            }
            else
            {
                Console.WriteLine("FAILED");
            }
            Thread.Sleep(1000);
            driver.Quit();
        }
        //đăng xuất thành công
        public void Login()
        {
            driver.FindElement(By.CssSelector("[type='email'][class='input']")).SendKeys("thuongnth.fastdo@gmail.com");
            driver.FindElement(By.CssSelector("[type='password'][class='input']")).SendKeys("fastdo@123");
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("#login > section.login_fr > div > form > button")).Click();
        }
        // đăng nhập thành công
        public void Logout()
        {
            driver.FindElement(By.CssSelector("#login > section.login_fr > div > a")).Click();
            Thread.Sleep(3000);
            IAlert alert = driver.SwitchTo().Alert();
            Console.WriteLine(alert.Text);
            alert.Accept();
        }
        //truy cập vào trang demo fastdo
        public void Access()
        {
            driver.FindElement(By.CssSelector("#login > section.login_fr > div > form > div:nth-child(3) > a")).Click();
        }
    }
}

