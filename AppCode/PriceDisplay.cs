using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bliss_POS.AppCode
{
    /*
     * Implements the behaviour of the price display on a cash register.
     * The decimal point remains in a fixed place and digits move from
     * right to left.
     */
    public class PriceDisplay
    {
        protected double price;
        protected string strPriceDisplay;
        protected List<int> digits;

        public PriceDisplay()
        {
            price = 0;
            digits = new List<int>();
            strPriceDisplay = String.Format("{0:c}", price);
        }

        public void addNote(double value)
        {
            price += value;
        }

        public void add(int num)
        {
            //numbers are added to the right of the display,
            //shifting existing digits to the left.
            if (num == -1) //the '00' button has been pressed
            {
                //price = price * 100;
                digits.Add(0);
                digits.Add(0);
            }
            else if (num == -2)//'C' has been pressed. Remove last digit
            {
                if (digits.Count > 0)
                {
                    digits.RemoveAt(digits.Count - 1);
                }
                //price = price / 10;
                //price = Convert.ToDouble(Math.Pow(Convert.ToDouble(price), -10));

            }
            else
            {
                //price = price * 10 + num * 0.01;
                digits.Add(num);
            }
            using (List<int>.Enumerator e = digits.GetEnumerator())
            {
                int count = digits.Count;
                price = 0;
                while (e.MoveNext())
                {
                    int i = e.Current;
                    price = price + i * Math.Pow(10, count - 3);
                    count--;
                }
            }
            
        }

        public void clear()
        {
            price = 0;
            digits.RemoveRange(0, digits.Count);
        }

        public string getPriceString()
        {
            return String.Format("{0:c}", price);
        }

        public double getPrice()
        {
            return price;
        }

    }
}
