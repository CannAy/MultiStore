using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiStore.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository; //private tanımlamamızın sebebi sadece bu sınıf içerisinde kullanılacak olmasıdır. readonly tanımlamamızın sebebi ise bu değişkenin sadece bir kere set edilebilir olmasıdır.

		public CreateAddressCommandHandler(IRepository<Address> repository) //constructor metodumuzu hazırladık.
        {
            _repository = repository;
        }
        public async Task Handle(CreateAddressCommand createAddressCommand) //Handle anlamı , bu metodun bir komutu ele alacağını belirtir.
		{ 
            //CreateAddressCommand sınıfından bir nesne alacak ve bu nesneyi kullanarak bir Address nesnesi oluşturacak.
			await _repository.CreateAsync(new Address
            {
                City= createAddressCommand.City,
                Detail= createAddressCommand.Detail,
                District= createAddressCommand.District,
                UserId= createAddressCommand.UserId
            }); //map'leme yapmadığımız için atamaları tek tek yapmamız gerekiyor.
		}
    }
}
