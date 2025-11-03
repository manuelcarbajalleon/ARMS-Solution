using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMS_LS
{
    internal class CustomerDAO
    {
        public string? connectionString = App.Config!.GetConnectionString("ARMSLSConnectionString");

        public List<Customer> customers = new List<Customer>();

    }
}
