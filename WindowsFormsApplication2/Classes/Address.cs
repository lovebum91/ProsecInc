using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProsecInc.Classes
{
    public class Address
    {
         /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// IP Address
        /// </summary>
        public string IPAddress { get; set; }

        /// <summary>
        /// Port
        /// </summary>
        public int port_number { get; set; }

        /// <summary>
        /// Statuscheck.
        /// </summary>
        public string Statuscheck { get; set; }
    }
}
