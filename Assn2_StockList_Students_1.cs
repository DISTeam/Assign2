﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_2
{
  public partial class StockList
  {
    private StockNode head;

    //Constructor for initialization
    
    public StockList()
    {
      this.head = null;
            //initial git commit1
    }

    //param        : NA
    //summary      : checks if the list is empty
    //return       : true if list is empty, false otherwise
    //return type  : bool
    // new comment for testing commit
    public bool IsEmpty()
    {
      if (this.head == null)
      {
        return true;
      }
      return false;
    }

    //param (Stock)stock : stock that is to be added
    //summary      : Add node at first position in list
    //                This is done by creating a new node 
    //                  and pointing it to the current list 
    //return       : NA
    //return type  : NA
    public void AddFirst(Stock stock)
    {
      StockNode nodeToAdd = new StockNode(stock);
      nodeToAdd.Next = head;
      head = nodeToAdd;
    }

    //param (Stock)stock : stock that is to be added
    //summary      : Add mode at last position of list
    //  This is done by traversing the list till we reach the end
    // and pointing the last node to the new node
    // return       :
    // return type  :
    public void AddLast(Stock stock)
    {
      // for an empty list, we add the node at the top of the list
      if (this.IsEmpty())
        AddFirst(stock);
      else
      {
        // traverse the list till the end
        StockNode current = this.head;
        while (current.Next != null)
          current = current.Next;

        // point the last node to the new node
        StockNode nodeToAdd = new StockNode(stock);
        current.Next = nodeToAdd;
      }
    }

    /// <summary>
    /// Add node in an alphabetically sorted manner, if stock is already present then set holdings to sum of existing and new stock
    ///   We assume that the list is always sorted in alphabetical order
    ///   The stock may be added either at:
    ///     the top of the list (if alphabetically lower than all nodes)
    ///   , middle of the list, in which case, we can either
    ///     Add to existing holdings (if the stock already exists in the list), or
    ///     Insert it at the right location in alphatecial order (if it does not already exist)
    ///   , or end of the list (if alphabetically greater than all existing nodes)
    /// </summary>
    /// <param name="stock">stock that is to be added</param>
    public void AddStock(Stock stock)
    {
      // for an empty list, we add the node at the top of the list
      if (this.IsEmpty())
        AddFirst(stock);
      else
      {
        // if the new node is alphabetically the first, again, we add it at the top of the list
        string nameOfStockToAdd = stock.Name;
        string headNodeData = (this.head.StockHolding).Name;
        if (headNodeData.CompareTo(nameOfStockToAdd) > 0)
          AddFirst(stock);
        else
        {
          // traverse the list to locate the stock
          StockNode current = this.head;
          StockNode previous = null;
          string currentStockName = (current.StockHolding).Name;

          while (current.Next != null && currentStockName.CompareTo(nameOfStockToAdd) < 0)
          {
            previous = current;
            current = current.Next;
            currentStockName = (current.StockHolding).Name;
          }

          // we have now traversed all stocks that are alphabetically less than the stock to be added
          if (current.Next != null)
          {
            // if the stock already exists, add to holdings
            if (currentStockName.CompareTo(nameOfStockToAdd) == 0)
            {
              decimal holdings = (current.StockHolding).Holdings + stock.Holdings;
              current.StockHolding.Holdings = holdings;
            }
            else if (currentStockName.CompareTo(nameOfStockToAdd) > 0)
            {
              // insert the stock in the current position. This requires creating a new node,
              //  pointing the new node to the next node
              //    and pointing the previous node to the current node
              //  QUESTION: what would happen if we flipped the sequence of assignments below?
              StockNode newNode = new StockNode(stock);
              newNode.Next = current;
              previous.Next = newNode;
            }
          }
          else
          {
            // we are at the end of the list, add the stock at the end
            //  This is probably not the most efficient way to do it,
            //  since AddLast traverses the list all over again
            AddLast(stock);
          }
        }
      }
    }

    //param  (Stock)stock : stock that is to be checked 
    //summary      : checks if list contains stock passed as parameter
    //                  This involves traversing the list until we find the stock
    //                    return null if we don't
    //return       : Reference of node with matching stock
    //return type  : StockNode if exists, null if not
    public StockNode Contains(Stock stock)
    {
      StockNode nodeReference = null;

      // if the list is empty, return null
      if (this.IsEmpty())
        return nodeReference;
      else
      {
        // traverse the list until we locate the stock,
        //  or, reach the end of the list
        StockNode current = this.head;
        StockNode previous = this.head;
        while (current.Next != null)
        {
          Stock currentStock = current.StockHolding;

          // found it! Return the node
          if (currentStock.Equals(stock))
          {
            nodeReference = previous;
            break;
          }

          // else, continue traversing
          previous = current;
          current = current.Next;
        }
      }

      return nodeReference;
    }

    /// <summary>
    /// swaps the node passed as argument with next node in list
    /// Sorting the list using the simple bubble sort algorithm requires repeatdely traversing
    ///   the list and pushing a node down the list until it falls in place
    ///     Pushing the node is essentially a swap operation, where we take the next node
    ///       and put it in the current position and move the current node to the next position on the list
    /// </summary>
    /// <param name="nodeOne">first node to be swapped</param>
    /// <returns>Reference to current node</returns>
    public StockNode Swap(Stock nodeOne)
    {
      StockNode prevNodeOne = null;
      StockNode currNodeOne = this.head;

      // traverse the list until we reach the node to swap
      while (currNodeOne != null && currNodeOne.StockHolding != nodeOne)
      {
        prevNodeOne = currNodeOne;
        currNodeOne = currNodeOne.Next;
      }

      // maintain references to the nodes to be swapped
      StockNode prevNodeTwo = currNodeOne;
      StockNode currNodeTwo = currNodeOne.Next;

      // handle corner cases, maybe we have reached the end of the list
      if (currNodeOne == null || currNodeTwo == null)
        return null;

      // perhaps the insertion is at the top of the list
      if (prevNodeOne != null)
        prevNodeOne.Next = currNodeTwo;
      else
        this.head = currNodeTwo;

      if (prevNodeTwo != null)
        prevNodeTwo.Next = currNodeOne;
      else
        this.head = currNodeOne;

      // normal case, swap nodes
      StockNode temp = currNodeOne.Next;
      currNodeOne.Next = currNodeTwo.Next;
      currNodeTwo.Next = temp;

      return currNodeTwo;
    }

    
    // FOR STUDENTS

    //param        : NA
    //summary      : Sort the list by descending number of holdings
    //return       : NA
    //return type  : NA
    /*
    this methods sorts existing stock list using bubble sort algorithm
    Method implemented by Amar
             */
    public void SortByValue()
    {    
            StockNode temp = this.head;
            int stockSize = 0; 
            while (temp.Next != null)
            {
                stockSize++;
                temp = temp.Next;//Simple traversal to find number of stocks available in the stock list
                
            }
            //local variables to handle data at run time
            decimal[] holdings = new decimal[stockSize];
            decimal[] currentPrice = new decimal[stockSize];
            string[] symbol = new string[stockSize];
            string[] name = new string[stockSize];
            temp = this.head;
            int iterator = 0;
            while (temp.Next != null)
            {
                //populating local variables using data fetched from list
                holdings[iterator] = temp.StockHolding.Holdings;
                currentPrice[iterator] = temp.StockHolding.CurrentPrice;
                symbol[iterator] = String.Copy(temp.StockHolding.Symbol);
                name[iterator] = String.Copy(temp.StockHolding.Name);
                temp = temp.Next;
                iterator++;
            }
            //bubble sort implementation,sorting based on holding values of stocks
            //sorting is done in descending order of holding values
            for (int i = 0; i < stockSize - 1; i++)
                for (int j = 0; j < stockSize - i - 1; j++)
                    if (holdings[j] < holdings[j + 1])
                    {
                        // swap temp and arr[i] 
                        decimal temp1 = holdings[j];
                        holdings[j] = holdings[j + 1];
                        holdings[j + 1] = temp1;

                        decimal temp2 = currentPrice[j];
                        currentPrice[j] = currentPrice[j + 1];
                        currentPrice[j + 1] = temp2;

                        string temp3 =String.Copy(name[j]);
                        name[j] = String.Copy(name[j + 1]);
                        name[j + 1] = String.Copy(temp3);

                        string temp4 = String.Copy(symbol[j]);
                        symbol[j] = String.Copy(symbol[j + 1]);
                        symbol[j + 1] = String.Copy(temp4);
                    }
            temp = this.head;
            iterator = 0;
            while (temp.Next != null)
            {
                //updating the existing list with sorted array values
                temp.StockHolding.Holdings = holdings[iterator];
                temp.StockHolding.CurrentPrice = currentPrice[iterator];
                temp.StockHolding.Name = String.Copy(name[iterator]);
                temp.StockHolding.Symbol = String.Copy(symbol[iterator]);
                temp = temp.Next;
                iterator++;
            }
        }

    //param        : NA
    //summary      : Sort the list alphabatically
    //return       : NA
    //return type  : NA
    public void SortByName()
        /* this methods sorts existing stock list using bubble sort algorithm
Method implemented by Amar
        */
        {   // write your implementation here
            StockNode temp = this.head;
            int stockSize = 0;
            while (temp.Next != null)
            {
                stockSize++;
                temp = temp.Next; //Simple traversal to find number of stocks available in the stock list

            }
            //local variables to handle data at run time
            decimal[] holdings = new decimal[stockSize];
            decimal[] currentPrice = new decimal[stockSize];
            string[] symbol = new string[stockSize];
            string[] name = new string[stockSize];
            temp = this.head;
            int iterator = 0;
            while (temp.Next != null)
            {
                //populating local variables using data fetched from list
                holdings[iterator] = temp.StockHolding.Holdings;
                currentPrice[iterator] = temp.StockHolding.CurrentPrice;
                symbol[iterator] = String.Copy(temp.StockHolding.Symbol);
                name[iterator] = String.Copy(temp.StockHolding.Name);
                temp = temp.Next;
                iterator++;
            }

            for (int i = 1; i < name.Length; i++)
            {
                for (int j = 0; j < name.Length - i; j++)
                {
                    if (name[j].CompareTo(name[j + 1]) > 0)
                    {
                        //bubble sort implementation,sorting based on holding values of stocks
                        //sorting is done in descending order of holding values
                        string tempname = String.Copy(name[j]);
                        name[j] = String.Copy(name[j + 1]);
                        name[j + 1] = String.Copy(tempname);

                        string tempsym = String.Copy(symbol[j]);
                        symbol[j] = String.Copy(symbol[j + 1]);
                        symbol[j + 1] = String.Copy(tempsym);

                        decimal tempholding = holdings[j];
                        holdings[j] = holdings[j + 1];
                        holdings[j + 1] = tempholding;

                        decimal currprice = currentPrice[j];
                        currentPrice[j] = currentPrice[j + 1];
                        currentPrice[j + 1] = currprice;
                    }
                }
            }

            temp = this.head;
            iterator = 0;
            while (temp.Next != null)
            {
                //updating the existing list with sorted array values

                temp.StockHolding.Holdings = holdings[iterator];
                temp.StockHolding.CurrentPrice = currentPrice[iterator];
                temp.StockHolding.Name = String.Copy(name[iterator]);
                temp.StockHolding.Symbol = String.Copy(symbol[iterator]);
                temp = temp.Next;
                iterator++;
            }
        }
  }
}