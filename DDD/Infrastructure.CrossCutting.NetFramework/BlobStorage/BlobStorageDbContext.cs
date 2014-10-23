using System.Data.Entity;
using System.IO;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework.BlobStorage
{
    public class BlobStorageDbContext : DbContext
    {
        private const string SchemaName = "BlobStorage";

        public BlobStorageDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public byte[] Find(string id)
        {
            var blob = this.Set<BlobEntity>().Find(id);
            if (blob == null)
                return null;

            return blob.Blob;
        }

        public void Save(string id, string contentType, byte[] blob)
        {
            var existing = Set<BlobEntity>().Find(id);
            var blobString = "";
            if (contentType == "text/plain")
            {
                Stream stream = null;
                try
                {
                    stream = new MemoryStream(blob);
                    using (var reader = new StreamReader(stream))
                    {
                        stream = null;
                        blobString = reader.ReadToEnd();
                    }
                }
                finally
                {
                    if (stream != null)
                        stream.Dispose();
                }
            }

            if (existing != null)
            {
                existing.Blob = blob;
                existing.BlobString = blobString;
            }
            else
            {
                Set<BlobEntity>().Add(new BlobEntity(id, contentType, blob, blobString));
            }

            SaveChanges();
        }

        public void Delete(string id)
        {
            var blob = this.Set<BlobEntity>().Find(id);
            if (blob == null)
                return;

            Set<BlobEntity>().Remove(blob);

            SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BlobEntity>().ToTable("Blobs", SchemaName);
        }
    }
}
