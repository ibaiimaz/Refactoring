using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace RefactoringExample
{
    public class Movie
    {
        public const int CHILDRENS = 2;
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;

        private readonly String title;
        private Price price;

        public Movie(String title, int priceCode)
        {
            this.title = title;
            SetPriceCode(priceCode);
        }

        public int GetPriceCode()
        {
            return price.GetPriceCode();
        }

        public void SetPriceCode(int arg)
        {
            switch (arg)
            {
                case REGULAR:
                    price = new RegularPrice();
                    break;
                case CHILDRENS:
                    price = new ChildrensPrice();
                    break;
                case NEW_RELEASE:
                    price = new NewReleasePrice();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("arg", "Incorrect Price Code");
            }
        }

        public String GetTitle()
        {
            return title;
        }

        public double GetCharge(int daysRented)
        {
            return price.GetCharge(daysRented);
        }

        public int GetFrecuentRenterPoints(int daysRented)
        {
            return price.GetFrecuentRenterPoints(daysRented);
        }
    }
}
