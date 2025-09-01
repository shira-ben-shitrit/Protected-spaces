using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ServicesBll
{
   public interface AddressInterfaceBLL
    {
        Task<int> addAddress(Address address);
        Task<List<Address>> GetByMonth(DateTime date);
        Task<List<Address>> GettingNearestPlaces(decimal point1, decimal point2);
    }
}
