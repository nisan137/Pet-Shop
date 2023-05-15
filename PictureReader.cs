namespace PetShopApp.Services
{
    public class PictureReader : IPictureReader
    {
        private readonly IWebHostEnvironment _env;

        public PictureReader(IWebHostEnvironment env)
        {
            _env = env;
        }

        public string FileReader(IFormFile file)
        {
            string filePath = _env.WebRootPath + "/images/" + file.FileName;
            if (!System.IO.File.Exists(filePath))
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                    file.CopyTo(stream);
            }
            return file.FileName;
        }
    }
}
