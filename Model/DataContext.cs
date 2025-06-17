using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DataContext: DbContext
    {
        // connects app to database
            public DbSet<User> Users { get; set; } // collection of objects type User. also creates Users table (Based on the plural of the class)
            public DataContext() // add parameter if you want to specify which connection string
            {

            }
        }
    }

