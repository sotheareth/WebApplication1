using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApplication1.Contract;
using WebApplication1.Model;

namespace WebApplication1.Service
{
    public class OrderDiscountService : IDiscount
    {
        private readonly Discount _discount;
        private readonly ILogger<OrderDiscountService> _logger;
        private static readonly OrderDiscountService _orderDiscountService = new OrderDiscountService();

        public OrderDiscountService() { }
        public static OrderDiscountService GetInstance() => _orderDiscountService;

        public OrderDiscountService(ILogger<OrderDiscountService> logger)
        {
            this._logger = logger;
            _logger.LogInformation("xxxxxxxxxxxxxxxxTerst");
        }

        public OrderDiscountService(Discount discount)
        {
            _discount = discount;
        }

        public double ProcessDiscount(Order order)
        {
            double discount = 0.0;
            double totalBill = order.Quantity * order.Price;

            if (order.Quantity >= _discount.MinimumItemCount && totalBill >= _discount.MinimumBillAmount)
            {
                discount = (totalBill * _discount.Percentage) / 100.0;
            }

            return discount;
        }
        
    }
}
