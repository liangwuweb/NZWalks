using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MaxLength(3,ErrorMessage ="{0} has to be excatly {1} characters")]
        [MinLength(3, ErrorMessage = "{0} has to be excatly {1} characters")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage ="{0} has to be a maximum of {1} characters")]
        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
