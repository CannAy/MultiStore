using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries
{
    public class GetAddressByIdQuery //listeleme işlemlerinden parametre tutacak
    {
        public int Id { get; set; } //parametre olarak id alacak

		public GetAddressByIdQuery(int id) //ctor oluşturmamızın sebebi id'yi set etmek
		{
            Id = id;
        }
    }
}
