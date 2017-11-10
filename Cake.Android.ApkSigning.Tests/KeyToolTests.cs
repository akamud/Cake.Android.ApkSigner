using Cake.Core;
using Cake.Testing;
using NUnit.Framework;

namespace Cake.Android.ApkSigning.Tests
{
    [TestFixture]
    public class KeyToolTests
    {
        [Test]
        public void TestCase()
        {
            var autoMocker = new NSubstituteAutoMocker<KeyTool>(new FakeEnvironment(PlatformFamily.OSX));
            autoMocker.

            autoMocker.ClassUnderTest.GenerateKeyPair(new KeyToolSettings()
            {
                ToolPath = "keytool"
            });
        }
    }
}
