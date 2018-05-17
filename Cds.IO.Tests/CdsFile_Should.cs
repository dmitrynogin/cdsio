using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cds.IO.Tests
{
    [TestClass]
    public class CdsFile_Should
    {
        [TestMethod]
        public void Persist()
        {
            var source = Demo();
            source.Save("test.txt");

            var copy = TestFile.Load("test.txt");

        }

        TestFile Demo() => new TestFile
        {
            Type = "Test File",
            Version = 1.1m,
            Header = new TestHeader
            {
                Comment = "Hello, world of IO",
                Details = new HeaderDetails
                {
                    Date = new DateTime(2018, 05, 17),
                    Location = "Duvall, WA"
                }
            },
            Data = new[]
            {
                new TestData { Depth = 1, Tip = 2 },
                new TestData { Depth = 2, Tip = 4 }
            }
        };
    }

    public class TestFile : CdsFile<TestFile>
    {
        [Field] public string Type { get; set; }
        [Field] public decimal Version { get; set; }
        [Section] public TestHeader Header { get; set; }
        [Section] public IList<TestData> Data { get; set; }
    }

    public class TestHeader
    {
        [Field] public string Comment { get; set; }
        [Section] public HeaderDetails Details { get; set; }
    }

    public class HeaderDetails
    {
        [Field] public DateTime Date { get; set; }
        [Field] public string Location { get; set; }     
    }

    public class TestData
    {
        [Field] public double Depth { get; set; }
        [Field] public double Tip { get; set; }
    }
}
