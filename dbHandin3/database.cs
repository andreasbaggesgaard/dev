using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dbHandin3
{
    public class database
    {
        public string dbConnection()
        {
            return @"data source = .\sqlexpress; integrated security = true; database = pokemonRun";
        }   
    }
} 