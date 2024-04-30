// MIS 3013 001
// HW 10
// Alexandra Camarena
// 113568154

//Console.WriteLine("HW10");

using HW10;

string menuStr = """
*********************************
Please choose from the options:
1: Add a new receipt
2: Print all receipts
3: Print all receipts of one customer
4: Print the highest total receipt
5: Print the average grand total
Press other keys to exit
**********************************
""";

List<Receipt>receiptList = new List<Receipt>();

while (true)
{
    Console.WriteLine(menuStr);

    Console.WriteLine();

    Console.Write($"Enter an option: ");
    string userChoiceStr = Console.ReadLine();

    if (userChoiceStr == "1")
    {
        Console.WriteLine("\nAdd a new receipt\n".ToUpper());

        Console.Write($"Input the customer ID: ");
        string idStr = Console.ReadLine();

        Console.Write($"Input N of cogs: ");
        string nCogsStr = Console.ReadLine();
        int nCogsInt = Convert.ToInt32(nCogsStr);

        Console.Write($"Input N of gears: ");
        string nGearsStr = Console.ReadLine();
        int nGearsInt = Convert.ToInt32(nGearsStr);

        Receipt r = new Receipt();

        r.CustomerID = idStr;
        r.CogQuantity = nCogsInt;
        r.GearQuantity = nGearsInt;

        r.CalculateGrandTotal();

        Console.WriteLine();

        r.PrintReceipt();

        Console.WriteLine();

        receiptList.Add(r);
    }
    else if (userChoiceStr == "2")
    {
        Console.WriteLine("\nAll Receipts\n".ToUpper());
        for (int i = 0; i <= receiptList.Count - 1; i = i + 1)
        {
            Receipt r = receiptList[i];
            r.PrintReceipt();
        }
    }
    else if (userChoiceStr == "3")
    {
        Console.WriteLine("\nAll Receipts for one customer\n");

        Console.Write("Input a customer ID: ");
        string idStr = Console.ReadLine();

        for (int i = 0; i <= receiptList.Count - 1; i = i + 1)
        {
            Receipt r = receiptList[i];
            if (r.CustomerID==idStr)
            {
                r.PrintReceipt();
            }
        }
    }
    else if (userChoiceStr == "4")
    {
        Console.WriteLine("\nReceipt with highest grand total\n".ToUpper());

        Receipt hr = receiptList[0];

        for (int i = 0; i <= receiptList.Count - 1; i = i + 1)
        {
            Receipt r = receiptList[i];
            if (r.GrandTotal > hr.GrandTotal)
            {
                hr = r;
            }
        }
        hr.PrintReceipt();
    }
    else if (userChoiceStr == "5")
    {
        Console.WriteLine("\nAverage grand total\n");

        double grandTotalSum = 0;

        for (int i = 0; i <= receiptList.Count - 1; i = i + 1)
        { 
            grandTotalSum = grandTotalSum + receiptList[i].GrandTotal;
        }

        double grandAverage = grandTotalSum / receiptList.Count;
        Console.WriteLine($"Average: {grandAverage:C2}");
    }
    else
    {
        Console.WriteLine("Thank you and goodbye!");
        break;    
    }
}