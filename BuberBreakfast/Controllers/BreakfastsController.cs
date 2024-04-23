using Microsoft.AspNetCore.Mvc;
using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;
using BuberBreakfast.Services.Breakfasts;

namespace BuberBreakfast.Controllers;

[ApiController]
[Route("breakfasts")] // magic: takes the name of class without 'controller'

public class BreakfastsController : ControllerBase
{
    // each time a request is made, the program creates a new breakfast controller. Then, when you have an interface,
    // it doesn't know how to create the interface.
    private readonly IBreakfastService _breakfastService;

    public BreakfastsController(IBreakfastService breakfastService)
    {
        _breakfastService = breakfastService;
    }

    [HttpPost]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request)
    {
        // mapping the data we get in the request to the language that our application speaks
        var breakfast = new Breakfast(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet);

        // application logic
        _breakfastService.CreateBreakfast(breakfast);

        // taking the data from the system and converting back to the API definition, returning the response
        var response = new BreakfastResponse(breakfast.Id,
        breakfast.Name, breakfast.Description, breakfast.StartDateTime, breakfast.EndDateTime, breakfast.LastModifiedDateTime, breakfast.Savory, breakfast.Sweet);

        return CreatedAtAction(
            actionName: nameof(GetBreakfast),
            routeValues: new { id = breakfast.Id },
            value: response);

    }

    [HttpGet("{id:guid}")]
    public IActionResult GetBreakfast(Guid id)
    {
        Breakfast breakfast = _breakfastService.GetBreakfast(id);

        var response = new BreakfastResponse(breakfast.Id, breakfast.Name, breakfast.Description, breakfast.StartDateTime, breakfast.EndDateTime, breakfast.LastModifiedDateTime, breakfast.Savory, breakfast.Sweet);

        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertBreakfast(Guid id, CreateBreakfastRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id)
    {
        return Ok(id);
    }
}