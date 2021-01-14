
/* Loan.cs
 * Creates fileds for the amount of loan, interest
 * rate, and number of years. Calculates payment amount
 * and produces an amortizatio schedule
 */
using System;

namespace LoanApp
{
    public class Loan
    {
        private double loanAmount;
        private double rate;
        private int numPayments;
        private double balance;
        private double totalInterestPaid;
        private double paymentAmout;
        private double principal;
        private double monthInterest;

        // Default constructor
        public Loan()
        { }

        // Constructor
        public Loan(double loan, double interestRate, int years)
        {
            loanAmount = loan;
            if (interestRate < 1)
                rate = interestRate;
            else
                rate = interestRate / 100;
            numPayments = 12 * years;
            totalInterestPaid = 0;
            DeterminePaymentAmount();
        }

        //Property accessing payment amount
        public double PaymentAmout
        {
            get
            {
                return paymentAmout;
            }
        }

        // Property setting and returning loan amount
        public double LoanAmount
        {
            set
            {
                loanAmount = value;
            }
            get
            {
                return loanAmount;
            }
        }

        // Property setting and returning rat
        public double Rate
        {
            set
            {
                rate = value;
            }
            get
            {
                return rate;
            }
        }

        // Property to set the numPayments, given years
        // to finance. Returns the number of years using
        // number of payments
        public int Years
        {
            set
            {
                numPayments = value;
            }
            get
            {
                return numPayments / 12;
            }
        }

        //Property for accessing total interest
        public double TotalInterestPaid
        {
            get
            {
                return totalInterestPaid;
            }
        }

        // Determine payment amount based on number of
        // years, loan amount, and rate
        public void DeterminePaymentAmount()
        {
            double term;
            term = Math.Pow((1 + rate / 12.0), numPayments);
            paymentAmout = (loanAmount * rate / 12.0 * term) / (term - 1.0);
        }

        // Returns string containing amortizaition table
        public string ReturnAmortizationSchedule()
        {
            string aSchedule = "Month\t\tInt.\t\tPrin.\t\tNew";
            aSchedule += "\nNo.\t\tPd.\t\tPd.\t\tBalance\n";
            aSchedule += "-----\t\t-----\t\t-----\t" + "\t--------\n";

            balance = loanAmount;
            for (int month = 1; month <= numPayments;month++)
            {
                CalculateMonthCharges(month, numPayments);
                aSchedule += month + "\t" +
                            monthInterest.ToString("N2") + "\t" +
                            principal.ToString("N2") + "\t" +
                            balance.ToString("C") + "\n";
            }
            return aSchedule;
        }

        // Calculates monthly interest and new balance.
        public void CalculateMonthCharges(int month, int numPayments)
        {
            double payment = paymentAmout;
            monthInterest = rate / 12 * balance;
            if (month == numPayments)
            {
                principal = balance;
                payment = balance + monthInterest;
            }
            else
            {
                principal = payment - monthInterest;
            }
            balance -= principal;
        }

        // Calcultes interest paid over life of loan
        public void DetermineTotalInterestPaid()
        {
            totalInterestPaid = 0;
            balance = loanAmount;
            for (int month = 1; month <= numPayments; month++)
            {
                CalculateMonthCharges(month, numPayments);
                totalInterestPaid += monthInterest;
            }
        }

        // Return information about the loan
        public override string ToString()
        {
            return "\nLoan Amount: " +
                    loanAmount.ToString("C") +
                    "\nInterest Rate: " + rate +
                    "\nNumber of Years for Loan: " +
                    (numPayments / 12) +
                    "\nMonthly payment: " +
                    paymentAmout.ToString("C");
        }
    }
}
