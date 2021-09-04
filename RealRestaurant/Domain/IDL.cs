using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IDL
    {
        List<Restaurant> GetRestaurants();
        List<Customer> ListUser();
        Customer AddUser(Customer x);
        Customer DeleteUser(Customer x);
        Review DeleteReview(Review x);
        Restaurant DeleteRestaurant(Restaurant x);
        Restaurant SearchRestaurant(string x);

        Restaurant AddRestaurant(Restaurant a);
        Suggestion AddSuggestion(Suggestion x);
    }
}
