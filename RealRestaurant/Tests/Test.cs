using Domain;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class Test
    {
        [Fact]
        public void CheckZip()
        {
            bool check = true;
            Restaurant rest = new Restaurant()
            {
                Id = 1,
                Name = "Subway",

                City = "Manhattan",
                Cuisine = "Sanduchitos",
                Address = "Downtown Manhattan",
                State = "NY",
                ZipCode = 10293,
                 Rating = 4,
            };

            foreach (char c in rest.ZipCode.ToString())
            {
                if (c < '0' || c > '9')
                    check = false;
            }

            Assert.True(check, "Zip only has one number");
        }

        public class TotalAverage
        {
            [Fact]
            public void Average()
            {
                //Given
                bool result = false;
                double[] numbers = { 1, 2, 3, 4, 5 };
                int count = 0;
                int total = 0;
                foreach (int number in numbers)
                {
                    total = total + number;
                    count++;
                }
                double actual = total / count;
                double expected = 3;
                //When
                if (actual == expected)
                {
                    result = true;
                }
                //Then
                Assert.True(result);
            }
        }

        [Fact]
        public void CheckPhone()
        {
            bool check = true;
           Customer rest = new Customer()
            {
            Id = 1,
            Name = "Estrellita",
            LastName = "Dough",
            Phone = 0986364637,
            Email = "estrellita@gmail.com"
        };

            foreach (char c in rest.Phone.ToString())
            {
                if (c < '0' || c > '9')
                    check = false;
            }

            Assert.True(check, "Phone only has numbers");
        }

        public class RatingValidation
        {
            [Fact]
            public void Rating()
            {
                //Given
                int rating = 0;
                bool result = true;
                //When
                if (rating < 1)
                {
                    result = false;
                }
                //Then
                Assert.False(result, "Rating shuld be between 1 and 5");
            }
        }

        public class IsAdmin
        {

            [Fact]
            public void AdminEntrance()
            {
                //Given
                bool result = false;
                string adminPass = "Admin";
                string truePass = "Admin";


                //When
                if (truePass == adminPass)
                {
                    result = true;
                }
                //Then
                Assert.True(result);
            }
        }

      


        //public class Repository
        //{
        //    private IDL _repo;
        //    private IDL repo;


        //    public void Test()
        //    {
        //        _repo = repo;
        //    }
        //    [Fact]

        //    public void GetUsers()
        //    {
        //        List<Domain.UserInformation> expectedType = new List<Domain.UserInformation>();

        //        var userType = _repo.GetUsers();

        //        Assert.Equal(expectedType, userType);

        //    }
        //}
        //    [Fact]
        //    public void GetReview()
        //    {
        //        int testInt = 4;

        //        var review = _reviewRepo.GetReviewObj(testInt);
        //        Console.WriteLine(testInt);

        //        Assert.True(review.Id == testInt);

        //    }

        //    [Fact]
        //    public void GetRestaurant()
        //    {
        //        string testId = "Frillies";

        //        var restaurantId = _reviewRepo.GetUserObj(testId);
        //        Console.WriteLine(testId);

        //        Assert.True(restaurantId.Name == testId);

        //    }
        //}


        //[Fact]
        //public void ZipCodeDigits()
        //{
        //    //Given
        //    bool result = false;
        //    string adminPass = "Admin";
        //    string truePass = "Admin";


        //    //When
        //    if (truePass == adminPass)
        //    {
        //        result = true;
        //    }
        //    //Then
        //    Assert.True(result);
        //}



    }
}
