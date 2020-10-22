using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserProject.API.Models;
using UserProject.Core.Extensions;
using UserProject.Data.Infrastructures;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        IUnitOfWork _uow;
        public UserController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public IEnumerable<UserViewModel> GetList()
        {
            return _uow.Users.FindBy(user => user.Id == HttpContext.User.Identity.Name.ToInt()).Select(x=> new UserViewModel { 
                Address = new Address
                {
                    City = x.City,
                    Latitude = x.Latitude,
                    Longitude = x.Longitude,
                    Street = x.Street,
                    Suite = x.Suite,
                    Zipcode = x.Zipcode
                },
                Company = new Company
                {
                    BS = x.BS,
                    CatchPhrase = x.CatchPhrase,
                    Companyname = x.Companyname
                },
                Id = x.Id,
                Email = x.Email,
                Name = x.Name,
                Phone = x.Phone,
                Username = x.Username,
                Website = x.Website
            });
        }

      
        [HttpGet("{id}")]
        public ActionResult<UserViewModel> Get(int id)
        {
            if (id != HttpContext.User.Identity.Name.ToInt()) return Forbid("You don't have permission");

            var result = _uow.Users.GetSingle(user => user.Id == id);
            return new UserViewModel
            {
                Address = new Address
                {
                    City = result.City,
                    Latitude = result.Latitude,
                    Longitude = result.Longitude,
                    Street = result.Street,
                    Suite = result.Suite,
                    Zipcode = result.Zipcode
                },
                Company = new Company
                {
                    BS = result.BS,
                    CatchPhrase = result.CatchPhrase,
                    Companyname = result.Companyname
                },
                Id = result.Id,
                Email = result.Email,
                Name = result.Name,
                Phone = result.Phone,
                Username = result.Username,
                Website = result.Website
            };
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id,[FromBody] UpdateUserViewModel model)
        {
            if (id != HttpContext.User.Identity.Name.ToInt()) return Forbid("You don't have permission");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = _uow.Users.GetSingle(x=>x.Id == id);

            user.Name = model.Name;
            user.Username = model.Username;
            user.Email = model.Email;
            user.Phone = model.Phone;
            user.Website = model.Website;
            user.Companyname = model.Companyname;
            user.Street = model.Street;
            user.Suite = model.Suite;
            user.City = model.City;
            user.Zipcode = model.Zipcode;
            user.Latitude = model.Latitude;
            user.Longitude = model.Longitude;
            user.CatchPhrase = model.CatchPhrase;
            user.BS = model.BS;

            _uow.Users.Update(user);
            _uow.Commit();

            return NoContent();
        }

    }
}
