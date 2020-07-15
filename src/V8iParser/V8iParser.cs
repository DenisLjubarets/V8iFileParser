using System;
using V8iFile;

namespace V8iParser
{
    /// <summary>
    /// Parses v8i data into collection of sections.
    /// </summary>
    public class V8iParser
    {
        /// <summary>
        /// Parse string into V8iData.
        /// </summary>
        /// <param name="data">String to be parsed</param>
        /// <returns>Collection of sections represented as V8iData</returns>
        public V8iData Parse(string data)
        {
            var lines = data.Split(Environment.NewLine);
            return Parse(lines);
        }

        /// <summary>
        /// Parses array of strings into V8iData.
        /// </summary>
        /// <param name="lines">Array of strings that represent lines of data</param>
        /// <returns>Collection of sections represented as V8iData</returns>
        public V8iData Parse(string[] lines)
        {
            var v8iData = new V8iData();
            Section section = new Section();
            foreach (var line in lines)
            {
                if (ContainsSectionName(line))
                {
                    if (!section.IsEmpty())
                    {
                        v8iData.AddSection(section);
                        section = new Section();
                    }
                    section.Name = ParseSectionName(line);
                }
                else if (ContainsParameter(line))
                {
                    var parameter = ParseParameter(line);
                    section.AddParameter(parameter);
                }
            }
            v8iData.AddSection(section);
            return v8iData;
        }

        private string ParseSectionName(string line)
        {
            return line[1..^1];
        }

        private Parameter ParseParameter(string line)
        {
            var index = line.IndexOf('=');
            return new Parameter()
            {
                Key = line.Substring(0, index),
                Value = line.Substring(index + 1).Trim()
            };
        }

        private bool ContainsSectionName(string line)
        {
            return line.StartsWith('[') && line.EndsWith(']');
        }

        private bool ContainsParameter(string line)
        {
            return line.Contains('=');
        }
    }
}
