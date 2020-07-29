using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class TransferRequest
    {
        public decimal amount { get; set; }//required
        public string beneficiary_account_id { get; set; }//optional
        public string beneficiary_id { get; set; }//optional
        public string cut_off_time_implementation { get; set; }//optional
        public string ledger_from_id { get; set; }//optional
        public string ledger_id { get; set; }//optional
        public string payment_credit_date { get; set; }//optional
        public string payment_type { get; set; }//required
        public string reference { get; set; }//optional
        public object transaction_meta { get; set; }//optional
        public string who_pays_charges { get; set; }//optional
    }
}
