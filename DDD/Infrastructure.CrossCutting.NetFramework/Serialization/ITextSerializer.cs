using System.IO;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework.Serialization
{
    /// <summary>
    /// Interface for serializes that can read/write an object graph to a stream.
    /// </summary>
    public interface ITextSerializer
    {
        /// <summary>
        /// Serializes an object graph to a text reader.
        /// </summary>
        void Serialize(TextWriter writer, object graph);

        /// <summary>
        /// De-serializes an object graph from the specified text reader.
        /// </summary>
        object Deserialize(TextReader reader);
    }
}
