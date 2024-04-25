using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers;

public class ErrorsControler : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        // this is an error from the Controller base
        return Problem();
    }
}