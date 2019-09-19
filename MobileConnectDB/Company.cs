using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MobileConnectDB
{
    [Table ("Company")]
    public class Company
    {
        [PrimaryKey]
        public int Id {get; set;}
        [MaxLength (50)]
        public string Name { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return this.Name + " (" + this.Address + " )";
        }
    }
}
