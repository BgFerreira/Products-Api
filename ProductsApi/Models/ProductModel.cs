using System.ComponentModel.DataAnnotations;

namespace ProductsApi.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O campo title é obrigatório")]
        [MaxLength(60, ErrorMessage = "O campo title deve conter até 60 caracteres")]
        [MinLength(3, ErrorMessage = "O campo title deve conter pelo menos 3 caracteres")]
        public string Title { get; set; }
        
        [MaxLength(1024, ErrorMessage = "A descrição do produto pode conter até 1024 caracteres")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Campo preço é obrigatório")]
        [Range(0.01, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public double Price { get; set; }
        
        [Required(ErrorMessage = "Campo categoria é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Categoria inválida")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}