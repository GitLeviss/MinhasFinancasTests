using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MinhasFinancas.Tests.Api.Config
{
    public class ApiEnvironmentConfig
    {
        private static readonly Settings _config;

        static ApiEnvironmentConfig()
        {
            var env = Environment.GetEnvironmentVariable("env") ?? "appsettings";
            var path = Path.Combine(AppContext.BaseDirectory, $"{env}.json");

            if (!File.Exists(path))
                throw new FileNotFoundException($"Configuration file not found in path: {path}");

            var json = File.ReadAllText(path);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReadCommentHandling = JsonCommentHandling.Skip,
                AllowTrailingCommas = true
            };

            _config = JsonSerializer.Deserialize<Settings>(json, options) ?? throw new InvalidOperationException("Failed to deserialize configuration");
        }

        public static Settings Config => _config;
    }

    public class Settings
    {
        public BaseSettings Base { get; set; } = new();
    }

    public class BaseSettings
    {
        public UrlSettings Url { get; set; } = new();
    }

    public class UrlSettings
    {
        public string MinhasFinancas { get; set; } = string.Empty;
    }

}
