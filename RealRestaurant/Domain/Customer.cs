using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public double Phone { get; set; }
        public string Email { get; set; }

        public virtual List<Review> Reviews { get; set; }
        public Customer()
        {

        }
        public Customer(int id)
        {
            this.Id = id;
        }
        public Customer(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public Customer(string name, string lastname, double phone, string email)
        {

            this.Name = name;
            this.LastName = lastname;
            this.Phone = phone;
            this.Email = email;

        }
        public Customer(int id, string name, string lastname, double phone, string email)
        {
            this.Id = id;
            this.Name = name;
            this.LastName = lastname;
            this.Phone = phone;
            this.Email = email;

        }
    }
}
