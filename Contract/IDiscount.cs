using WebApplication1.Model;

namespace WebApplication1.Contract
{
    public interface IDiscount
    {
        double ProcessDiscount(Order order);
    }
}
