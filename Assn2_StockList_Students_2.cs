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
			// traverse the list to locate the stock	

			//check if the list is empty and return an empty stock
			//if (this.IsEmpty())
			this.SortByValue();
			//else
			// go to the head node first 
			StockNode current = this.head;
			StockNode previous = null;
			//decimal currentMaxHoldings;
			decimal maxHoldings=(current.StockHolding).Holdings;
			while (current.Next != null)
			{
				previous = current;
				current = current.Next;
				//if ((previous.StockHolding).Holdings > (current.StockHolding).Holdings)
				//	currentMaxHoldings = previous.StockHolding.Holdings;
				//else
				//	currentMaxHoldings = (current.StockHolding).Holdings;
				//if (maxHoldings <= currentMaxHoldings)
				//	maxHoldings = currentMaxHoldings;
					
			}

			//manasa code - added end

			mostShareStock = current.StockHolding;
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
				length++;
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