using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiStore.Order.Domain.Entities
{
    public class Ordering
    {
        public int OrderingId { get; set; } // {get; set;} anlamı bu property'nin dışarıdan set edilebilir ve okunabilir olduğudur.
		public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
