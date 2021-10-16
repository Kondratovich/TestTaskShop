using System.ComponentModel.DataAnnotations;

namespace TestTaskShop.ViewModels
{
    public class ProductFormViewModel
    {
        public int StoreId { get; set; }
        public string ActionName { get; set; }
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Name not specified")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name length must be between 3 and 30 characters")]
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
    }
}
