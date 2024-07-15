using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Comment {
    public class UpdateCommentRequestDto {
        [Required]
        [MinLength(5, ErrorMessage = "Title must be 5 characters 3999")]
        [MaxLength(280, ErrorMessage = "Title cannot be over 280 characters 3999")]
        public string Title {get; set;} = string.Empty;
        
        [Required]
        [MinLength(5, ErrorMessage = "Title must be 5 characters 3999")]
        [MaxLength(280, ErrorMessage = "Title cannot be over 280 characters 3999")]
        public string Content {get; set;} = string.Empty;
    }
}