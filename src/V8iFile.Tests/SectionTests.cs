using NUnit.Framework;
using System;

namespace V8iFile.Tests
{
    public class SectionTests
    {

        private Section section;

        [SetUp]
        public void Setup()
        {
            section = new Section();
        }

        [Test]
        public void ToString_ReturnsCorrectlyFormatedData()
        {
            section.Name = "Test";
            section.AddParameter("Connect", "Srvr=\"Server\";Ref=\"Database\";");
            section.AddParameter("ParameterName", "ParameterValue");
            var actual = section.ToString();
            var expected = "[Test]" + Environment.NewLine + 
                "Connect=Srvr=\"Server\";Ref=\"Database\";" + Environment.NewLine +
                "ParameterName=ParameterValue";
            Assert.AreEqual(expected, actual);
        }
    }
}