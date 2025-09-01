using Core.Models;
using Core.Repositories;
using Core.ServicesBll;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bll_Services
{
    public class AddressBLL :AddressInterfaceBLL
    {
        // -הזרקה של ה dal
        AddressInterfaceDAL Adal;
        public AddressBLL(AddressInterfaceDAL Adal)
        {
            this.Adal = Adal;
        }
        public async Task<List<Address>> GetByMonth(DateTime d)
        {
            var allAddresses = await Adal.GetAllAddress();
            var filtered = allAddresses.Where(a => a.CreatedAt.Month == d.Month && a.CreatedAt.Year == d.Year).ToList();

            return filtered;
        }

        public async  Task<int> addAddress(Address address)
         {
            return await Adal.addAddress(address);
         }

        public async Task<List<Address>> GettingNearestPlaces(decimal point1,decimal point2)
        {
            List<Address> l = await Adal.GetAllAddress();
            //כאן אני יוצרת טופל שיכיל שדה המיצג את המרחק של כל כתובת מרשימת הכתובות לנקודה שאני נמצאת בה
            //  המחשבת את המרחק האוירי CalculateDistanceInKm על ידי שימוש בפונקציה 
            var lWithDistances = l.Select(a => (address: a,
                                drivingTimeSec: CalculateDistanceInKm(point1, point2, a.MapLocation_point1, a.MapLocation_point2)))
                                .ToList();
            //לאחר מכן אני מפעילה עליו מיון שימין לי לפי רמת הקירבה והוא מחזיר רק את 10 הראשונים
            return  SortByDrivingTime(lWithDistances).Take(10).Select(t => t.address).ToList();
        }

        private decimal CalculateDistanceInKm(decimal lat1, decimal lon1, decimal lat2, decimal lon2)
        {
            const double R = 6371; // רדיוס כדור הארץ בק"מ

           
            double latRad1 = DegreesToRadians((double)lat1);
            double latRad2 = DegreesToRadians((double)lat2);
            double deltaLat = DegreesToRadians((double)(lat2 - lat1));
            double deltaLon = DegreesToRadians((double)(lon2 - lon1));

            double a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                       Math.Cos(latRad1) * Math.Cos(latRad2) *
                       Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            double distance = R * c;

            return (decimal)distance;
        }
        private double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }

        public List<(Address address, decimal drivingTimeSec)>
        SortByDrivingTime(List<(Address address, decimal drivingTimeSec)> laddresses)
        {
            return laddresses.OrderBy(item => item.drivingTimeSec).ToList();
        }

    }
}
