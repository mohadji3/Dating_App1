using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class AuthController: ControllerBase
    {
        public IAuthRepository _repo { get; }
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
            
        }

        [HttpPost("register")]

        public async Task<IActionResult> Register(string username, string password){

            //validate request
            username = username.ToLower();

            if (await _repo.UserExists(username))
                return BadRequest("Username already exists");
            
            var userToCreate = new Users {
                Username = username
            };
            
            var createdUser = await _repo.Register(userToCreate, password);

            //return CreatedAtRoute();
            return StatusCode(201);
        }
    }
}