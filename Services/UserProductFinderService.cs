using System;
using System.Linq;
using Newtonsoft.Json;
using ServiceInterfaces.Model;
using ServiceInterfaces.Service;

namespace Services
{
	public class UserProductFinderService : IUserProductFinderService
    {
        // The product json should be put into a seperate class with an interface. This means we can mock an inject another version for testing etc
        ProductModel? IUserProductFinderService.GetBestProductForUser(LoanEnquiry user)
        {
            //TODO Load products from a database, look up connection string from a config file. This can be overridded in azure etc with settings to specify a production connection for example
            string json = File.ReadAllText("products.json");

            var applicantRisk = UserRiskCalculator.CalculateRisk(user.Income, user.RequestedLoan, 12);//Currently all loans a paid back over a year.

            ProductModel[] products = JsonConvert.DeserializeObject<ProductModel[]>(json);

            if (products == null)
            {
                throw new ApplicationException("No products found");
            }

            return products.OrderBy(p => p.Interest).FirstOrDefault(p => p.MaxRiskLevel >= applicantRisk);
        }
    }
}

