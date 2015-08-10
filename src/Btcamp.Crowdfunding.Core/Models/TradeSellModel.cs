using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btcamp.Crowdfunding.Core.Models
{
    public class TradingModel
    {
        public TradingModel()
        {

        }
        public TradingModel(int orderId, DateTime tradeTime, decimal price, double weight, double profit)
        {
            this.OrderID = orderId;
            this.TradeTime = tradeTime.ToString("MM.dd hh:mm");
            this.Price = price;
            this.Weight = weight;
            this.Profit = profit;
        }
        public int OrderID { get; set; }
        public string TradeTime { get; set; }
        public decimal Price { get; set; }
        public double Weight { get; set; }

        public double Profit { get; set; }
    }
}
