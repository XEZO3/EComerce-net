using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.common
{
    public static class SharedIds
    {
        public static int UserId { get; set; }
        public static int CustomerId { get; set; }
        public static int GetUserId() { 
        return UserId;
        }
        public static int GetCustomerId() {
            return CustomerId;
        }
    }
}
