using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProsecInc.Classes;

namespace ProsecInc.Extend
{
    public class AddressUtil
    {
        /// <summary>
        /// save list object
        /// </summary>
        /// <param name="offices"></param>
        public void SaveFile(IEnumerable<Address> addresses)
        {
            string filePath = Application.StartupPath + "\\Data\\addresses.json";

            var addStr = JsonConvert.SerializeObject(addresses);
            File.WriteAllText(filePath, addStr);
        }

        /// <summary>
        /// Get list object
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Address> Gets()
        {
            try
            {
                string filePath = Application.StartupPath + "\\Data\\addresses.json";
                using (var r = new StreamReader(filePath))
                {
                    var json = r.ReadToEnd();
                    var offices = JsonConvert.DeserializeObject<List<Address>>(json);
                    return offices;
                }
            }
            catch (FileNotFoundException e)
            {
                return new List<Address>();
            }
        }

        /// <summary>
        /// Add new object
        /// </summary>
        /// <param name="office"></param>
        public bool Create(Address address)
        {
            var result = false;
            if (address == null)
            {
                throw new Exception("Null Address");
            }
            var addresses = Gets().ToList();
            var add = addresses.FirstOrDefault(o => o.IPAddress == address.IPAddress && o.port_number == address.port_number);
            if (add == null)
            {
                address.Id = addresses.Any() ? addresses.Last().Id + 1 : 1;
                addresses.Add(address);
                SaveFile(addresses);
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Get one object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Address Get(int id)
        {
            var addresses = Gets().ToList();
            return addresses.FirstOrDefault(o => o.Id == id);
        }

        /// <summary>
        /// Update object
        /// </summary>
        /// <param name="office"></param>
        public bool Update(Address address)
        {
            var result = false;
            if (address == null)
            {
                throw new Exception("Null Address");
            }
            var addresses = Gets().ToList();
            var add = addresses.FirstOrDefault(o => o.IPAddress == address.IPAddress && o.port_number == address.port_number);
            if (add == null)
            {
                for (var i = 0; i < addresses.Count; i++)
                {
                    if (addresses[i].Id == address.Id)
                    {
                        addresses[i] = address;
                        SaveFile(addresses);
                        result = true;
                    }
                }
            }


            return result;
        }

        /// <summary>
        /// Delete thông tin cơ quan
        /// </summary>
        /// <param name="office"></param>
        public void Delete(int id)
        {
            var addresses = Gets().ToList();
            for (var i = 0; i < addresses.Count; i++)
            {
                if (addresses[i].Id == id)
                {
                    addresses.Remove(addresses[i]);
                    break;
                }
            }
            SaveFile(addresses);
        }   
    }
}
