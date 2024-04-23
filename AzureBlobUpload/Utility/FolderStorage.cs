using Azure.Storage.Blobs;
using AzureBlobUpload.Repository;

namespace AzureBlobUpload.Utility
{
    public class FolderStorage : IStorage
    {
        
        private readonly BlobServiceClient _blobServiceClient;
        public FolderStorage(BlobServiceClient blobServiceClient)
        {
            
            _blobServiceClient = blobServiceClient;

        }
        
        public void uploadfolder(IEnumerable<IFormFile> files,string foldername, string containername)
        {

        
            var containerClient = _blobServiceClient.GetBlobContainerClient(containername);

            foreach (var file in files)
            {
                string fileName_new = Guid.NewGuid().ToString();
                var extension = Path.GetExtension(file.FileName);
                var fname = foldername + "/" + fileName_new + extension;
                BlobClient blobClient = containerClient.GetBlobClient(fname);

                var fileStream = file.OpenReadStream();
                blobClient.Upload(fileStream, true);
                fileStream.Close();
            }

        }
    }
}
