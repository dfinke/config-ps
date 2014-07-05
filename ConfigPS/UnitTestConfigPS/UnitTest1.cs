using System;
using ConfigPS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestConfigPS
{
    [TestClass]
    public class UnitTest1
    {
        private dynamic global;

        [TestInitialize]
        public void Setup()
        {
            global = new Global();
        }

        [TestMethod]
        public void TestCreate()
        {
            Assert.IsNotNull(global);
        }

        [TestMethod]
        public void TestNoConfig()
        {
            var t = global.test;
            Assert.IsNull(t);
        }

        [TestMethod]
        public void TestWrongNamedConfigFile()
        {
            const string configFile = @"c:\test\notthere";

            dynamic g = new Global(configFile);
            var t = g.test;
            Assert.IsNull(t);
        }

        [TestMethod]
        public void TestEmptyConfigFile()
        {
            var configFile = System.IO.Directory.GetCurrentDirectory() + @"\..\..\EmptyPSConfig.dll.ps1";
            dynamic g = new Global(configFile);
            var t = g.test;
            Assert.IsNull(t);
        }

        [TestMethod]
        public void TestConfig()
        {
            var configFile = System.IO.Directory.GetCurrentDirectory() + @"\..\..\UnitTestConfigPS.dll.ps1";

            dynamic g = new Global(configFile);
            var t = g.test;
            Assert.AreEqual(42, t);
        }

        [TestMethod]
        public void TestUriConfig()
        {
            var configFile = System.IO.Directory.GetCurrentDirectory() + @"\..\..\UnitTestConfigPS.dll.ps1";

            dynamic g = new Global(configFile);
            
            var t = g.uri;
            
            var uri = new Uri(@"http://www.microsoft.com");

            Assert.AreEqual(uri.AbsolutePath, t.AbsolutePath);
            Assert.AreEqual(uri.DnsSafeHost, t.DnsSafeHost);
        }
    }
}
