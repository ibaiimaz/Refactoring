using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactoringExample;

namespace Refactoring.Test
{
    /// <summary>
    /// Descripción resumida de RefactoringTest
    /// </summary>
    [TestClass]
    public class RefactoringTest
    {
        [TestMethod]
        public void Test_Customer1_Regular_Movie1_1_day()
        {
            var customer = new Customer("Customer1");

            customer.AddRental(new Rental(new Movie("Movie1", Movie.REGULAR), 1));

            string resp = customer.Statement();

            Assert.AreEqual("Rental Record for Customer1\n\tMovie1\t2\nAmount owed is 2\nYou earned 1 frequent renter points", resp);
        }

        [TestMethod]
        public void Test_Customer1_Regular_Movie1_More_Than_2_Days()
        {
            var customer = new Customer("Customer1");

            customer.AddRental(new Rental(new Movie("Movie1", Movie.REGULAR), 4));

            string resp = customer.Statement();

            Assert.AreEqual("Rental Record for Customer1\n\tMovie1\t5\nAmount owed is 5\nYou earned 1 frequent renter points", resp);
        }

        [TestMethod]
        public void Test_Customer2_NewRelease_Movie2_1_day()
        {
            var customer = new Customer("Customer2");

            customer.AddRental(new Rental(new Movie("Movie2", Movie.NEW_RELEASE), 1));

            string resp = customer.Statement();

            Assert.AreEqual("Rental Record for Customer2\n\tMovie2\t3\nAmount owed is 3\nYou earned 1 frequent renter points", resp);
        }

        [TestMethod]
        public void Test_Customer2_NewRelease_Movie2_More_Than_1_Day()
        {
            var customer = new Customer("Customer2");

            customer.AddRental(new Rental(new Movie("Movie2", Movie.NEW_RELEASE), 2));

            string resp = customer.Statement();

            Assert.AreEqual("Rental Record for Customer2\n\tMovie2\t6\nAmount owed is 6\nYou earned 2 frequent renter points", resp);
        }

        [TestMethod]
        public void Test_Customer3_Childrens_Movie3_1_day()
        {
            var customer = new Customer("Customer3");

            customer.AddRental(new Rental(new Movie("Movie3", Movie.CHILDRENS), 1));

            string resp = customer.Statement();

            Assert.AreEqual("Rental Record for Customer3\n\tMovie3\t1,5\nAmount owed is 1,5\nYou earned 1 frequent renter points", resp);
        }

        [TestMethod]
        public void Test_Customer3_Childrens_Movie3_More_Than_3_Days()
        {
            var customer = new Customer("Customer3");

            customer.AddRental(new Rental(new Movie("Movie3", Movie.CHILDRENS), 5));

            string resp = customer.Statement();

            Assert.AreEqual("Rental Record for Customer3\n\tMovie3\t4,5\nAmount owed is 4,5\nYou earned 1 frequent renter points", resp);
        }

        [TestMethod]
        public void Test_Customer_Two_Rentals()
        {
            var customer = new Customer("Customer");

            customer.AddRental(new Rental(new Movie("Movie1", Movie.CHILDRENS), 2));
            customer.AddRental(new Rental(new Movie("Movie2", Movie.NEW_RELEASE), 3));

            string resp = customer.Statement();

            Assert.AreEqual("Rental Record for Customer\n\tMovie1\t1,5\n\tMovie2\t9\nAmount owed is 10,5\nYou earned 3 frequent renter points", resp);
        }
    }
}
