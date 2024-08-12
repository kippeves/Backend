using System.Net;
using Backend.Class.DTO;
using Backend.Class.Records;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace Backend.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]/[action]")]
public class BookController(IBookRepository bookRepo) : ControllerBase
{
    public IBookRepository BookRepo { get; } = bookRepo;

    [HttpPost]
    public IActionResult Add(CreateBookDTO newBook)
    {
        var createdBook = BookRepo.Create(newBook);
        if (createdBook is null) return BadRequest("Failed to add book");
        return CreatedAtAction(nameof(Add), new { createdBook.Id }, createdBook);
    }

    [HttpPut]
    public IActionResult Update([FromBody] UpdateBookDTO newState) => BookRepo.Update(newState) ? new OkObjectResult(new ApiStatus(ReturnStatus.Success)) : BadRequest();

    [HttpDelete]
    public IActionResult Delete(int id) => BookRepo.Delete(id) ? new OkObjectResult(new ApiStatus(ReturnStatus.Success)) : BadRequest();

    [HttpGet]
    public IActionResult GetBookById(int id) => BookRepo.Exists(id) ? new OkObjectResult(BookRepo.Get(id)) : BadRequest();

    [HttpGet]
    public IActionResult GetAll() => new OkObjectResult(BookRepo.GetAll());
}
