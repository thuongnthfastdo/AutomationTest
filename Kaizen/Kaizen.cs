using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using OpenQA.Selenium.Support.UI;

namespace learning.Tests
{
    internal class Kaizen
    {
        private IWebDriver driver;
        [SetUp]
        public void SetUp()
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
        public void Test1()
        {
            //Test case 01: Tạo mới kaizen để trống value 
            Login();
            Thread.Sleep(5000);
            Access();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//*[@id='content']/section/ul[2]/li[1]/div/ul/li[6]/a/span[2]")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//*[@id='content']/div/div[3]/div/div[2]/button")).Click();
            Thread.Sleep(2000);
            string expected = "Vui lòng nhập tiêu đề và nội dung của Kaizen này!";
            string error = driver.FindElement(By.XPath("//*[@id='notify']/div/p")).Text;
            if (error == expected)
            {
                Console.WriteLine("PASSED");
            }    
            else
            {
                Console.WriteLine("FAILED");
            }
            Thread.Sleep(5000);
            driver.Quit();

        }
        [Test]
        public void Test2()
        {
            //Test case 02: Tạo mới kaizen để trống value ở text box nội dung
            Login();
            Thread.Sleep(5000);
            Access();
            Thread.Sleep(5000);
            // mở form nhập
            driver.FindElement(By.XPath("//*[@id='content']/section/ul[2]/li[1]/div/ul/li[6]/a/span[2]")).Click();
            Thread.Sleep(5000);
            //nhập tiêu đề và để trống nội dung
            driver.FindElement(By.XPath("//*[@id='content']/div/div[2]/div/div/div[2]/div[3]/div/input")).SendKeys("abc");
            Thread.Sleep(5000);
            // Click nút gửi
            driver.FindElement(By.XPath("//*[@id='content']/div/div[3]/div/div[2]/button")).Click();
            Thread.Sleep(2000);
            string expected = "Vui lòng nhập tiêu đề và nội dung của Kaizen này!";
            string error = driver.FindElement(By.XPath("//*[@id='notify']/div/p")).Text;
            if (error == expected)
            {
                Console.WriteLine("PASSED");
            }
            else
            {
                Console.WriteLine("FAILED");
            }
            Thread.Sleep(5000);
            driver.Quit();

        }
        [Test]
        public void Test3()
        {
            //Test case 03: Tạo mới kaizen để trống value ở text box tiêu đề
            Login();
            Thread.Sleep(5000);
            Access();
            Thread.Sleep(5000);
            // mở form nhập
            driver.FindElement(By.XPath("//*[@id='content']/section/ul[2]/li[1]/div/ul/li[6]/a/span[2]")).Click();
            Thread.Sleep(5000);
            //nhập nội dung và để trống tiêu đề
            driver.FindElement(By.TagName("textarea")).SendKeys("abcdef");
            Thread.Sleep(5000);
            // Click nút gửi
            driver.FindElement(By.XPath("//*[@id='content']/div/div[3]/div/div[2]/button")).Click();
            Thread.Sleep(2000);
            string expected = "Vui lòng nhập tiêu đề và nội dung của Kaizen này!";
            string error = driver.FindElement(By.XPath("//*[@id='notify']/div/p")).Text;
            if (error == expected)
            {
                Console.WriteLine("PASSED");
            }
            else
            {
                Console.WriteLine("FAILED");
            }
            Thread.Sleep(5000);
            driver.Quit();

        }
        [Test]
        public void Test4()
        {
            //Test case 04: Tạo mới kaizen nhập khoảng trắng ở text box tiêu đề và nội dung
            Login();
            Thread.Sleep(5000);
            Access();
            Thread.Sleep(5000);
            // mở form nhập
            driver.FindElement(By.XPath("//*[@id='content']/section/ul[2]/li[1]/div/ul/li[6]/a/span[2]")).Click();
            Thread.Sleep(5000);
            //nhập khoảng trắng ở textbox tiêu đề và nội dung
            driver.FindElement(By.XPath("//*[@id='content']/div/div[2]/div/div/div[2]/div[3]/div/input")).SendKeys("                      ");
            driver.FindElement(By.TagName("textarea")).SendKeys("                  ");
            Thread.Sleep(5000);
            // Click nút gửi
            driver.FindElement(By.XPath("//*[@id='content']/div/div[3]/div/div[2]/button")).Click();
            Thread.Sleep(2000);
            string expected = "Vui lòng nhập tiêu đề và nội dung của Kaizen này!";
            string error = driver.FindElement(By.XPath("//*[@id='notify']/div/p")).Text;
            if (error == expected)
            {
                Console.WriteLine("PASSED");
            }
            else
            {
                Console.WriteLine("FAILED");
            }
            Thread.Sleep(5000);
            driver.Quit();

        }
        [Test]
        public void Test5()
        {
            //Test case 05: Tạo mới kaizen nhập khoảng trắng ở text box tiêu đề
            Login();
            Thread.Sleep(5000);
            Access();
            Thread.Sleep(5000);
            // mở form nhập
            driver.FindElement(By.XPath("//*[@id='content']/section/ul[2]/li[1]/div/ul/li[6]/a/span[2]")).Click();
            Thread.Sleep(5000);
            //nhập khoảng trắng ở textbox tiêu đề và nhập dữ liệu ở textbox nội dung
            driver.FindElement(By.XPath("//*[@id='content']/div/div[2]/div/div/div[2]/div[3]/div/input")).SendKeys("                      ");
            driver.FindElement(By.TagName("textarea")).SendKeys("abcdeff");
            Thread.Sleep(5000);
            // Click nút gửi
            driver.FindElement(By.XPath("//*[@id='content']/div/div[3]/div/div[2]/button")).Click();
            Thread.Sleep(2000);
            string expected = "Vui lòng nhập tiêu đề và nội dung của Kaizen này!";
            string error = driver.FindElement(By.XPath("//*[@id='notify']/div/p")).Text;
            if (error == expected)
            {
                Console.WriteLine("PASSED");
            }
            else
            {
                Console.WriteLine("FAILED");
            }
            Thread.Sleep(5000);
            driver.Quit();

        }
        [Test]
        public void Test6()
        {
            //Test case 06: Tạo mới kaizen nhập khoảng trắng ở text box nội dung
            Login();
            Thread.Sleep(5000);
            Access();
            Thread.Sleep(5000);
            // mở form nhập
            driver.FindElement(By.XPath("//*[@id='content']/section/ul[2]/li[1]/div/ul/li[6]/a/span[2]")).Click();
            Thread.Sleep(5000);
            //nhập khoảng trắng ở textbox tiêu đề và nhập dữ liệu ở textbox nội dung
            driver.FindElement(By.XPath("//*[@id='content']/div/div[2]/div/div/div[2]/div[3]/div/input")).SendKeys("aaa");
            driver.FindElement(By.TagName("textarea")).SendKeys("                        ");
            Thread.Sleep(5000);
            // Click nút gửi
            driver.FindElement(By.XPath("//*[@id='content']/div/div[3]/div/div[2]/button")).Click();
            Thread.Sleep(2000);
            string expected = "Vui lòng nhập tiêu đề và nội dung của Kaizen này!";
            string error = driver.FindElement(By.XPath("//*[@id='notify']/div/p")).Text;
            if (error == expected)
            {
                Console.WriteLine("PASSED");
            }
            else
            {
                Console.WriteLine("FAILED");
            }
            Thread.Sleep(5000);
            driver.Quit();

        }
        [Test]
        public void Test7()
        {
            //Test case 07: Xóa khoảng trắng khi Tạo mới kaizen
            Login();
            Thread.Sleep(5000);
            Access();
            Thread.Sleep(5000);
            // mở form nhập
            driver.FindElement(By.XPath("//*[@id='content']/section/ul[2]/li[1]/div/ul/li[6]/a/span[2]")).Click();
            Thread.Sleep(5000);
            //nhập khoảng trắng ở textbox tiêu đề và nhập dữ liệu ở textbox nội dung
            driver.FindElement(By.XPath("//*[@id='content']/div/div[2]/div/div/div[2]/div[3]/div/input")).SendKeys("              aaa                 ");
            driver.FindElement(By.TagName("textarea")).SendKeys("          bbbbbb              ");
            Thread.Sleep(5000);
            // Click nút gửi
            driver.FindElement(By.XPath("//*[@id='content']/div/div[3]/div/div[2]/button")).Click();
            Thread.Sleep(5000);
            driver.Quit();
        }
        [Test]
        public void Test8()
        {
            //Test case 08: Tạo mới kaizen khi nhập hợp lệ (không chọn loại phiếu)
            Login();
            Thread.Sleep(5000);
            Access();
            Thread.Sleep(5000);
            // mở form nhập
            driver.FindElement(By.XPath("//*[@id='content']/section/ul[2]/li[1]/div/ul/li[6]/a/span[2]")).Click();
            Thread.Sleep(5000);
            //nhập khoảng trắng ở textbox tiêu đề và nhập dữ liệu ở textbox nội dung
            driver.FindElement(By.XPath("//*[@id='content']/div/div[2]/div/div/div[2]/div[3]/div/input")).SendKeys("aaa");
            driver.FindElement(By.TagName("textarea")).SendKeys("bbbbbb");
            Thread.Sleep(5000);
            // Click nút gửi
            driver.FindElement(By.XPath("//*[@id='content']/div/div[3]/div/div[2]/button")).Click();
            Thread.Sleep(5000);
            driver.Quit();
        }
        [Test]
        public void Test9()
        {
            //Test case 09: Tạo mới kaizen khi nhập hợp lệ (chọn loại phiếu)
            Login();
            Thread.Sleep(5000);
            Access();
            Thread.Sleep(5000);
            // mở form nhập
            driver.FindElement(By.XPath("//*[@id='content']/section/ul[2]/li[1]/div/ul/li[6]/a/span[2]")).Click();
            Thread.Sleep(5000);
            // chọn loại phiếu
            driver.FindElement(By.XPath("//*[@id='content']/div/div[2]/div/div/div[2]/div[2]/select")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//*[@id='content']/div/div[2]/div/div/div[2]/div[2]/select/option[2]")).Click();
            Thread.Sleep(5000);
            //nhập khoảng trắng ở textbox tiêu đề và nhập dữ liệu ở textbox nội dung
            driver.FindElement(By.XPath("//*[@id='content']/div/div[2]/div/div/div[2]/div[3]/div/input")).SendKeys("abcd");
            driver.FindElement(By.TagName("textarea")).SendKeys("bbbbbb");
            Thread.Sleep(5000);
            // Click nút gửi
            driver.FindElement(By.XPath("//*[@id='content']/div/div[3]/div/div[2]/button")).Click();
            Thread.Sleep(5000);
            driver.Quit();
        }
        [Test]
        public void Test10()
        {
            //Test case 09: Kiểm tra số lượng like 
            Login();
            Thread.Sleep(5000);
            Access();
            Thread.Sleep(5000);
            //số lượng like trước khi like
            string number_before = driver.FindElement(By.XPath("//*[@id='content']/section/ul[2]/li[2]/div[1]/article/div/div[3]/ul/li[1]/a/span[2]")).Text;
            //click nút like
            driver.FindElement(By.XPath("//*[@id='content']/section/ul[2]/li[2]/div[1]/article/div/div[3]/ul/li[1]/a/span[1]/i")).Click();
            Thread.Sleep(5000);
            //số lượng like sau khi like
            string number_after = driver.FindElement(By.XPath("//*[@id='content']/section/ul[2]/li[2]/div[1]/article/div/div[3]/ul/li[1]/a/span[2]")).Text;
            if (int.TryParse(number_before, out int beforeValue) && int.TryParse(number_after, out int afterValue))
            {
                if (afterValue == beforeValue + 1)
                {
                    Console.WriteLine("PASSED");
                }
                else
                {
                    Console.WriteLine("FAILED: Không tăng giá trị đúng như mong đợi.");
                }
            }
            else
            {
                Console.WriteLine("FAILED: Không thể chuyển đổi thành số nguyên.");
            }
            Thread.Sleep(5000);
            driver.Quit();
        }
        [Test]
        public void Test11()
        {
            //Test case 10: Kiểm tra số lượng dislike 
            Login();
            Thread.Sleep(5000);
            Access();
            Thread.Sleep(5000);
            string number_before = driver.FindElement(By.XPath("//*[@id='content']/section/ul[2]/li[2]/div[1]/article/div/div[3]/ul/li[2]/a/span[2]")).Text;
            driver.FindElement(By.XPath("//*[@id='content']/section/ul[2]/li[2]/div[1]/article/div/div[3]/ul/li[2]/a/span[1]")).Click();
            Thread.Sleep(5000);
            string number_after = driver.FindElement(By.XPath("//*[@id='content']/section/ul[2]/li[2]/div[1]/article/div/div[3]/ul/li[2]/a/span[2]")).Text;
            if (int.TryParse(number_before, out int beforeValue) && int.TryParse(number_after, out int afterValue))
            {
                if (afterValue == beforeValue + 1)
                {
                    Console.WriteLine("PASSED");
                }
                else
                {
                    Console.WriteLine("FAILED: Không tăng giá trị đúng như mong đợi.");
                }
            }
            else
            {
                Console.WriteLine("FAILED: Không thể chuyển đổi thành số nguyên.");
            }
            Thread.Sleep(5000);
            driver.Quit();
        }
        [Test]
        public void Test12()
        {
            //test case 11: Để trống bình luận
            Login();
            Thread.Sleep(5000);
            Access();
            Thread.Sleep(5000);
            //truy cập vào kaizen
            driver.FindElement(By.XPath("//*[@id='content']/section/ul[2]/li[2]/div[1]/article/div/ul/li[1]/a")).Click();
            Thread.Sleep(3000);
            //gửi bình luận
            driver.FindElement(By.XPath("//*[@id='content']/section/div/article/div/div[2]/div/div[2]/form/a/i")).Click();
            //driver.FindElement(By.TagName("textarea")).SendKeys("abcd");
            string expected = "Chưa nhập nội dung bình luận !";
            string error = driver.FindElement(By.XPath("//*[@id='notify']/div/p")).Text;
            if (expected == error)
            {
                Console.WriteLine("PASSED");
            }    
            else
            {
                Console.WriteLine("FAILED");
            }
            Thread.Sleep(5000);
            driver.Quit();
        }
        [Test]
        public void Test13()
        {
            //test case 12: nhập khoảng trắng ở textbox bình luận
            Login();
            Thread.Sleep(5000);
            Access();
            Thread.Sleep(5000);
            //truy cập vào kaizen
            driver.FindElement(By.XPath("//*[@id='content']/section/ul[2]/li[2]/div[1]/article/div/ul/li[1]/a")).Click();
            Thread.Sleep(3000);
            //nhập bình luận
            driver.FindElement(By.TagName("textarea")).SendKeys("                         ");
            Thread.Sleep(3000);
            //gửi bình luận;
            driver.FindElement(By.XPath("//*[@id='content']/section/div/article/div/div[2]/div/div[2]/form/a/i")).Click();
            Thread.Sleep(2000);
            //kiểm tra message lỗi
            string expected = "Chưa nhập nội dung bình luận !";
            string error = driver.FindElement(By.XPath("//*[@id='notify']/div/p")).Text;
            if (expected == error)
            {
                Console.WriteLine("PASSED");
            }
            else
            {
                Console.WriteLine("FAILED");
            }
            Thread.Sleep(5000);
            driver.Quit();
        }
        [Test]
        public void Test14()
        {
            //test case 13: tự động xóa khoảng trắng ở textbox bình luận
            Login();
            Thread.Sleep(5000);
            Access();
            Thread.Sleep(5000);
            //truy cập vào kaizen
            driver.FindElement(By.XPath("//*[@id='content']/section/ul[2]/li[2]/div[1]/article/div/ul/li[1]/a")).Click();
            Thread.Sleep(3000);
            //nhập bình luận
            driver.FindElement(By.TagName("textarea")).SendKeys("       abc      ");
            Thread.Sleep(3000);
            //gửi bình luận;
            driver.FindElement(By.XPath("//*[@id='content']/section/div/article/div/div[2]/div/div[2]/form/a/i")).Click();
            Thread.Sleep(5000);
            driver.Quit();
        }
        [Test]
        public void Test15()
        {
            //test case 14: Bình luận thành công và kiểm tra số lượng bình luận 
            Login();
            Thread.Sleep(5000);
            Access();
            Thread.Sleep(5000);
            //truy cập vào kaizen
            driver.FindElement(By.XPath("//*[@id='content']/section/ul[2]/li[2]/div[1]/article/div/ul/li[1]/a")).Click();
            Thread.Sleep(3000);
            //số lượng bình luận trước khi thêm mới
            string number_before = driver.FindElement(By.XPath("//*[@id='content']/section/div/article/div/div[1]/div[1]/ul/li[3]/a/span[2]")).Text;
            number_before = number_before.Replace(" bình luận", "");
            //nhập bình luận
            driver.FindElement(By.TagName("textarea")).SendKeys("123456");
            Thread.Sleep(3000);
            //gửi bình luận;
            driver.FindElement(By.XPath("//*[@id='content']/section/div/article/div/div[2]/div/div[2]/form/a/i")).Click();
            Thread.Sleep(5000);
            //số lượng bình luận sau khi thêm mới bình luận
            string number_after = driver.FindElement(By.XPath("//*[@id='content']/section/div/article/div/div[1]/div[1]/ul/li[3]/a/span[2]")).Text;
            number_after=number_after.Replace(" bình luận", "");
            Thread.Sleep(5000);
            if (int.TryParse(number_before, out int before) && int.TryParse(number_after, out int after))
            {
                if (after == before+1)
                {
                    Console.WriteLine("PASSED");
                }
                else
                {
                    Console.WriteLine("FAILED: số lượng không hợp lệ");
                } 
            }
            else
            {
                Console.WriteLine("Không thể chuyển đổi");
            }
            Thread.Sleep(5000);
            driver.Quit();
        }
        public void Login()
        {
            driver.FindElement(By.CssSelector("[type='email'][class='input']")).SendKeys("thuongnth.fastdo@gmail.com");
            driver.FindElement(By.CssSelector("[type='password'][class='input']")).SendKeys("fastdo@123");
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("#login > section.login_fr > div > form > button")).Click();
        }
        public void Access()
        {
            driver.FindElement(By.CssSelector("#login > section.login_fr > div > form > div:nth-child(3) > a")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//*[@id='content']/section/div[2]/div[3]/div[9]/a/div[2]/span")).Click();
        }
    }
}
