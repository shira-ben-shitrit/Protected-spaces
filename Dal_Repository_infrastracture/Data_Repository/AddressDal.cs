using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace Dal_Repository_infrastracture.Data_Repository
{
   public class AddressDal:AddressInterfaceDAL
    {
        public myContext DB;

        public AddressDal(myContext db)
        {
            this.DB = db;
        }

        public async Task<int> addAddress(Address address)
        {
            if (address == null)
                throw new ArgumentNullException(nameof(address));

            if (string.IsNullOrEmpty(address.ContactPerson) || string.IsNullOrEmpty(address.PhoneNumber))
                throw new ArgumentException("פרטי איש קשר חסרים");

            //מוודא שבעצם קיים לי המבנה באוביקט הכתובת שקיבלתי
            if (address.Structure == null || string.IsNullOrEmpty(address.Structure.Name))
                throw new Exception("נדרש שם של סוג מבנה (Structure)");

            // אם יש מבנה אני בודקת אם המבנה כבר קיים בשביל לא להוסיפו סתם לטבלת המבנים
            var existingStructure = await DB.Structures
                .FirstOrDefaultAsync(s => s.Name == address.Structure.Name);
            //אם אין כזה מבנה אז ניצור חדש ונוסיפו לטבלה
            if (existingStructure == null)
            {
                
                existingStructure = new Structure
                {
                    Name = address.Structure.Name,
                    Level = address.Structure.Level 
                };

                await DB.Structures.AddAsync(existingStructure);
                await DB.SaveChangesAsync(); 
            }

            // שיוך המבנה לכתובת
            address.StructureId = existingStructure.Id;
            address.Structure = null;

            await DB.Addresses.AddAsync(address);
            await DB.SaveChangesAsync();

            return address.Id;
        }    



        public async Task<List<Address>> GetAllAddress()
        {
            return await DB.Addresses.Include(a => a.Structure).ToListAsync();
        }

    }
}
