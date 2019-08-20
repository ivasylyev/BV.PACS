//using System;
//using System.Threading.Tasks;
//using BV.PACS.WEB.Client.SearchPanels;
//using BV.PACS.WEB.Shared.Models;
//using NUnit.Framework;
//
//namespace BV.PACS.WEB.Tests
//{
//    public class PanelsTests
//    {
//        [SetUp]
//        public void Setup()
//        {
//        }
//
//        private class AliquotSearchPanelTest : AliquotSearchPanelCode
//        {
//            public TemplateLookupItem[] TemplatesTest => Templates;
//
//            public void OnInitializedAsyncTest()
//            {
//                OnInitializedAsync().Wait();
//            }
//        }
//
//        [Test]
//        public void AliquotSearchPanelCodeTest()
//        {
//            var panel = new AliquotSearchPanelTest();
//
//            panel.OnInitializedAsyncTest();
//            Assert.IsNotEmpty(panel.TemplatesTest);
//            Assert.Pass();
//        }
//    }
//}