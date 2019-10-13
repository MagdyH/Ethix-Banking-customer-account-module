using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ethix_NG_API.Model
{
    public class CustomerAccountViewModel
    {
        public int AccId { get; set; }
        public string Acc_Type { get; set; }       
        public string Acc_Number { get; set; }
        public string Class_Code { get; set; }       
        public decimal Openning_Bal { get; set; }
        public bool IsClosed { get; set; }
        public int CurrencyId { get; set; }
        public int CustomerId { get; set; }
        public string Currency { get; set; }
        public int currDecimal { get; set; }
    }

    public class CustomerAccountListViewModel
    {
        public CustomerViewModel Customer { get; set; }
        public List<CustomerAccountViewModel> CustomerAccountList { get; set; }
    }

    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        public string CustmerName { get; set; }
        public DateTime OpenDate { get; set; }
        public string BranchName { get; set; }
    }

    public class ExchangeRateModel
    {
        public int Id { get; set; }
        public string Operator { get; set; }
        public decimal Amount { get; set; }
        public int FromCurrency { get; set; }
        public int ToCurrency { get; set; }
    }
}
