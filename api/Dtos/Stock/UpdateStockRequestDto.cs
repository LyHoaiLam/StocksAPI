using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Stock {
    public class UpdateStockRequestDto {
        [Required]
        [MaxLength(200, ErrorMessage = "Symbol cannot be over 200 characters 3999")]
        public string Symbol {get; set;} = string.Empty;
        [Required]
        [MaxLength(200, ErrorMessage = "Company Name cannot be over 200 characters 3999")]

        public string CompanyName {get; set;} = string.Empty;
        [Required]
        [Range(1, 1000000000)]

        public decimal Purchase {get; set;}
        [Required]
        [Range(0.001, 100)]

        public decimal LastDiv {get; set;}
        [Required]
        [MaxLength(200, ErrorMessage = "Industry cannot be over 200 characters 3999")]

        public string Industry {get; set;} = string.Empty;
        [Required]
        [Range(1, 5000000000)]

        public long MrketCap {get; set;}
    }
}