using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Linq;

namespace UAT_Class_Project_Inhertance
{
    // Users base class with demographic information
    public class Users
    {
        // this way we can access all users in one place
        // to do this it must be a static class 
        // if you're doing async operations you `need to lock the object before updating to avoid concurrentcy issues
        private static List<Users> UserList = new List<Users>();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string WebSite { get; set; }
        public Users(string firstName, string lastName, string email, string webSite)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = email;
            WebSite = webSite;
            UserList.Add(this);
        }
        public static List<Users> getUsers()
        {
            return UserList;
        }
    }

    public class Address
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
    public class HomeAddress : Address
    {
        public string AddressType { get; set; }
        public string TypeOfHome { get; set; }
    }
    public class CorporateAddress:Address
    {
        public string AddressType = "Home";
        public CorporateAddress(string address, string city, string state, string zip)
        {
            StreetAddress = address;
            City = city;
            State = state;
            ZipCode = zip;

        }
        public string getSerializeObject()
        {
            return this.ToString();
        }
    }
    public class AdminUser : Users
    {
        public string Role { get; set; }
        public Users UserDetails { get; set; }

        public CorporateAddress CorporateLocation { get; set; }
        public HomeAddress HomeLocation { get; set; }

        public AdminUser():base("Clarence", "Brathwaite", "cbrathwa2002@yahoo.com", "clarence.brathwaite@jaacSoftwareConsulting.com")
        {
            this.Role = "Administrator";
            CorporateLocation = new CorporateAddress("123 Ben Franklin Blvd ", "Philadelphia", "Pennsylavania", "32111");
            HomeLocation = new HomeAddress();
        }
    }

    public class Wrapper
    {
        public Users _User { get; set; }
        public HomeAddress HomeAddr { get; set; }

        public CorporateAddress CorpAddr { get; set; }
        public Wrapper(string firstName,String lastName, string email, string web, string streetAddress)
        {

            CorpAddr = new CorporateAddress("15 Redbud Road", "Piscataway","New Jersey", "07134");
            HomeAddr = new HomeAddress { AddressType = "Home", StreetAddress=streetAddress };
            _User = new Users(firstName,lastName,email,web);// FirstName = firstName, LastName = lastName, EmailAddress = email, WebSite = web };

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var cb = new Wrapper("Clarence", "Brathwaite", "Clarence.Brathwaite@Ey.com", "EY.com","300 E Maine Ave");
            var thomas = new Wrapper("Thomas", "Brathwaite", "Thomas.Brathwaite@TheRightSolution.com", "TheRightSolution.com", "319 Jefferson Ave");
            var tim = new Wrapper("Timothy", "Brathwaite", "no email on file", "no web site on file","319 Jefferson Ave");
            var mayne = new Wrapper("Sharmayne", "Ward-Brathwaie", "wardsharmayne@yahoo.com", "nettenllc.com","300 E Maine Ave");
  
            Console.WriteLine("{0}\t {1} \t{2} \t{3}", "First Name", " Last Name", "Email", "Web Site", " Home Address");

                Console.WriteLine("==================================================================");


            new AdminUser();

            var list = Users.getUsers();
          
            foreach(var user in list)
            {
                Console.WriteLine("{0} {1} {2} {3}", user.FirstName, user.LastName, user.EmailAddress, user.WebSite);
                switch (user.FirstName)
                {
                    case "Clarence":
                        Console.WriteLine("\t\tClarence's home address is " + cb.HomeAddr.StreetAddress);
                        break;
                    case "Thomas":
                        Console.WriteLine("\t\t==> {0}", "thomas' Home Address is " + thomas.HomeAddr.StreetAddress);
                        break;
                    case "Timothy":
                        Console.WriteLine("\t\t==> Timothy's home address is " + tim.HomeAddr.StreetAddress);
                        break;
                    default:
                        Console.WriteLine("\t\t==> No address on file...");
                        break;
  
                }
            }
         
            Console.WriteLine("Hello World!");
        }
    }
}
