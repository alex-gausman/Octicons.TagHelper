using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Octicons.TagHelper
{
    internal sealed class Octicons
    {
        private static readonly Lazy<Octicons> _octicons =
            new Lazy<Octicons>(() => new Octicons());

        public static Octicons Instance { get; } = _octicons.Value;
        private string _dataFile = "lib.data.json";
        private string _spriteFile = "lib.sprite.octicons.svg";
        private Dictionary<string, Octicon> _octiconSymbols;
        public string SpriteSheet { get; }

        private Octicons()
        {
            var data = GetEmbeddedResource(_dataFile);
            SpriteSheet = GetEmbeddedResource(_spriteFile);
            _octiconSymbols = JsonConvert.DeserializeObject<Dictionary<string, Octicon>>(data);
        }

        private string GetEmbeddedResource(string file)
        {
            var namespaceName = typeof(Octicons).Namespace;
            var assembly = typeof(Octicons).GetTypeInfo().Assembly;
            string content;

            using (var resourceStream = assembly.GetManifestResourceStream($"{namespaceName}.{file}"))
            using (var readerStream = new StreamReader(resourceStream))
            {
                content = readerStream.ReadToEnd();
            }

            return content;
        }

        public Octicon Symbol(string name) => _octiconSymbols[name];
    }
}
