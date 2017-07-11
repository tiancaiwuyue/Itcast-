using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buffet店
{
    abstract class AbstractPerson:SinglePriceInterface
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public int TempCount { get; set; }
        public int Age { get; set; }
        public double Price { get; set; }
    }
    class Adult : AbstractPerson
    {
        public Adult()
        {
            this.Name = "Adults";
            this.Count = 0;
            this.TempCount = 0;
            this.Age = 10;
            if (TimeNow.TimeLunchDinner=="Dinner")
            {
                this.Price = DinnerLunchPrice.AdultsPriceDinner;
            }
            else
            {
                this.Price = DinnerLunchPrice.AdultsPriceLunch;
            }
            
        }
    }
    class Child : AbstractPerson
    {
        public Child(int i)
        {
            this.Count = 0;
            this.TempCount = 0;
            this.Age = i;
            if (TimeNow.TimeLunchDinner == "Dinner")
            {
                switch (i)
                {
                    case 3: this.Price = DinnerLunchPrice.ChildThreePriceDinner;this.Name = "ChildThreeYO"; break;
                    case 6: this.Price = DinnerLunchPrice.ChildSixPriceDinner;this.Name = "ChildSixYO"; break;
                    case 8: this.Price = DinnerLunchPrice.ChildEightPriceDinner;this.Name = "ChildEightYO"; break;
                    default:break;
                }
            }
            else
            {
                switch (i)
                {
                    case 3: this.Price = DinnerLunchPrice.ChildThreePriceLunch; this.Name = "ChildThreeYO"; break;
                    case 6: this.Price = DinnerLunchPrice.ChildSixPriceLunch; this.Name = "ChildSixYO"; break;
                    case 8: this.Price = DinnerLunchPrice.ChildEightPriceLunch; this.Name = "ChildEightYO"; break;
                    default: break;
                }
            }
        }
    }
    class PublicOfficer : AbstractPerson
    {
        public PublicOfficer()
        {
            this.Name = "PublicOfficer";
            this.Count = 0;
            this.TempCount = 0;
            this.Age = 10;
            if (TimeNow.TimeLunchDinner == "Dinner")
            {
                this.Price = DinnerLunchPrice.PublicOfficerPriceDinner;
            }
            else
            {
                this.Price = DinnerLunchPrice.PublicOfficerPriceLunch;
            }
        }
    }
    class ElderPeople : AbstractPerson
    {
        public ElderPeople()
        {
            this.Name = "ElderPerson";
            this.Count = 0;
            this.TempCount = 0;
            this.Age = 60;
            if (TimeNow.TimeLunchDinner == "Dinner")
            {
                this.Price = DinnerLunchPrice.OldPersonPriceDinner;
            }
            else
            {
                this.Price = DinnerLunchPrice.OldPersonPriceLunch;
            }
        }
    }
    class Others : AbstractPerson
    {
        public Others()
        {
            this.Name = "Others";
            this.Count = 0;
            this.TempCount = 0;
            this.Age = 0;
            if (TimeNow.TimeLunchDinner == "Dinner")
            {
                this.Price = DinnerLunchPrice.OthersPriceDinner;
            }
            else
            {
                this.Price = DinnerLunchPrice.OthersPriceLunch;
            }
        }
    }
}
