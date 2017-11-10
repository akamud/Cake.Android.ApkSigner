using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Android.ApkSigning
{
    public class KeyTool : Tool<KeyToolSettings>
    {
        readonly IFileSystem _fileSystem;
        readonly ICakeEnvironment _environment;
        readonly IProcessRunner _processRunner;
        readonly IToolLocator _tools;

        public KeyTool(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools) : base(fileSystem, environment, processRunner, tools)
        {
			this._processRunner = processRunner;
            this._environment = environment;
            this._fileSystem = fileSystem;
            this._tools = tools;
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

        public void GenerateKeyPair(KeyToolSettings settings)
        {
            var argumentsBuilder = new ProcessArgumentBuilder();

            var toolPath = GetToolPathWithJavaHomeFallback(settings);

            if (toolPath == null || !_fileSystem.Exist(toolPath))
            {
                const string message = "{0}: Could not locate executable.";
                throw new CakeException(string.Format(CultureInfo.InvariantCulture, message, GetToolName()));
            }

            if (settings.ArgumentCustomization != null)
            {
                argumentsBuilder = settings.ArgumentCustomization(argumentsBuilder);
            }

            var ab = toolPath.MakeAbsolute(_environment);
            var a = new ProcessStartInfo(toolPath.MakeAbsolute(_environment).FullPath, argumentsBuilder.Render());
        }

        private FilePath GetToolPathWithJavaHomeFallback(KeyToolSettings settings)
        {
            var toolPath = GetToolPath(settings);

            if (toolPath == null || !_fileSystem.Exist(toolPath))
            {
                toolPath = GetToolPathFromJavaHome(settings);
            }

            return toolPath;
        }

        private FilePath GetToolPathFromJavaHome(KeyToolSettings settings)
        {
            FilePath toolPath = null;

            var javaPath = _environment.GetEnvironmentVariable("JAVA_HOME");
            var keytoolExecutablePath = $"{javaPath}/bin/";

            foreach (var keytoolExe in GetToolExecutableNames())
            {
                var fileExists = _fileSystem.Exist((FilePath)(keytoolExecutablePath + keytoolExe));
                if (fileExists)
                {
                    toolPath = keytoolExecutablePath + keytoolExe;
                }
            }

            return toolPath;
        }
    }
}
