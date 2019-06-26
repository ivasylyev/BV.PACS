using System;
using System.Threading.Tasks;

using BV.PACS.Client.Shared;
using BV.PACS.Shared.Models;
using NUnit.Framework;

namespace BV.Pacs.Tests
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
            StateService service = new StateService();
            var currentPageState = service.CurrentPageState;
            Assert.IsNull(currentPageState);
            Assert.Pass();
        }
    }
}