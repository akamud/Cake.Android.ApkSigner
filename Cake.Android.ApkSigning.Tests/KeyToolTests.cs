using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Configuration;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Testing;
using NUnit.Framework;

namespace Cake.Android.ApkSigning.Tests
{
    [TestFixture]
    public class KeyToolTests
    {
        private KeyTool keyTool;

        [SetUp]
        private void SetUp()
        {
            var testsDir = new DirectoryPath(System.IO.Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory));
            var environment = new FakeEnvironment(PlatformFamily.OSX);
            var fileSystem = new FakeFileSystem(environment);
            var log = new FakeLog();
            var toolRepo = new ToolRepository(environment);
            var processRunner = new ProcessRunner(environment, log);
            var globber = new Globber(fileSystem, environment);
            var config = new CakeConfigurationProvider(fileSystem, environment)
                                .CreateConfiguration(testsDir, new Dictionary<string, string>());
            var toolResolutionStrategy = new ToolResolutionStrategy(fileSystem, environment, globber, config);
            var toolLocator = new ToolLocator(environment, toolRepo, toolResolutionStrategy);

            keyTool = new KeyTool(fileSystem, environment, processRunner, toolLocator);
        }

        [Test]
        public void TestCase()
        {
            var autoMocker = new NSubstituteAutoMocker<KeyTool>(new FakeEnvironment(PlatformFamily.OSX));

            autoMocker.ClassUnderTest.GenerateKeyPair(new KeyToolSettings()
            {
                ToolPath = "keytool"
            });
        }
    }
}
