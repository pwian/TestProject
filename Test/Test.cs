using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void RegexString()
        {
            var verbatimString = @"^[a-zA-Zа-яА-Я0-9\u0020-\u002F\u003A-\u0040\u005B-\u0060\u007B-\u007E\u2116]+$";
            var regulString = "^[a-zA-Zа-яА-Я0-9\u0020-\u002F\u003A-\u0040\u005B-\u0060\u007B-\u007E\u2116]+$";

            var sourceList = new []{ "\"", "\u0022",  @"""" , "\u002F", "ып", @"443987 РОССИЯ 77 Москва, ""Уличная"" 1 1, 1" };
            foreach (var source in sourceList)
            {
                Assert.IsTrue(Regex.IsMatch(source, regulString), $"source = '{source}', regular");
                Assert.IsTrue(Regex.IsMatch(source, verbatimString), $"source = '{source}', verbatim");
            }

            var badList = new[] {"443987 РОССИЯ 77 Москва, “Уличная” 1 1, 1"};
            foreach (var source in badList)
            {
                Assert.IsFalse(Regex.IsMatch(source, regulString), $"source = '{source}', regular");
                Assert.IsFalse(Regex.IsMatch(source, verbatimString), $"source = '{source}', verbatim");
            }
        }
    }
}
