using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Android.ApkSigning
{
    public class KeyTool : Tool<KeyToolSettings>
    {
        readonly IFileSystem fileSystem;
        readonly ICakeEnvironment environment;
        readonly IProcessRunner processRunner;
        readonly IGlobber globber;
        readonly IToolLocator tools;

        public KeyTool(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools) : base(fileSystem, environment, processRunner, tools)
        {
            this.processRunner = processRunner;
            this.environment = environment;
            this.fileSystem = fileSystem;
            this.tools = tools;
        }

        protected override IEnumerable<string> GetToolExecutableNames()
        {
            return new List<string>
            {
                "keytool",
                "keytool.exe"
            };
        }

        protected override string GetToolName() => "keytool";

        public string Teste()
        {
            return GetToolName();
        }
    }
}
