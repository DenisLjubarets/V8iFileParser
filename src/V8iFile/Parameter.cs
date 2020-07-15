using System;
using System.Collections.Generic;

namespace V8iFile
{
    /// <summary>
    /// Parameter class represents a parameter in v8i files. 
    /// Parameters are key-value pairs devided by '=' character.
    /// </summary>
    public class Parameter : IEquatable<Parameter>
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Parameter);
        }

        public bool Equals(Parameter other)
        {
            return other != null &&
                   this.Key == other.Key;
        }

        public override int GetHashCode()
        {
            return 990326508 + EqualityComparer<string>.Default.GetHashCode(this.Key);
        }

        public override string ToString()
        {
            return $@"{this.Key}={this.Value}";
        }
    }
}
