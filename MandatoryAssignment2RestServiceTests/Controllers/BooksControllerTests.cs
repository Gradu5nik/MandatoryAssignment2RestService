using Microsoft.VisualStudio.TestTools.UnitTesting;
using MandatoryAssignment2RestService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MandatoryAssigment1Library;
using Microsoft.AspNetCore.Mvc;

namespace MandatoryAssignment2RestService.Controllers.Tests
{
    [TestClass()]
    public class BooksControllerTests
    {
        

        [TestMethod()]
        public void GetTest1()
        {
            BooksController r = new BooksController();
            ActionResult<Book> result = r.Get("978-0441013593");
            Assert.AreEqual("Dune", result.Value.Title);
            
        }

        [TestMethod()]
        public void PostTest()
        {
            BooksController r = new BooksController();
            Book u = new Book() { Title = "Duna", Author = "Frank Herbert", NoOfPages = 100, ISBN13 = "978-0441013594" };
            r.Post(u);
            string result = r.Get("978-0441013594").Value.Title;
            Assert.AreEqual("Duna", result);
        }

        [TestMethod()]
        public void PutTest()
        {
            BooksController r = new BooksController();
            Book u = new Book() { Title = "Duna", Author = "Frank Herbert", NoOfPages = 100, ISBN13 = "978-0441013593" };
            r.Put(u.ISBN13,u);
            int page = r.Get("978-0441013593").Value.NoOfPages;
            Assert.AreEqual(100,page);
            string result = r.Get("978-0441013593").Value.Title;
            Assert.AreEqual("Duna",result);
        }

        
    }
}