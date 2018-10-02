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

                //added by Mano -starti of code
                StockNode items = this.head;
                //this will append the newly added value into variable value
                value = value + items.StockHolding.Holdings * items.StockHolding.CurrentPrice;

              
     
                while (items.Next != null)
                {
                   
                   value = value + items.StockHolding.Holdings * items.StockHolding.CurrentPrice;
                    items = items.Next;
                }
                value = value + items.StockHolding.Holdings * items.StockHolding.CurrentPrice;

                //end of code added by Mano



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
            //code added by Mano
            var stock1 = new List<string>();
            //checks if the list is empty
            if (!this.IsEmpty())
            {

                StockNode items = this.head;
                stock1.Add(items.StockHolding.Symbol);

             //takes the symbol of each list holding and compares
                while (items.Next != null)
                {
                    
                    stock1.Add(items.StockHolding.Symbol);
                    items = items.Next;
                }
                stock1.Add(items.StockHolding.Symbol);
            }

            var stock2 = new List<string>();
            //list 1 compares to lsit symbols
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
            //end of code added by Mano
    }

    //param        : NA
    //summary      : Print all the nodes present in the list
    //return       : NA
    //return type  : NA
    public void Print()
    {
            // write your implementation here

            /*if (!this.IsEmpty())
            {
                StockNode items = this.head;
                Console.WriteLine(items.StockHolding.ToString());

              
                while (items.Next != null)
                {
                   
                    Console.WriteLine(items.StockHolding.ToString());
                    items = items.Next;
                }
                Console.WriteLine(items.StockHolding.ToString());*/
                //code added by Mano -start
            StockNode s = this.head;
            while (s.Next != null)
            {
                Console.Write(s.StockHolding + "\n");
                s = s.Next;
            }
            Console.Write(s.StockHolding + "\n");
            //end of code added by `
        }

        }
  }