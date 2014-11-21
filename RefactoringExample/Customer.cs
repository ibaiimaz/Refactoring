using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace RefactoringExample
{
    public class Customer
    {
        private readonly String _name;
        private readonly List<Rental> _rentals = new List<Rental>();

        public Customer(String name)
        {
            _name = name;
        }

        public void AddRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        public String GetName()
        {
            return _name;
        }

        public String Statement()
        {
            String result = "Rental Record for " + GetName() + "\n";
            foreach (Rental each in _rentals)
            {
                //show figures for this rental
                result += "\t" + each.GetMovie().GetTitle() + "\t" + each.GetCharge().ToString() + "\n";
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

        public String HtmlStatement()
        {

            String result = "<H1>Rentals for <EM>" + GetName() + "</EM></H1><P>\n";
            foreach (Rental each in _rentals)
            {
                //show figures for each rental
                result += each.GetMovie().GetTitle() + ": " + each.GetCharge().ToString() + "<BR>\n";
            }
            //add footer lines
            result += "<P>You owe <EM>" + GetTotalCharge().ToString() + "</EM><P>\n";
            result += "On this rental you earned <EM>" + GetTotalFrequentRenterPoints().ToString() + "</EM> frequent renter points<P>";
            return result;
        }
    }
}
