namespace Order.Host.Models.Response;

public class AddItemResponse<T>
{
    public T Id { get; set; } = default(T) !;
}