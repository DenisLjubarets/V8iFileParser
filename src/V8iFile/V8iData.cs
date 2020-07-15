using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace V8iFile
{
    /// <summary>
    /// V8iData represents data contained in v8i file.
    /// V8iData is a collection of sections sorted by their names.
    /// </summary>
    public class V8iData
    {
        /// <summary>
        /// Sorted collection of sections.
        /// </summary>
        public SortedSet<Section> Sections { get; private set; } = new SortedSet<Section>();

        /// <summary>
        /// Adds a section to the collection.
        /// </summary>
        /// <param name="section">Section to be added</param>
        public void AddSection(Section section)
        {
            Sections.Add(section);
        }

        /// <summary>
        /// Gets a list of sections.
        /// </summary>
        /// <returns>List of sections</returns>
        public List<Section> GetSections()
        {
            return Sections.ToList();
        }

        /// <summary>
        /// Represents a collection in common to v8i files format.
        /// </summary>
        /// <returns>Formatted collection</returns>
        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach(var section in GetSections())
            {
                builder.AppendLine($"{section}");
            }
            return builder.ToString().Trim();
        }
    }
}
