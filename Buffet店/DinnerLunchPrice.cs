using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Reflection;

namespace Buffet店
{
    class DinnerLunchPrice
    {
        public static double AdultsPriceDinner;
        public static double AdultsPriceLunch;
        public static double PublicOfficerPriceDinner;
        public static double PublicOfficerPriceLunch;
        public static double OldPersonPriceDinner;
        public static double OldPersonPriceLunch;
        public static double ChildThreePriceDinner;
        public static double ChildThreePriceLunch;
        public static double ChildSixPriceDinner;
        public static double ChildSixPriceLunch;
        public static double ChildEightPriceDinner;
        public static double ChildEightPriceLunch;
        public static double OthersPriceDinner;
        public static double OthersPriceLunch;
        public static double Budweiser;
        public static double BudLight;
        public static double MillerLite;
        public static double CoorsLight;
        public static double Michelob;
        public static double Tsingtao;
        public static double Heineken;
        public static double Sapporo;
        public static double Corona;
        public static double TenHigh;
        public static double Oolong;
        public static double OrangeJuice;
        public static double AppleJuice;
        public static double Milk;
        public static double Charonna;
        public static double Zinfandel;
        public static double Merlot;
        public static double PlumWine;
        public static double Sake;
        public static double Tax;
        public static void LoadPrice()
        {
            string[] tmpPrice = File.ReadAllLines("Configuration.txt");
            for (int i = 0; i < tmpPrice.Length; i++)
            {
                string[] temArr = tmpPrice[i].Split('=');
                switch (temArr[0].Trim())
                {
                    case "Tax":Tax=double.Parse(temArr[1].Trim()); break;
                    case "AdultsPriceDinner":AdultsPriceDinner = double.Parse(temArr[1].Trim()); break;
                    case "AdultsPriceLunch": AdultsPriceLunch = double.Parse(temArr[1].Trim()); break;
                    case "PublicOfficerPriceDinner": PublicOfficerPriceDinner = AdultsPriceDinner * double.Parse(temArr[1].Trim()); break;
                    case "PublicOfficerPriceLunch": PublicOfficerPriceLunch = AdultsPriceLunch * double.Parse(temArr[1].Trim()); break;
                    case "OldPersonPriceDinner": OldPersonPriceDinner = AdultsPriceDinner * double.Parse(temArr[1].Trim()); break;
                    case "OldPersonPriceLunch": OldPersonPriceLunch = AdultsPriceLunch * double.Parse(temArr[1].Trim()); break;
                    case "ChildThreePriceDinner": ChildThreePriceDinner = double.Parse(temArr[1].Trim()); break;
                    case "ChildThreePriceLunch": ChildThreePriceLunch = double.Parse(temArr[1].Trim()); break;
                    case "ChildSixPriceDinner": ChildSixPriceDinner = double.Parse(temArr[1].Trim()); break;
                    case "ChildSixPriceLunch": ChildSixPriceLunch = double.Parse(temArr[1].Trim()); break;
                    case "ChildEightPriceDinner": ChildEightPriceDinner = double.Parse(temArr[1].Trim()); break;
                    case "ChildEightPriceLunch": ChildEightPriceLunch = double.Parse(temArr[1].Trim()); break;
                    case "OthersPriceDinner": OthersPriceDinner = double.Parse(temArr[1].Trim()); break;
                    case "OthersPriceLunch": OthersPriceLunch = double.Parse(temArr[1].Trim()); break;
                    case "Budweiser": Budweiser = double.Parse(temArr[1].Trim()); break;
                    case "BudLight": BudLight = double.Parse(temArr[1].Trim()); break;
                    case "MillerLite": MillerLite = double.Parse(temArr[1].Trim()); break;
                    case "CoorsLight": CoorsLight = double.Parse(temArr[1].Trim()); break;
                    case "Michelob": Michelob = double.Parse(temArr[1].Trim()); break;
                    case "Tsingtao": Tsingtao = double.Parse(temArr[1].Trim()); break;
                    case "Heineken": Heineken = double.Parse(temArr[1].Trim()); break;
                    case "Sapporo": Sapporo = double.Parse(temArr[1].Trim()); break;
                    case "Corona": Corona = double.Parse(temArr[1].Trim()); break;
                    case "TenHigh": TenHigh = double.Parse(temArr[1].Trim()); break;
                    case "Oolong": Oolong = double.Parse(temArr[1].Trim()); break;
                    case "OrangeJuice": OrangeJuice = double.Parse(temArr[1].Trim()); break;
                    case "AppleJuice": AppleJuice = double.Parse(temArr[1].Trim()); break;
                    case "Milk": Milk = double.Parse(temArr[1].Trim()); break;
                    case "Charonna": Charonna = double.Parse(temArr[1].Trim()); break;
                    case "Zinfandel": Zinfandel = double.Parse(temArr[1].Trim()); break;
                    case "Merlot": Merlot = double.Parse(temArr[1].Trim()); break;
                    case "PlumWine": PlumWine = double.Parse(temArr[1].Trim()); break;
                    case "Sake": Sake = double.Parse(temArr[1].Trim()); break;
                }
            }
        }
    }
}
//public static string[] PriceArray = new string[] { "ChildEightPriceLunch", "OthersPriceDinner", "OthersPriceLunch" };
//Regex.Match(tmpPrice[i], @"\d+.\d+").Value
//unsafe public static void LoadPrice()
//{
//    
//    object[] obj=new object[] {AdultsPriceDinner, AdultsPriceLunch, PublicOfficerPriceDinner, PublicOfficerPriceLunch, OldPersonPriceDinner, OldPersonPriceLunch, ChildThreePriceDinner, ChildThreePriceLunch, ChildSixPriceDinner, ChildSixPriceLunch, ChildEightPriceDinner, ChildEightPriceLunch, OthersPriceDinner, OthersPriceLunch };
//    obj[i]
////fixed (double *p= &AdultsPriceDinner)
////{
////    object[] PriceArray = new object[] { *p };
////    for (int i = 0; i < PriceArray.Length; i++)
////    {
////        bool isDinner = true;
////double n = double.Parse(Regex.Match(tmpPrice[i], @"\d+.\d+").Value);
////*p=double.Parse(Regex.Match(tmpPrice[i], @"\d+.\d+").Value);
////Console.WriteLine(n);
//    for (int i = 0; i < obj.Length; i++) { }
//    if ((PriceArray[i] = double.Parse(Regex.Match(tmpPrice[i], @"\d+.\d+").Value)) < 1 && isDinner == true)
//    {
//        PriceArray[i] = AdultsPriceDinner * PriceArray[i];
//    }
//    else if ((PriceArray[i] < 1 && isDinner == false))
//    {
//        PriceArray[i] = AdultsPriceLunch * PriceArray[i];
//    }
//}
//AdultsPriceDinner, &AdultsPriceLunch, PublicOfficerPriceDinner, PublicOfficerPriceLunch, OldPersonPriceDinner, OldPersonPriceLunch, ChildThreePriceDinner, ChildThreePriceLunch, ChildSixPriceDinner, ChildSixPriceLunch, ChildEightPriceDinner, ChildEightPriceLunch, OthersPriceDinner, OthersPriceLunch };



