using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Store;

namespace App9.Models
{
    public class Invoice
    {
        public decimal Amount { get; set; }
        public bool IsPaid { get; private set; }

        public Invoice( ) {
            IsPaid = false;
        }

        public void Pay( ) {
            IsPaid = true;
        }
    }
}
