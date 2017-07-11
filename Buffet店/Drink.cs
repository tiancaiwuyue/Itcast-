using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buffet店
{
    class Drink:SinglePriceInterface
    {
        public int Count { get; set; }
        public double Price { get; set; }
        public string Name { set; get; }
        public Drink()
        {
            this.Name = "SoftDrink";
            this.Count = 0;
            this.Price = 1.5;
        }
    }
    class SpecialDrink : Drink
    {
        public SpecialDrink(string _name)
        {
            this.Name = _name;
            this.Count = 0;
            switch (_name)
            {
                case "Milk": this.Price = DinnerLunchPrice.Milk;break;
                case "Budweiser": this.Price = DinnerLunchPrice.Budweiser;break;
                case "BudLight": this.Price = DinnerLunchPrice.BudLight; break;
                case "MillerLite": this.Price = DinnerLunchPrice.MillerLite; break;
                case "CoorsLight": this.Price = DinnerLunchPrice.CoorsLight; break;
                case "Michelob": this.Price = DinnerLunchPrice.Michelob; break;
                case "Tsingtao": this.Price = DinnerLunchPrice.Tsingtao; break;
                case "Heineken": this.Price = DinnerLunchPrice.Heineken; break;
                case "Sapporo": this.Price = DinnerLunchPrice.Sapporo; break;
                case "Corona": this.Price = DinnerLunchPrice.Corona; break;
                case "TenHigh": this.Price = DinnerLunchPrice.TenHigh; break;
                case "Oolong": this.Price = DinnerLunchPrice.Oolong; break;
                case "OrangeJuice": this.Price = DinnerLunchPrice.OrangeJuice; break;
                case "AppleJuice": this.Price = DinnerLunchPrice.AppleJuice; break;
                case "Charonna": this.Price = DinnerLunchPrice.Charonna; break;
                case "Zinfandel": this.Price = DinnerLunchPrice.Zinfandel; break;
                case "Merlot": this.Price = DinnerLunchPrice.Merlot; break;
                case "PlumWine": this.Price = DinnerLunchPrice.PlumWine; break;
                case "Sake": this.Price = DinnerLunchPrice.Sake; break;
                default:break;
            }
        }
    }
}
