using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using VocaApi.Controllers;
using VocaApi.Models;

namespace apiTest
{
    public class ApiController
    {
        private const string Expected = "Hello World!";

        public static DbContextOptions<VocaContext> dbContextOptions { get; }
        //public static string connectionString = Write your database route
        Voca _voca;

        static ApiController()
        {
            dbContextOptions = new DbContextOptionsBuilder<VocaContext>()
                //.UseSqlServer(connectionString)
                .UseInMemoryDatabase("Voca")
                .Options;
        }



        [SetUp]
        public void Setup()
        {
            //var date1 = new DateTime(2020, 8, 4, 8, 30, 52);


            //_voca = new Voca
            //{
            //    Id = 17,
            //    Word = "vvv",
            //    Meaning = "vvv",
            //    EnrollmentDate = date1,
            //    EditDate = date1
            //};
            //var context = new VocaContext(dbContextOptions);
            //VocasController voc = new VocasController(context);

        }

        //[Test]
        //public void Test1()
        //{
        //    var result = _voca.IsPrime(1);
        //    Assert.IsFalse(result, "1 should not be prime");
        //}

        [Test]
        public void Normal_WhenCreateWord_ShouldReturn201AndValidValue()
        {
            var date1 = new DateTime(2020, 8, 4, 8, 30, 52);

            _voca = new Voca
            {
                Word = "vvv",
                Meaning = "vvv",
                EnrollmentDate = date1,
                EditDate = date1
            };
            var context = new VocaContext(dbContextOptions);
            VocasController voc = new VocasController(context);
            var data = voc.PostVoca(_voca);
            Console.WriteLine(_voca.Id);
            var response = data.Result as CreatedAtActionResult;
            var item = response.Value as Voca;
            Assert.AreEqual(StatusCodes.Status201Created, response.StatusCode);
            Assert.AreEqual("vvv", item.Word);
            Assert.AreEqual("vvv", item.Meaning);
        }

        [Test]
        public void Abnormal_WhenCreateWordWithoutWord_ShouldReturn400()
        {
            var date1 = new DateTime(2020, 8, 4, 8, 30, 52);

            _voca = new Voca
            {
                Word = null,
                Meaning = "df",
                EnrollmentDate = date1,
                EditDate = date1
            };
            var context = new VocaContext(dbContextOptions);
            VocasController voc = new VocasController(context);
            var data = voc.PostVoca(_voca);
            var response = data.Result as NotFoundResult;
            Assert.AreEqual(StatusCodes.Status404NotFound, response.StatusCode);

        }


        [Test]
        public void Abnormal_WhenEditWordAndIfThereIsNoIdReturnBadRequest()
        {
            var date1 = new DateTime(2020, 8, 4, 8, 30, 52);

            _voca = new Voca
            {
                Word = null,
                Meaning = "df",
                EnrollmentDate = date1,
                EditDate = date1
            };
            var context = new VocaContext(dbContextOptions);
            VocasController voc = new VocasController(context);
            var data = voc.PutVoca(2, _voca);
            var response = data.Result as BadRequestResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, response.StatusCode);
        }

        //[Test]
        //public void Abnormal_editWordt()
        //{
        //    var date1 = new DateTime(2020, 8, 4, 8, 30, 52);

        //    _voca = new Voca
        //    {
        //        Id = 17,
        //        Word = "apple",
        //        Meaning = "dddddf",
        //        EnrollmentDate = date1,
        //        EditDate = date1
        //    };
        //    var context = new VocaContext(dbContextOptions);
        //    VocasController voc = new VocasController(context);

        //    var data = voc.PutVoca(17, _voca);
        //    var response = data.Result as NoContentResult;
        //    Assert.AreEqual(StatusCodes.Status204NoContent, response.StatusCode);
        //}



    }
}