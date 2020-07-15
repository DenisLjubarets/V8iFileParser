using NUnit.Framework;
using System;

namespace V8iParser.Tests
{
    public class V8iParserTests
    {
        private V8iParser v8iParser;
        private string mockData;

        [SetUp]
        public void Setup()
        {
            v8iParser = new V8iParser();
            mockData = "[Section1]" + Environment.NewLine +
                "Parameter1=Value1" + Environment.NewLine +
                "Parameter2=Value2" + Environment.NewLine +
                "Parameter3=Value3" + Environment.NewLine +
                "[Section2]" + Environment.NewLine +
                "Parameter1=Value1" + Environment.NewLine +
                "Parameter2=Value2" + Environment.NewLine +
                "[Section3]" + Environment.NewLine +
                "Parameter1=Value1" + Environment.NewLine +
                "Parameter2=Value2" + Environment.NewLine +
                "Parameter3=Value3" + Environment.NewLine +
                "Parameter4=Value4";

        }

        [Test]
        public void Parse_ParsesDataCorrectly()
        {
            var expected = mockData;
            var actual = v8iParser.Parse(mockData).ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}