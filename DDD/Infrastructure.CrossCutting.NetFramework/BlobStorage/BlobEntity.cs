namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework.BlobStorage
{
    public class BlobEntity
    {
        public BlobEntity(string id, string contentType, byte[] blob, string blobString)
        {
            Id = id;
            ContentType = contentType;
            Blob = blob;
            BlobString = blobString;
        }

        protected BlobEntity()
        {
        }

        public string Id { get; private set; }
        public string ContentType { get; set; }
        public byte[] Blob { get; set; }

        /// <devdoc>
        /// This property is only populated by the SQL implementation 
        /// if the content type of the saved blob is "text/plain".
        /// </devdoc>
        public string BlobString { get; set; }
    }
}
