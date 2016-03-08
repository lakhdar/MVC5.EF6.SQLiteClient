using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using System.IO;
using System.Collections.Generic;
using Infrastructure.Dependances;
using SQLiteClient.Controllers;
using System.Web.Mvc;
using System.Linq;

namespace SQLiteClient.Tests.Controllers
{
    [TestClass]
    public class ProduitControllerTests
    {

        [TestInitialize]
        public void Setup()
        {
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse((TextWriter)new StringWriter()));
            HttpContext.Current.Items.Add("owin.Environment", new Dictionary<string, object>()
              {
                {
                  "owin.RequestBody",
                  null
                }
              });
            BootStrapper.Start();
        }

        [TestMethod]
        public void Index_Tests()
        {
            //Arrange
            ProduitController controller = DependanceFactory.Instance.ContainerActuel.Resoudre<ProduitController>();

            //Act
            ViewResult result =  controller.Index(0) as ViewResult;
            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(controller.ModelState.Count == 0);
            Assert.IsNotNull(result.Model);
        }
    }
}
