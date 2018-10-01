using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment_2
{
  public partial class StockList
  {
    //param        : NA
    //summary      : Calculate the value of each node by multiplying holdings with price, and returns the total value
    //return       : total value
    //return type  : decimal
    public decimal Value()
    {
      decimal value = 0.0m;
            // write your implementation here

            if (!this.IsEmpty())
            {
                StockNode items = this.head;
                //value = value + (items.StockHolding.Holdings * items.StockHolding.CurrentPrice);              
     
                while (items.Next != null)
                {                   
                   value = value + (items.StockHolding.Holdings * items.StockHolding.CurrentPrice);
                   items = items.Next;
                }
                value = value + (items.StockHolding.Holdings * items.StockHolding.CurrentPrice);
            }

      return value;
    }

    //param  (StockList) listToCompare     : StockList which has to comared for similarity index
    //summary      : finds the similar number of nodes between two lists
    //return       : similarty index
    //return type  : int
    public int Similarity(StockList listToCompare)
    {
      int similarityIndex = 0;

            // write your implementation here

            var stock1 = new List<string>();

            if (!this.IsEmpty())
            {
                StockNode items = this.head;
                stock1.Add(items.StockHolding.Symbol);
             
                while (items.Next != null)
                {
                    
                    stock1.Add(items.StockHolding.Symbol);
                    items = items.Next;
                }
                stock1.Add(items.StockHolding.Symbol);
            }

            var stock2 = new List<string>();

            if (!listToCompare.IsEmpty())
            {
                var items = new StockNode();
                items = listToCompare.head;
                stock2.Add(items.StockHolding.Symbol);

              
                while (items.Next != null)
                {
                    
                    stock2.Add(items.StockHolding.Symbol);
                    items = items.Next;
                }
                stock2.Add(items.StockHolding.Symbol);
            }

            var CommonList = stock1.Intersect(stock2);
            similarityIndex = CommonList.Count();


            return similarityIndex;
    }

    //param        : NA
    //summary      : Print all the nodes present in the list
    //return       : NA
    //return type  : NA
    public void Print()
    {
            // write your implementation here

             //this method prints the data present in stock list to the console
            StockNode s = this.head;
            while (s.Next != null)
            {
                Console.Write(s.StockHolding + "\n");
                s = s.Next;
            }
			Console.WriteLine(s.StockHolding);

        }
  }
}