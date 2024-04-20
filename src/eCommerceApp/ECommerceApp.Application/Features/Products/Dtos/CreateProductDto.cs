namespace ECommerceApp.Application.Features.Products.Dtos;

public class CreateProductDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string ImagePath { get; set; }
    public string Description { get; set; }
    public string CategoryId { get; set; }
}