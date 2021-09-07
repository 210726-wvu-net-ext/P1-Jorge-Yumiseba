using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain
{
    public class Suggestion
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public Suggestion()
        {

        }

        public Suggestion(int id)
        {
            this.Id = id;
        }
   
        public Suggestion(string name, string email, string message)
        {

            this.Name = name;
            this.Email = email;
            this.Message = message;
        }

    }
}

