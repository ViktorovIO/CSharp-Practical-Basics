using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAccounting
{
    public class AccountingModel : ModelBase
    {
        //double Price(должно быть не меньше 0)
        //int NightsCount(должно быть больше 0)
        //double Discount(скидка.Ограничений нет)
        //double Total(должно быть больше нуля
        private double price;
        private int nightsCount;
        private double discount;
        private double total;

        public double Price
        {
            get => price;
            set
            {
                if (value < 0)
                    throw new ArgumentException();
                price = value;
                Notify(nameof(Price));
                Total = Price * NightsCount * (1 - Discount / 100);

            }
        }

        public int NightsCount
        {
            get => nightsCount;
            set
            {
                if (value <= 0)
                    throw new ArgumentException();
                nightsCount = value;
                Notify(nameof(NightsCount));
                Total = Price * NightsCount * (1 - Discount / 100);

            }
        }

        public double Discount
        {
            get => discount;
            set
            {
                if (Math.Abs(discount - value) >= 1e-5)
                {
                    discount = value;
                    Notify(nameof(Discount));
                    Total = Price * NightsCount * (1 - Discount / 100);
                }

            }
        }

        public double Total
        {
            get => total;
            set
            {
                if (Math.Abs(total - value) >= 1e-5)
                {
                    if (value <= 0)
                        throw new ArgumentException();
                    total = value;
                    Notify(nameof(Total));
                    Discount = 100 * (1 - Total / (Price * NightsCount));
                }
            }
        }
    }
}
