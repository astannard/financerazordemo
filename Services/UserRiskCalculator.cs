using System;
namespace Services
{
	public static class UserRiskCalculator
	{
        private const decimal MAX_PERCENTAGE_OF_INCOME = 0.25M; //Should load from a config setting

        // This should be unit tested
        public static decimal CalculateRisk(decimal annualIncome, decimal loan, int monthsPayback)
        {
            decimal monthlyIncome = annualIncome / 12;
            decimal monthlyPaybackExludingInterest = loan / monthsPayback;
            decimal maxMonthlyPaybackAmmount = monthlyIncome * MAX_PERCENTAGE_OF_INCOME;
            return monthlyPaybackExludingInterest / maxMonthlyPaybackAmmount;
        }
    }
}

