using System;
namespace ServiceInterfaces.Model
{
	public class ProductModel
	{
        public int Id { get; set; }
        public decimal MaxRiskLevel { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Interest { get; set; }

    }
}

