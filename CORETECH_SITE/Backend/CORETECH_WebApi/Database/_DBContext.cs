using Common;
using Common.Consts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public partial class _DBContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);


            if (string.IsNullOrWhiteSpace(AppConfig.ConnectionString))
            {
#if DEBUG
                AppConfig.ConnectionString = Consts_Debug.DB_ConnectionString;
#else
			    throw new KeyNotFoundException("Не указан ConnectionString");
#endif
            }

            optionsBuilder.UseSqlServer(AppConfig.ConnectionString);

        }


        public bool IsValidConnection()
        {
            try
            {
                this.GetDateTime();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        internal DateTime GetDateTime()
        {
            var dQuery = this.Database.SqlQueryRaw<DateTime>("select current_timestamp;");
            DateTime dbDate = dQuery.AsEnumerable().First(); //https://stackoverflow.com/questions/2585272/how-to-ask-the-database-server-for-current-datetime-using-entity-framework
            return dbDate;
        }

    }
}
