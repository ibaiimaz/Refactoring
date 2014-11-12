using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace RefactoringExample
{
    public class Customer
    {
        private String _name;
        private List<Rental> _rentals = new List<Rental>();

        public Customer(String name)
        {
            _name = name;
        }

        public void addRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        public String getName()
        {
            return _name;
        }

        public String statement()
        {
            String result = "Rental Record for " + getName() + "\n";
            foreach (Rental each in _rentals)
            {
                //show figures for this rental
                result += "\t" + each.getMovie().getTitle() + "\t" + each.GetCharge().ToString() + "\n";
            }
            //add footer lines
            result += "Amount owed is " + GetTotalCharge().ToString() +
            "\n";
            result += "You earned " + GetTotalFrequentRenterPoints().ToString()
            +
            " frequent renter points";
            return result;
        }

        private double GetTotalCharge()
        {
            double result = 0;
            foreach (Rental each in _rentals)
            {
                result += each.GetCharge();
            }
            return result;
        }

        private double GetTotalFrequentRenterPoints()
        {
            double result = 0;
            foreach (Rental each in _rentals)
            {
                result += each.GetFrecuentRenterPoints();
            }
            return result;
        }

        public String htmlStatement()
        {

            String result = "<H1>Rentals for <EM>" + getName() + "</EM></H1><P>\n";
            foreach (Rental each in _rentals)
            {
                //show figures for each rental
                result += each.getMovie().getTitle() + ": " + each.GetCharge().ToString() + "<BR>\n";
            }
            //add footer lines
            result += "<P>You owe <EM>" + GetTotalCharge().ToString() + "</EM><P>\n";
            result += "On this rental you earned <EM>" + GetTotalFrequentRenterPoints().ToString() + "</EM> frequent renter points<P>";
            return result;
        }
    }
}
