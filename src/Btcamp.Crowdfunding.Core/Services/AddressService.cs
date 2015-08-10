using Btcamp.Crowdfunding.Core.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btcamp.Crowdfunding.Core.Services
{
    public class AddressService : Infrastructure.ServiceBase<Address>, Interface.IAddressService
    {
        public AddressService(Infrastructure.IRepository<Address> repository)
            : base(repository)
        {

        }
    }
}
