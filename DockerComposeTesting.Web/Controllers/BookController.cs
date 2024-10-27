using DockerComposeTesting.Core.Domain;
using DockerComposeTesting.Data.Abstractions;
using DockerComposeTesting.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DockerComposeTesting.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BookController> _logger;

        public BookController(IUnitOfWork unitOfWork, ILogger<BookController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.BookRepository.GetAllAsync(cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookRequest request, CancellationToken cancellationToken)
        {
            var entity = new Book{ }; // todo map by request
            var result = await _unitOfWork.BookRepository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveAsync();
            return Created();
        }
    }
}
