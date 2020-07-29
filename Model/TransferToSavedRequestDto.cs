using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class TransferToSavedRequestDto
    {
        public string currency { get; set; }
        public string amount { get; set; }
        public string description { get; set; }
        public string fromAccountReference { get; set; }
        public string toAccountReference { get; set; }
    }
}
