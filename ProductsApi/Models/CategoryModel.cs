using System.ComponentModel.DataAnnotations;

namespace ProductsApi.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O campo title é obrigatório")]
        [MaxLength(60, ErrorMessage = "O campo title deve conter até 60 caracteres")]
        [MinLength(3, ErrorMessage = "O campo title deve conter pelo menos 3 caracteres")]
        public string Title { get; set; }
    }
}