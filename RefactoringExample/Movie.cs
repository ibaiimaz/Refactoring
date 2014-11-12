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
        private String _title;
        private int _priceCode;

        public Movie(String title, int priceCode)
        {
            _title = title;
            _priceCode = priceCode;
        }

        public int getPriceCode()
        {
            return _priceCode;
        }

        public void setPriceCode(int arg)
        {
            _priceCode = arg;
        }

        public String getTitle()
        {
            return _title;
        }

        public double GetCharge(int daysRented)
        {
            double result = 0;
            switch (getPriceCode())
            {
                case Movie.REGULAR:
                    result += 2;
                    if (daysRented > 2)
                        result += (daysRented - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    result += daysRented * 3;
                    break;
                case Movie.CHILDRENS:
                    result += 1.5;
                    if (daysRented > 3)
                        result += (daysRented - 3) * 1.5;
                    break;
            }
            return result;
        }

        public int GetFrecuentRenterPoints(int daysRented)
        {
            // add bonus for a two day new release rental
            if ((getPriceCode() == Movie.NEW_RELEASE) && daysRented > 1)
                return 2;
            else
                return 1;
        }
    }
}
