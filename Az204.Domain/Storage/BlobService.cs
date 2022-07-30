using Azure.Storage.Blobs;

namespace Az204.Domain.Storage
{
    public class BlobService
    {
        readonly BlobServiceClient _blobClient;

        public BlobService(string storageConfigKey)
        {
            _blobClient = new BlobServiceClient(storageConfigKey);
        }

        public bool Exists(string container, string name)
        {
            try
            {
                var containerReference = _blobClient.GetBlobContainerClient(container);
                var blobReference = containerReference.GetBlobClient(name);

                return blobReference.Exists();
            }
            catch (Exception ex) { throw ex; }
        }

        public byte[] GetBytes(string container, string name)
        {
            try
            {
                var containerReference = _blobClient.GetBlobContainerClient(container);
                var blobReference = containerReference.GetBlobClient(name);

                if (!blobReference.Exists()) return null;

                using var ms = new MemoryStream();
                blobReference.DownloadTo(ms);
                return ms.ToArray();
            }
            catch (Exception ex) { throw ex; }
        }

        public bool Upload(string container, string name, byte[] content)
        {
            try
            {
                var containerReference = _blobClient.GetBlobContainerClient(container);
                var blobReference = containerReference.GetBlobClient(name);
                containerReference.CreateIfNotExists();

                using var ms = new MemoryStream(content);
                blobReference.Upload(ms);

                return blobReference.Exists();
            }
            catch (Exception ex) { throw ex; }
        }
    }
}