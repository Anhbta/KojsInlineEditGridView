using KojsInlineEditGridview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KojsInlineEditGridview.Controllers
{
    public class ApiUsersController : ApiController
    {
        [HttpPost]
        public PageResult<User> GetUsers(UserCriteria criteria) {
            var pageResult = new PageResult<User>();

            var users = GetDumpData();
            pageResult.TotalRecords = users.Count;
            pageResult.TotalPages = (users.Count / criteria.PageSize) + (users.Count % criteria.PageSize != 0 ? 1 : 0);

            pageResult.Results = users.Skip((criteria.PageIndex - 1) * criteria.PageSize).Take(criteria.PageSize).ToList();
            return pageResult;
        }

        private List<User> GetDumpData() {
            return new List<User>() { 
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Tommy Cruze", Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" }
            };
        }
    }
}
