using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Program program = new Program(); 
                //Scenario A    -- Test case 1
                // cosidering 1 : A, 1: B, 1: C
                string skuOneDetails = "BAC";

                //Scenario B    -- Test case 2
                // cosidering 5 : A, 5: B, 1: C
                //string skuOneDetails = "AAAAABBBBBC";

                //Scenario C    -- Test case 3
                // cosidering 3 : A, 5: B, 1: C, 1: D
                //string skuOneDetails = "AAABBBBBDC";

                decimal test = program.PrintInvoice(skuOneDetails);

                Console.WriteLine("Total amount of your product is {0}.", test);

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occured");
                Console.ReadLine();
            }

        }

        public decimal PrintInvoice(string str)
        {
            decimal amount = 0;
            try
            {
                if (!string.IsNullOrEmpty(str) && !string.IsNullOrWhiteSpace(str))
                {
                    char[] skuItems = str.ToArray();
                    Item itemSku = new Item();
                    Dictionary<char, int> skuList = new Dictionary<char, int>();

                    bool isCombo = false;
                    foreach (var item in skuItems)
                    {
                        if (skuList.ContainsKey(item))
                        {
                            skuList[item]++;
                        }
                        else
                        {
                            skuList[item] = 1;
                        }
                    }
                    if (skuList.ContainsKey('C') && skuList.ContainsKey('D'))
                    {
                        isCombo = true;
                        GetPriceOfComboItem(skuList, isCombo, ref amount);
                    }
                    else
                    {
                        isCombo = false;
                        GetPriceOfComboItem(skuList, isCombo, ref amount);
                    }
                }               
                
            }
            catch (Exception ex)
            {
                throw;
            }
            return amount;
        }

        private decimal GetPriceOfComboItem(Dictionary<char, int> skuList, bool isCombo, ref decimal amount)
        {
            
            //decimal amount = 0;
            Item itemSku = new Item();
            try
            {
                int counter = 0;
                foreach (var item in skuList)
                {
                    if (skuList.ContainsKey('C') && skuList.ContainsKey('D'))
                    {
                        
                        if (item.Key.Equals('C') || item.Key.Equals('D'))
                        {
                            
                            if (skuList['C'] > skuList['D'])
                            {
                                int cVal = skuList['C'] - skuList['D'];
                                GetComboAmount(skuList, isCombo, ref amount, itemSku, item, ref counter, cVal);
                            }
                            else if (skuList['C'] < skuList['D'])
                            {
                                int cVal = skuList['D'] - skuList['C'];
                                GetComboAmount(skuList, isCombo, ref amount, itemSku, item, ref counter, cVal);
                            }
                            else
                            {
                                if (counter == 0)
                                {
                                    amount = amount + itemSku.GetItemAmount(skuList['C'], item.Key, isCombo);
                                }
                                counter++;
                            }
                        }
                        else
                        {
                            amount = amount + itemSku.GetItemAmount(item.Value, item.Key, isCombo);
                        }
                    }
                    else
                    {
                        amount = amount + itemSku.GetItemAmount(item.Value, item.Key, isCombo);
                    }
                                    
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return amount;
        }

        private static void GetComboAmount(Dictionary<char, int> skuList, bool isCombo, ref decimal amount, Item itemSku, KeyValuePair<char, int> item, ref int counter, int cVal)
        {
            if (item.Key.Equals('C'))
            {
                if (counter == 0)
                {
                    amount = amount + itemSku.GetItemAmount(cVal, item.Key, false);
                    amount = amount + itemSku.GetItemAmount(skuList['D'], item.Key, isCombo);
                }
                counter++;
            }
            else
            {
                if (counter == 0)
                {
                    amount = amount + itemSku.GetItemAmount(cVal, item.Key, false);
                    amount = amount + itemSku.GetItemAmount(skuList['C'], item.Key, isCombo);
                }
                counter++;
            }
        }
    }
}
