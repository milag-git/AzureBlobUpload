namespace AzureBlobUpload.Repository
{
    public interface IStorage
    {
        public void uploadfolder(IEnumerable<IFormFile> files,string foldername, string containername);
      //  public void downloadfolder(string localfolderpath, string foldername, string azurestoragecontainer);
      //  public void deletefolder(string azurestoragecontainer, string foldername);
     //   public List<string> getFilesFromFolder(string azurestoragecontainer, string foldername);
    }
}
