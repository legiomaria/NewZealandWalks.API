using System.ComponentModel.DataAnnotations;

namespace NewZealandWalks.API.DTO
{
    public class ImageUploadRequestDto
    {
        [Required]
        public IFormFile File { get; set; }

        [Required]
        public string? FileName { get; set; }

        public string? FIleDescription { get; set; }
    }
}
