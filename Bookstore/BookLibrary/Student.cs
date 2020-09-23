/*
 * Andrew Larkins
 * 09/21/20
 * Student class to store info. 
 */ 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Student
    {
        String id;
        String name;
        String address;
        String phoneNum;
        String campus;

        public Student(String id, String name, String address, String phoneNum, String campus)
        {
            id = this.Id;
            name = this.Name;
            address = this.Address;
            phoneNum = this.PhoneNum;
            campus = this.Campus;
        }

        public Student()
        {

        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string PhoneNum { get => phoneNum; set => phoneNum = value; }
        public string Campus { get => campus; set => campus = value; }
    }
}
