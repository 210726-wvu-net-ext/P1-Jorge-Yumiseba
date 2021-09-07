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
        List<UserInformation> GetUsers();
        List<Customer> ListUser();
        List<ReviewSecond> GetReviews();
        List<Suggestion> ListSuggestion();
        Customer AddUser(Customer x);
        Customer DeleteUser(Customer x);
        UserInformation DeleteUserInfo(UserInformation x);
        Review DeleteReview(Review x);

        ReviewSecond DeleteReviewSecond(ReviewSecond x);
        Restaurant DeleteRestaurant(Restaurant x);
        Restaurant SearchRestaurant(string x);

        Restaurant AddRestaurant(Restaurant a);
        Suggestion AddSuggestion(Suggestion x);
        UserInformation AddUserInfo(UserInformation x);

        ReviewSecond AddReviewSecond(ReviewSecond x);
    }
}
