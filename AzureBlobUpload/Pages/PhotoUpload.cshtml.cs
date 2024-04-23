using AzureBlobUpload.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AzureBlobUpload.Pages
{
    [BindProperties]
    public class PhotoUploadModel : PageModel
    {
        private readonly IStorage _storage;
        public PhotoUploadModel(IStorage storage)
        {
            _storage = storage; 
        }

        public IEnumerable<IFormFile>? files { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (files != null && files.Any())
            {
                foreach (var file in files)
                {
                    var extension = Path.GetExtension(file.FileName);
                    if (((extension == ".jpg") || (extension == ".jpeg") || (extension == ".png") || (extension == ".bmp") || (extension == ".heic") || (extension == ".heif")) == false)
                    {

                        ModelState.AddModelError(string.Empty, "Only .jpg or .png files accepted");
                        return Page();
                    }
                    var filesize = file.Length;

                    if (filesize > 3000000)
                    {

                        ModelState.AddModelError(string.Empty, "Image size has to be under 3MB");
                        return Page();
                    }
                }
            }

                if (ModelState.IsValid)
                {

                    
                    if (files != null && files.Any())
                    {

                //    _storage.uploadfolder(files,"Your desired folder name", "Your Azure Storage Container Name"). Create a container with this name in your Azure storage Account. 

                    _storage.uploadfolder(files, "uploadfolder", "uploadcontainer");
                    TempData["success"] = "Photo uploaded";

                }
                    


                    return Page();

                }
                return Page();

            }
        
    }
}
