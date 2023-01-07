using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers;

[ApiController]
//[Route("controller")]
[Route("/")]
public class ValuesController : ControllerBase
{

    private readonly DataContext _context;

    public ValuesController(DataContext context)
    {
            _context = context;
        
    }

    //[HttpGet(Name = "GetWeatherForecast")]
    [HttpGet]
    [Route("accueil")]
    public async Task<IActionResult> GetValues()
    {
        var values = await _context.Values.ToListAsync();
        //return Ok(values);

        return Ok(values);
    }

    [HttpGet]
    [Route("accueil/{id}")]
    public async Task<IActionResult> GetValue(int id)
    {
        var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);

        return Ok(value);
    }
}
