namespace Application;

public class CartDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Owner { get; set; }
    public string Price { get; set; }
    public DateTime ShoppingTime { get; set; }
}
