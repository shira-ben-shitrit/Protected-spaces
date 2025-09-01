using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface AddressInterfaceDAL
    {
        Task<int> addAddress(Address address);
        Task<List<Address>> GetAllAddress();
    }
}
