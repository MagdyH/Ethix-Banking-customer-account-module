using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ethix_NG_API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ethix_NG_API.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {

        private readonly Ethix_NGContext _context;
        CustomerAccount customerAccount;
        List<ClassCode> classCodeList;
        List<Currency> currencyList;
        List<ExchangeRate> exchangeRateList;

        public CustomersController(Ethix_NGContext context)
        {
            _context = context;
        }
        // GET api/Customers
        [HttpGet]
        //[Route("api/[controller]/GetAll")]
        public IEnumerable<CustomerViewModel> GetAllCustomers()
        {
            var customers = _context.Customers.Include("Branch").Select(c => new CustomerViewModel { BranchName = c.Branch.BranchName, CustomerId = c.CustomerId, CustmerName = c.CustmerName, OpenDate = c.OpenDate }).ToList();
            return customers;
        }

        [Route("Search/{SearchInput}")]
        [HttpGet]
        //[Route("api/[controller]/GetById/{SearchInput}")]
        public IEnumerable<Customer> GetCustomerBySearch(string SearchInput)
        {
            List<Customer> customerList = new List<Customer>();
            int Id = 0;
            if (!string.IsNullOrEmpty(SearchInput))
            {
                if (int.TryParse(SearchInput, out Id))
                {
                    customerList = _context.Customers.Include("Branch").Where(c => c.CustomerId == Id).ToList();
                }
                else
                {
                    customerList = _context.Customers.Include("Branch").Where(c => c.CustmerName.ToLower().Contains(SearchInput.ToLower())).ToList();
                }
            }
            else
            {

            }
            return customerList;
        }

        [Route("getById/{Id}")]
        [HttpGet]
        public CustomerAccountListViewModel GetCustomerById(int Id)
        {
            CustomerAccountViewModel customerAcc = new CustomerAccountViewModel();

            CustomerAccountListViewModel customerAccountList = new CustomerAccountListViewModel();
            customerAccountList.CustomerAccountList = new List<CustomerAccountViewModel>();
            if (Id != 0)
            {
                customerAccountList.Customer = _context.Customers.Include("Branch").Select(c => new CustomerViewModel { BranchName = c.Branch.BranchName, CustomerId = c.CustomerId, CustmerName = c.CustmerName, OpenDate = c.OpenDate }).FirstOrDefault(c => c.CustomerId == Id);
                var customerAccList = _context.CustomerAccounts.Include("Currency").Where(ca => ca.Customer.CustomerId == Id && !ca.IsClosed);
                if (customerAccList != null)
                {
                    foreach (var Acc in customerAccList)
                    {
                        customerAcc = new CustomerAccountViewModel();
                        customerAcc.AccId = Acc.AccId;
                        customerAcc.Acc_Number = Acc.Acc_Number;
                        customerAcc.Acc_Type = Acc.Acc_Type;
                        customerAcc.Openning_Bal = Math.Round(Acc.Openning_Bal, Acc.Currency.decimal_Digits); 
                        customerAcc.Class_Code = Acc.Class_Code;
                        customerAcc.IsClosed = Acc.IsClosed;
                        customerAcc.Currency = Acc.Currency.ISO_Code;
                        customerAcc.CurrencyId = Acc.Currency.currencyId;
                        customerAcc.CustomerId = Id;// Acc.Customer.CustomerId;
                        customerAcc.currDecimal = Acc.Currency.decimal_Digits;
                        customerAccountList.CustomerAccountList.Add(customerAcc);
                    }
                }
            }
            else
            {

            }
            return customerAccountList;
        }

        // POST api/values
        [HttpPost]
        public CustomerAccountViewModel CreateCustomerAccount([FromBody] CustomerAccountViewModel customerobj)
        {
            if (customerobj != null)
            {
                customerAccount = new CustomerAccount();
                if (customerobj.Acc_Number.Length > 12 || customerobj.Acc_Number.Length > 12)
                {
                    return customerobj;
                }
                if (customerobj.Openning_Bal <=0)
                {
                    return customerobj;
                }
                customerAccount.Acc_Number = customerobj.Acc_Number;
                customerAccount.AccId = customerobj.AccId;
                customerAccount.Acc_Type = customerobj.Acc_Type;
                customerAccount.Class_Code = customerobj.Class_Code;
                customerAccount.IsClosed = customerobj.IsClosed;
                customerAccount.Openning_Bal = customerobj.Openning_Bal;


                _context.CustomerAccounts.Add(customerAccount);
                customerAccount.Currency = _context.Currencies.FirstOrDefault(c => c.currencyId == customerobj.CurrencyId);
                customerAccount.Customer = _context.Customers.FirstOrDefault(c => c.CustomerId == customerobj.CustomerId);
                _context.SaveChanges();

                customerobj.AccId = customerAccount.AccId;
                customerobj.Currency = customerAccount.Currency.ISO_Code;
                customerobj.currDecimal = customerAccount.Currency.decimal_Digits;
                return customerobj;
            }
            else
            {
                return customerobj;
            }
        }

        [Route("UpdateAcc/{id}")]
        [HttpPost]
        public void UpdateAccountState(int id)
        {
            var acc = _context.CustomerAccounts.FirstOrDefault(ca => ca.AccId == id);
            if (acc != null)
            {
                acc.IsClosed = true;
            }
            _context.SaveChanges();

        }

        [Route("getClassCode/{Acc_type}")]
        [HttpGet]
        public List<ClassCode> GetClassCodeByAccType(string Acc_type)
        {
            classCodeList = new List<ClassCode>();
            if (Acc_type != "")
            {
                classCodeList = _context.ClassCodes.Where(cc => cc.Acc_Type.ToLower().Contains(Acc_type.ToLower())).ToList();
                return classCodeList;
            }
            else
            {
                return classCodeList;
            }
        }

        [Route("getCurrency")]
        [HttpGet]
        public List<Currency> GetCurrencies()
        {
            currencyList = new List<Currency>();

            currencyList = _context.Currencies.ToList();
            return currencyList;
        }

        [Route("getExRates")]
        [HttpGet]
        public List<ExchangeRateModel> GetExchangeRates()
        {
            List<ExchangeRateModel> exchangeRates = new List<ExchangeRateModel>();
            ExchangeRateModel exchangeRate;
            exchangeRateList = new List<ExchangeRate>();

            exchangeRateList = _context.ExchangeRates.Include("FromCurrency").Include("ToCurrency").ToList();
            foreach (ExchangeRate item in exchangeRateList)
            {
                exchangeRate = new ExchangeRateModel();
                exchangeRate.Id = item.Id;
                exchangeRate.Operator = item.Operator;
                exchangeRate.Amount = item.Amount;
                exchangeRate.FromCurrency = item.FromCurrency.currencyId;
                exchangeRate.ToCurrency = item.ToCurrency.currencyId;

                exchangeRates.Add(exchangeRate);
            }
            return exchangeRates;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
