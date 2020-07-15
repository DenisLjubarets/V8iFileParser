using NUnit.Framework;
using System;

namespace V8iFile.Tests
{
    public class V8iDataTests
    {
        private V8iData v8iData;
        private Section section1;
        private Section section2;

        [SetUp]
        public void Setup()
        {
            v8iData = new V8iData();

            section1 = new Section();
            section1.Name = "First Section";
            section1.AddParameter("Parameter1Name", "Parameter1Value");
            section1.AddParameter("Parameter2Name", "Parameter2Value");
            section1.AddParameter("Parameter3Name", "Parameter3Value");

            section2 = new Section();
            section2.Name = "Second Section";
            section2.AddParameter("Parameter1Name", "Parameter1Value");
            section2.AddParameter("Parameter2Name", "Parameter2Value");
        }

        [Test]
        public void ToString_ReturnsCorrectlyFormatedData()
        {
            // Adding in reverse
            v8iData.AddSection(section2);
            v8iData.AddSection(section1);

            var actual = v8iData.ToString();

            // Expected is sorted by Name
            var expected = "[First Section]" + Environment.NewLine +
                "Parameter1Name=Parameter1Value" + Environment.NewLine +
                "Parameter2Name=Parameter2Value" + Environment.NewLine +
                "Parameter3Name=Parameter3Value" + Environment.NewLine +
                "[Second Section]" + Environment.NewLine +
                "Parameter1Name=Parameter1Value" + Environment.NewLine +
                "Parameter2Name=Parameter2Value";

            Assert.AreEqual(expected, actual);
        }
    }
}