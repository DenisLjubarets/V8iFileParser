using System;
using System.Collections.Generic;
using System.Text;

namespace V8iFile
{
    /// <summary>
    /// Section represents an infobase in v8i file. It is called a 'Section' and not a 'Infobase' 
    /// because this is how 1C refers to this piece of v8i file in their documentation.
    /// </summary>
    public class Section : IEquatable<Section>, IComparable<Section>
    {
        /// <summary>
        /// 
        /// The name is always on the top of a section. In v8i files with multiple 
        /// sections the name denotes a start of a section. The name is always contained in square brackets.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Parameters always come after the section name and are devided by '=' character.
        /// </summary>
        public Dictionary<string, string> Parameters { get; private set; } = new Dictionary<string, string>();

        /// <summary>
        /// Adds parameter to the section.
        /// </summary>
        /// <param name="key">Paramter key</param>
        /// <param name="value">Parameter value</param>
        public void AddParameter(string key, string value)
        {
            Parameters.Add(key, value);
        }

        /// <summary>
        /// Adds parameter to the section.
        /// </summary>
        /// <param name="parameter">Parameter to be added</param>
        public void AddParameter(Parameter parameter)
        {
            AddParameter(parameter.Key, parameter.Value);
        }

        /// <summary>
        /// Get a list of parameters.
        /// </summary>
        /// <returns>List of parameters</returns>
        public List<Parameter> GetParameters()
        {
            var list = new List<Parameter>();
            foreach (var key in Parameters.Keys)
            {
                list.Add(new Parameter
                {
                    Key = key,
                    Value = Parameters[key]
                });
            }
            return list;
        }

        /// <summary>
        /// Gets <see cref="Parameter"/> by its key name.
        /// </summary>
        /// <param name="key">Parameter key</param>
        /// <returns>Parameter that contains a given key</returns>
        public Parameter GetParameter(string key)
        {
            return new Parameter
            {
                Key = key,
                Value = Parameters[key]
            };
        }

        /// <summary>
        /// Gets parameter value that corresponds to a given key.
        /// </summary>
        /// <param name="key">Key to search a corresponding value</param>
        /// <returns>Value of a parameter</returns>
        public string GetValue(string key)
        {
            return Parameters[key];
        }

        /// <summary>
        /// Checks if the section is empty.
        /// </summary>
        /// <returns>Returns <see langword="true"/> if the Name is <see langword="null"/> 
        /// or parameters list is empty</returns>
        public bool IsEmpty()
        {
            return Name == null || Parameters.Count == 0;
        }

        /// <summary>
        /// Checks for equality. Sections are considered to be equal if their names are equal.
        /// </summary>
        /// <param name="other">Section to compare to</param>
        /// <returns><see langword="true"/> if sections are equal</returns>
        public bool Equals(Section other)
        {
            return Name.Equals(other.Name);
        }

        /// <summary>
        /// Compares names of sections for sorting purposes.
        /// </summary>
        /// <param name="other">Section to compare to</param>
        /// <returns></returns>
        public int CompareTo(Section other)
        {
            return Name.CompareTo(other.Name);
        }

        /// <summary>
        /// Represents a section in common to v8i files format.
        /// </summary>
        /// <returns>Formatted section</returns>
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"[{Name}]");
            foreach (var param in GetParameters())
            {
                builder.AppendLine($"{param}");
            }
            return builder.ToString().Trim();
        }
    }
}
