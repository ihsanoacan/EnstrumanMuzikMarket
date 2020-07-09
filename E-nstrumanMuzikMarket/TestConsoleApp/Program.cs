using BLL.Service;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            UserService srv = new UserService();
            User usr = new User
            {
                Email = "dasda@dasd.com",
                Name = "murat",
                

                
            };
            srv.Add(usr);
            srv.Save();

        }
    }
}
