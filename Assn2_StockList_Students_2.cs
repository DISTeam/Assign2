	using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_2
{
	public partial class StockList
	{
		//param   (StockList)listToMerge : second list to be merged 
		//summary      : merge two different list into a single result list
		//return       : merged list
		//return type  : StockList
		public StockList MergeList(StockList listToMerge)
		{
			StockList resultList = new StockList();

			// write your implementation here1
			// Added by Manasa - start of code
			//assigning the stock of the client who called the function merge
			StockNode current = this.head;
			// that first list to be merged is assigned to the new stocklist -which holds the merged list
			resultList.head = current;
			
			Stock stockToAdd = listToMerge.head.StockHolding;
			
			while(listToMerge.head != null)
			{
				// this function call adds each stock to the stocklist -resultList
				//while also trying to merge any existing stock with their holdings
				resultList.AddStock(listToMerge.head.StockHolding);
				// to traverse the stocklist to the next node
				listToMerge.head = listToMerge.head.Next;
			}
			//Added by Manasa - end of code
			return resultList;
		}

		//param        : NA
		//summary      : finds the stock with most number of holdings
		//return       : stock with most shares
		//return type  : Stock
		public Stock MostShares()
		{
			Stock mostShareStock = null;
			//manasa code -added start
			// traverse the list to locate the stock. this function sorts the list in descending order	
			this.SortByValue();
			
			   		
			// go to the head node first 
			StockNode current = this.head;	
			// the holding value of the first and max stock
			decimal maxHoldings=(current.StockHolding).Holdings;
			//assigning the most holding stock to the variable of type stock to display
			mostShareStock = current.StockHolding;

			//manasa code - added end 
			return mostShareStock;
		}

		//param        : NA
		//summary      : finds the number of nodes present in the list
		//return       : length of list
		//return type  : int
		public int Length()
		{
			int length = 0;
			// write your implementation here
									
			//***Implementation Begin - Added by Manasa***
			//check if the list is empty and if so then set number of nodes is 0
			if (this.IsEmpty())
				length = 0;
			else  //if the list is not empty and has atleast one or more nodes
			{
				// go to the head node first 
				StockNode current = this.head;
				//count the head node as 1
				//length++;
				// traverse the list till the end
				while (current.Next != null)
				{
					//move to the next node
					current = current.Next;
					//count each of the node that is successfully moved to
					length++;
				}
			}
			//***Implementation End - Added by Manasa***

			return length;
		}
	}
}