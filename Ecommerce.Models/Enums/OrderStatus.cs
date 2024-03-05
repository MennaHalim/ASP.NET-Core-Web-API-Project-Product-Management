using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models.Models
{
    public enum OrderStatus
    {
        Unconfirmed,
        Pending,
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }
}
