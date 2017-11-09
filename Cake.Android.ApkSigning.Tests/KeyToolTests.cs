using Cake.Core.IO;
using FluentAssertions;
using NSubstitute;
using NSubstituteAutoMocker;
using NUnit.Framework;

namespace Cake.Android.ApkSigning.Tests
{
    [TestFixture]
    public class KeyToolTests
    {
        [Test]
        public void TestCase()
        {
            var autoMocker = new NSubstituteAutoMocker<KeyTool>();

            teste.Should().Be("keytool");
        }
    }
}
