namespace SeamenResto.Models;

public class OrderEntity
{
    public int Id { get; set; }
    public string? Img {get; set;}
    public string? CustomerName {get; set;}
    public string? Order {get; set;}
    public int Quantity { get; set; }
    public int Price { get; set; }
    public int Total { get; set; }
}
