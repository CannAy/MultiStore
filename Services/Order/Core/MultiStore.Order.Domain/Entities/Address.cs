using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiStore.Order.Domain.Entities
{
    public class Address //public kullanılmasının sebebi diğer katmanlar (API, Application, Infrastructure) tarafından erişilebilir olmasıdır.
	{
        public int AddressId { get; set; }
        public string UserId { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}
