using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    // [ApiController]
    // [Route("api/[controller]")]
    //public class UsersController : ControllerBase
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        
        //Synchronous Method
        //Long Hand method only required if we are going to do extra work with the data
        // var users = _context.Users.ToList();
        // return users;


        //Short Hand Method if we do not need to preform any extra work on the data
        //return _context.Users.ToList();


        //ASynchronous Method - best Practice
        return await _context.Users.ToListAsync();

    }
    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        //Synchronous Method
        //Long Hand method only required if we are going to do extra work with the data
        // var user = _context.Users.Find(id);
        // return user;

         //Short Hand Method if we do not need to preform any extra work on the data
        //return _context.Users.Find(id);


        //ASynchronous Method - Best Practice
        return await _context.Users.FindAsync(id);
    }




    }
}