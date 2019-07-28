using System;
using System.Threading.Tasks;
using BV.PACS.WEB.Client.Services.Context;
using BV.PACS.WEB.Client.Shared;
using BV.PACS.WEB.Shared.Models;
using NUnit.Framework;

namespace BV.PACS.WEB.Tests.Client.Services.Context
{
    public class PanelsTests
    {
        [SetUp]
        public void Setup()
        {
        }

      

        [Test]
        public void StateServiceTest()
        {
            ApplicationContextService service = new ApplicationContextService();
            var currentPageState = service.CurrentApplicationContext;
            Assert.IsNull(currentPageState);
            Assert.Pass();
        }
    }
}