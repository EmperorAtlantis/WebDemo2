﻿using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebDemo2;
using WebDemo2.Controllers;

namespace WebDemo2.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // 排列
            HomeController controller = new HomeController();

            // 操作
            ViewResult result = controller.Index() as ViewResult;

            // 断言
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
            
        }
    }
}
