using System;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace PackageGraphVisualizer
{
    public class Config
    {
        public string PackageName { get; set; } = string.Empty;
        public string RepositoryPath { get; set; } = string.Empty;
        public RepositoryMode RepositoryMode { get; set; }
        public string OutputImage { get; set; } = string.Empty;
        public string FilterSubstring { get; set; } = string.Empty;
    }

    public enum RepositoryMode
    {
        Online,
        Offline
    }

    class Program
    {
        static void Main(string[] args)
        {
            string configPath = "config.yaml";

            try
            {
                if (!File.Exists(configPath))
                    throw new FileNotFoundException($"Configuration file not found: {configPath}");

                var yamlContent = File.ReadAllText(configPath);
                var deserializer = new DeserializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .Build();

                var config = deserializer.Deserialize<Config>(yamlContent);
                ValidateConfig(config);

                Console.WriteLine("Configuration parameters:");
                Console.WriteLine($"PackageName: {config.PackageName}");
                Console.WriteLine($"RepositoryPath: {config.RepositoryPath}");
                Console.WriteLine($"RepositoryMode: {config.RepositoryMode}");
                Console.WriteLine($"OutputImage: {config.OutputImage}");
                Console.WriteLine($"FilterSubstring: {config.FilterSubstring}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
                Environment.Exit(1);
            }
        }

        static void ValidateConfig(Config config)
        {
            if (string.IsNullOrWhiteSpace(config.PackageName))
                throw new ArgumentException("PackageName cannot be empty");

            if (string.IsNullOrWhiteSpace(config.RepositoryPath))
                throw new ArgumentException("RepositoryPath cannot be empty");

            if (string.IsNullOrWhiteSpace(config.OutputImage))
                throw new ArgumentException("OutputImage cannot be empty");

            if (!Enum.IsDefined(typeof(RepositoryMode), config.RepositoryMode))
                throw new ArgumentException($"Invalid RepositoryMode value: {config.RepositoryMode}");
        }
    }
}
