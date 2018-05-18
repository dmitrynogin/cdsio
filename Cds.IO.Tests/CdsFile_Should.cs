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

            Assert.AreEqual(
                source.ToString(),
                copy.ToString());
        }

        TestFile Demo() => new TestFile
        {
            Type = "Test File", // META
            Version = 1.1m,
            Header = new TestHeader // SECTION
            {
                Comment = "Hello, world of IO",
                Details = new HeaderDetails // SUBSECTION
                {
                    Date = new DateTime(2018, 05, 17),
                    Location = "Duvall, WA"                    
                }
            },
            Soundings = new[]
            {
                new Sounding // REPEATABLE SECTION 1
                {
                    Name = "A001",
                    Data = new[] // TABLE
                    {
                        new TestData { Depth = 1, Tip = 2 },
                        new TestData { Depth = 2, Tip = 4 }
                    }
                },
                new Sounding // REPEATABLE SECTION 2
                {
                    Name = "A002",
                    Data = new[] // TABLE
                    {
                        new TestData { Depth = 10, Tip = 20 },
                        new TestData { Depth = 20, Tip = 40 }
                    }
                }
            }
        };
    }

    public class TestFile : CdsFile<TestFile>
    {
        [Field] public string Type { get; set; }
        [Field] public decimal Version { get; set; }
        [Section] public TestHeader Header { get; set; }
        [Section] public IList<Sounding> Soundings { get; set; }
    }

    public class TestHeader
    {
        [Field] public string Comment { get; set; }
        [Section] public HeaderDetails Details { get; set; }
    }

    public class HeaderDetails
    {
        [Field(Format = "yyyy-MM-dd")] public DateTime Date { get; set; }
        [Field] public string Location { get; set; }
    }

    public class Sounding
    {
        [Field] public string Name { get; set; }
        [Table] public IList<TestData> Data { get; set; }
    }

    public class TestData
    {
        [Field("Depth (m)", Format = "N4", Width = 10)]
        public double Depth { get; set; }

        [Field("Tip (bar)", Format = "N4", Width = 10)]
        public double Tip { get; set; }
    }
}
