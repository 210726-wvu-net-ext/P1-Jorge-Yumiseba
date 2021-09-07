using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
     public class RestaurantService
    {
        private readonly IDL _repo;

        public RestaurantService(IDL repo)
        {
            _repo = repo;
        }

        public int RemoveDuplicatePhones()
        {
            return 0;
        }


    }
}
