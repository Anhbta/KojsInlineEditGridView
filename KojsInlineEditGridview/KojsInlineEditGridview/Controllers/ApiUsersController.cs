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

            //sort
            if(criteria.SortExpression == "UserId")
                users = criteria.SortOrder == "ASC" ? users.OrderBy(x => x.UserId).ToList() : users.OrderByDescending(x=>x.UserId).ToList();
            else if (criteria.SortExpression == "UserName" && criteria.SortOrder == "ASC")
                users = criteria.SortOrder == "ASC" ? users.OrderBy(x => x.UserName).ToList() : users.OrderByDescending(x => x.UserName).ToList();

            pageResult.TotalRecords = users.Count;
            pageResult.TotalPages = (users.Count / criteria.PageSize) + (users.Count % criteria.PageSize != 0 ? 1 : 0);

            pageResult.Results = users.Skip((criteria.PageIndex - 1) * criteria.PageSize).Take(criteria.PageSize).ToList();
            return pageResult;
        }

        private List<User> GetDumpData() {
            return new List<User>() { 
                new User{ UserId = "AIPERTI", UserName = "Handerson Wzerw",DateOfBirth="24/12/1989", Address="123 Dawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "BIPERTI", UserName = "Ackerley Amzi", DateOfBirth="24/12/1989",Address="555 Normanton, Singapore", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "CIPERTI", UserName = "Acton Cruze", DateOfBirth="24/12/1989",Address="145 Orchard Street, Singapore", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "DIPERTI", UserName = "Admaris Wzerw", DateOfBirth="24/12/1989",Address="123 Dawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "EIPERTI", UserName = "Gabby Amzi", DateOfBirth="24/12/1989",Address="555 Normanton, Singapore", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "FIPERTI", UserName = "Babe Cruze", DateOfBirth="24/12/1989",Address="145 Orchard Street, Singapore", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "GIPERTI", UserName = "Tommy Cruze", DateOfBirth="24/12/1989",Address="222 Thomson Street, Vietnam", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HIPERTI", UserName = "Gabor Wzerw", DateOfBirth="24/12/1989",Address="123 Dawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "IIPERTI", UserName = "Gabriel Amzi", DateOfBirth="24/12/1989",Address="555 Normanton, Singapore", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "JPERTIP", UserName = "Gaetan Cruze", DateOfBirth="24/12/1989",Address="145 Orchard Street, Singapore", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "KIPERTI", UserName = "Jabez Cruze", DateOfBirth="24/12/1989",Address="222 Thomson Street, Vietnam", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "LIPERTI", UserName = "Jac Wzerw", DateOfBirth="24/12/1989",Address="123 Dawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "NIPERTI", UserName = "Jacinta Amzi", DateOfBirth="24/12/1989",Address="555 Normanton, Singapore", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "OIPERTI", UserName = "Jack Cruze", DateOfBirth="24/12/1989",Address="145 Orchard Street, Singapore", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "PIPERTI", UserName = "Tommy Cruze", DateOfBirth="24/12/1989",Address="222 Thomson Street, Vietnam", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "QIPERTI", UserName = "Sabah Wzerw", DateOfBirth="24/12/1989",Address="123 Dawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "RIPERTI", UserName = "Sabra Amzi", DateOfBirth="24/12/1989",Address="555 Normanton, Singapore", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "SIPERTI", UserName = "Saburo Cruze", DateOfBirth="24/12/1989",Address="145 Orchard Street, Singapore", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "TIPERTI", UserName = "Sachi Cruze", DateOfBirth="24/12/1989",Address="222 Thomson Street, Vietnam", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "UIPERTI", UserName = "Sacagawea Wzerw", DateOfBirth="24/12/1989",Address="123 Dawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "VIPERTI", UserName = "Willson Amzi", DateOfBirth="24/12/1989",Address="555 Normanton, Singapore", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "WIPERTI", UserName = "Walden Cruze", DateOfBirth="24/12/1989",Address="145 Orchard Street, Singapore", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "XIPERTI", UserName = "Walenty Cruze", DateOfBirth="24/12/1989",Address="222 Thomson Street, Vietnam", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "ZIPERTI", UserName = "Walermar Wzerw", DateOfBirth="24/12/1989",Address="123 Dawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "AZPERTI", UserName = "Weldon Amzi", DateOfBirth="24/12/1989",Address="555 Normanton, Singapore", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "BXPERTI", UserName = "Wen Cruze", DateOfBirth="24/12/1989",Address="145 Orchard Street, Singapore", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "CQPERTI", UserName = "Kaipo Cruze", DateOfBirth="24/12/1989",Address="222 Thomson Street, Vietnam", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "DSPERTI", UserName = "Kaiser Wzerw", DateOfBirth="24/12/1989",Address="123 Dawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "ETPERTI", UserName = "Kaili Amzi", DateOfBirth="24/12/1989",Address="555 Normanton, Singapore", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "FOPERTI", UserName = "Kang Cruze", DateOfBirth="24/12/1989",Address="145 Orchard Street, Singapore", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "HQPERTI", UserName = "Kanoa Cruze", DateOfBirth="24/12/1989",Address="222 Thomson Street, Vietnam", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "KJPERTI", UserName = "Kanuha Cruze", DateOfBirth="24/12/1989",Address="123 Drawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "QWPERTI", UserName = "Kanye Wzerw", DateOfBirth="24/12/1989",Address="123 Dawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "KJPERTI", UserName = "Kapila Amzi", DateOfBirth="24/12/1989",Address="555 Normanton, Singapore", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "CFPERTI", UserName = "Kanta Cruze", DateOfBirth="24/12/1989",Address="145 Orchard Street, Singapore", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "LHDERTI", UserName = "Caden Cruze", DateOfBirth="24/12/1989",Address="222 Thomson Street, Vietnam", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "ZAQERTI", UserName = "Cadman Wzerw", DateOfBirth="24/12/1989",Address="123 Dawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "TEQERTI", UserName = "Cael Amzi", DateOfBirth="24/12/1989",Address="555 Normanton, Singapore", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "PUYERTI", UserName = "Caesar Cruze", DateOfBirth="24/12/1989",Address="145 Orchard Street, Singapore", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "LFSERTI", UserName = "Caius Cruze", DateOfBirth="24/12/1989",Address="222 Thomson Street, Vietnam", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "ZPOERTI", UserName = "Cajsa Wzerw", DateOfBirth="24/12/1989",Address="123 Dawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "BMNBVXI", UserName = "Cannon Amzi", DateOfBirth="24/12/1989",Address="555 Normanton, Singapore", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "QWEERTI", UserName = "Cara Cruze", DateOfBirth="24/12/1989",Address="145 Orchard Street, Singapore", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "DAQERTI", UserName = "Carberry Cruze", DateOfBirth="24/12/1989",Address="222 Thomson Street, Vietnam", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "MKIERTI", UserName = "Caridad Wzerw", DateOfBirth="24/12/1989",Address="123 Dawson Street, USA", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "CDEERTI", UserName = "Carlin Amzi",DateOfBirth="24/12/1989", Address="555 Normanton, Singapore", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "LMOERTI", UserName = "Carlinhos Cruze", DateOfBirth="24/12/1989",Address="145 Orchard Street, Singapore", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },
                new User{ UserId = "CXZERTI", UserName = "Carlisle Cruze", DateOfBirth="24/12/1989",Address="222 Thomson Street, Vietnam", Email="xxx@gmail.com", MarritalStatus="Married", PhoneNumber="(012) 8999-999" },                
            };
        }
    }
}
