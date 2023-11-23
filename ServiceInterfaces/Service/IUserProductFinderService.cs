using System;
using ServiceInterfaces.Model;

namespace ServiceInterfaces.Service
{
	public interface IUserProductFinderService
	{
        public ProductModel GetBestProductForUser(LoanEnquiry user);
    }
}

