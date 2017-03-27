using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Octicons.TagHelper
{
    internal sealed class Octicons
    {
        private static readonly Lazy<Octicons> _octicons =
            new Lazy<Octicons>(() => new Octicons());

        /// <summary>
        /// The singleton instance of <see cref="Octicons"/>
        /// </summary>
        public static Octicons Instance { get; } = _octicons.Value;

        /// <summary>
        /// The svg sprite sheet that is referenced from an svg <use>
        /// </summary>
        public string SpriteSheet { get; }

        private string _dataFile = "lib.data.json";
        private string _spriteFile = "lib.sprite.octicons.svg";
        private Dictionary<string, Octicon> _octiconSymbols;

        private Octicons()
        {
            var data = GetEmbeddedResource(_dataFile);
            SpriteSheet = GetEmbeddedResource(_spriteFile);
            SpriteSheet = RemoveSvgTag(SpriteSheet);
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

        private string RemoveSvgTag(string content)
        {
            var match = Regex.Match(content, "<svg\\b[^>]*>(.*?)</svg>");
            if (match.Success && match.Groups.Count == 2)
            {
                return match.Groups[1].Value;
            }

            return content;
        }

        public static string SymbolName(OcticonSymbol symbol)
        {
            string name = Enum.GetName(symbol.GetType(), symbol);
            return Regex.Replace(name, @"([a-z])([A-Z])", "$1-$2").ToLower();
        }

        /// <summary>
        /// Use this method to get an <see cref="Octicon" /> symbol.
        /// </summary>
        /// <param name="name">The octicon name</param>
        /// <returns></returns>
        public Octicon Symbol(OcticonSymbol symbol) => _octiconSymbols[Octicons.SymbolName(symbol)];
    }
}
