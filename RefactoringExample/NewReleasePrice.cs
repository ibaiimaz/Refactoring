using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactoringExample
{
    class NewReleasePrice : Price
    {
        public override int GetPriceCode()
        {
            return Movie.NEW_RELEASE;
        }

        public override double GetCharge(int daysRented)
        {
            double result = daysRented * 3;
 
            return result;
        }

        public override int GetFrecuentRenterPoints(int daysRented)
        {
            // add bonus for a two day new release rental
            return daysRented > 1 ? 2 : 1;
        }
    }
}
