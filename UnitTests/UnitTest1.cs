using System.Runtime.InteropServices;

namespace UnitTests
{
    public class Tests
    {
        private WordFinder sut;

        [SetUp]
        public void Setup()
        {
            var matrix = new string[]
            {
                "abcdc",
                "fgwio",
                "chill",
                "pqnsd",
                "uvdxy"
            };
            sut = new WordFinder(matrix);
        }

        [Test]
        public void CanFindHorizontalFromRightToLeft()
        {
            
            var wordstream2 = new string[]
            {
                "chill",
                "codl",
                "snow"
            };
            
            IEnumerable<string> result = sut.Find(wordstream2);
            Assert.AreEqual("chill",result.First().ToString());
            
        }

        [Test]
        public void CanFindVerticalFromUpToBottom()
        {
            var wordstream2 = new string[]
            {
                "chlil",
                "cold",
                "snow"
            };

            IEnumerable<string> result = sut.Find(wordstream2);
            Assert.AreEqual("cold", result.First().ToString());

        }

        [Test]
        public void CannotFindIfWordIsNotFound()
        {
            var wordstream2 = new string[]
            {
                "chlil",
                "codl",
                "snow"
            };

            IEnumerable<string> result = sut.Find(wordstream2);
            Assert.AreEqual(0, result.Count());

        }
    }
}