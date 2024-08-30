namespace WebAPICoreTask1.DTOS
{
    public class ProductResponseDTO
    {
        public string? ProductName { get; set; }

        public string? Description { get; set; }

        public decimal? Price { get; set; }

        public string? ProductImage { get; set; }

        public CategoryResponseDTO? CategoryDTO { get; set; }
    }

    public class CategoryResponseDTO
    {
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }

        public string? CategoryImage { get; set; }

    }
}
