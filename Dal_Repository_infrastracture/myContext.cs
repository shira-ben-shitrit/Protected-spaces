using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace Dal_Repository_infrastracture
{
    

    public class myContext: DbContext
    {
        //appsettingבנאי הזה שימושי רק לאחר שהמסד קיים ומקבל את ערכי הפרמטר דרך ההזרקה שעושה שימוש ב
        //בכל פעם שנעשה שינוי באובייקטים ונרצה שוב להפעיל את פקודות עדכון המסד ניירק בנאי זה
        public myContext(DbContextOptions<myContext> options)
        : base(options)
        {
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<opinion> Opinions { get; set; }
        public DbSet<Structure> Structures { get; set; }
        /*קוד זה יפתח בכל פעם שנרצה לעדכן שוב את המסד
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     => optionsBuilder.UseSqlServer("Server=DESKTOP-L9S4R74;Database=Db_finalProject;Trusted_Connection=True;TrustServerCertificate=True");
        */
        
    }
}
