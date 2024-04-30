using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HW10// folder name: HW10
{
    public class Receipt
    {
        public string CustomerID;
        public int CogQuantity;
        public int GearQuantity;
        public DateTime SaleDate;
        public double Subtotal;
        public double SalesTax;
        public double GrandTotal;

        private double SalesTaxRate;
        private double CogPrice;
        private double GearPrice;

        // constructor functions
        public Receipt() 
        {
            this.CustomerID = "";
            this.CogQuantity = 0;
            this.GearQuantity = 0;

            this.SaleDate = DateTime.Now;
            this.Subtotal = 0;
            this.SalesTaxRate = 0;
            this.GrandTotal = 0;

            this.SalesTaxRate = 0.08;
            this.CogPrice = 80.00;
            this.GearPrice = 250.00;
        }
        public Receipt(string id, int cog, int gear)
        { 
            this.CustomerID = id;
            this.CogQuantity = cog;
            this.GearQuantity = gear;

            this.SaleDate = DateTime.Now;
            this.Subtotal = 0;
            this.SalesTaxRate = 0;
            this.GrandTotal = 0;

            this.SalesTaxRate = 0.08;
            this.CogPrice = 80.00;
            this.GearPrice = 250.00;
        }
        private double CalculateSubtotal()
        {
            this.Subtotal = this.CogPrice * this.CogQuantity + this.GearPrice * this.GearQuantity;
            return this.Subtotal;
        }
        private double CalculateSalesTax()
        {
            this.SalesTax = this.Subtotal*this.SalesTaxRate;
            return this.SalesTax;
        }

        public double CalculateGrandTotal()
        {
            this.CalculateSubtotal();
            this.CalculateSalesTax();

            this.GrandTotal = this.Subtotal + this.SalesTax;
            
            return this.GrandTotal;
        }

        public void PrintReceipt()
        { 
            Console.WriteLine("======================================");
            Console.WriteLine($"Receipt".ToUpper());
            Console.WriteLine($"Customer ID: {this.CustomerID}");
            Console.WriteLine($"# of cogs: {this.CogQuantity}");
            Console.WriteLine($"# of gears: {this.GearQuantity}");
            Console.WriteLine($"Subtotal: {this.Subtotal:C2}");
            Console.WriteLine($"Sales Tax: {this.SalesTax:C2}");
            Console.WriteLine($"Grand Total: {this.GrandTotal:C2}");
            Console.WriteLine($"Time: {this.SaleDate}");
            Console.WriteLine("======================================");
        }
    }
}
