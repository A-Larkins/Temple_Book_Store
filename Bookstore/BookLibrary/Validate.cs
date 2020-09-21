/*
 * Andrew Larkins
 * 09/21/20
 * Validate class with some boolean methods for validation.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Validate
    {

        public Validate()
        {

        }

        public Boolean isValidID(String id)
        {
            return id != null && id.Length == 8 && !id.Equals("") && !id.Equals("        ");
        }

        public Boolean isValidName(String name)
        {
            return name != null && !name.Equals("");
        }

        public Boolean isValidAddress(String address)
        {
            return address != null && !address.Equals("");
        }

        public Boolean isValidPhoneNum(String num)
        {
            return num != null && num.Length == 10 && !num.Equals("          ");
        }

    }
}
