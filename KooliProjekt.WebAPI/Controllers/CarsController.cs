using KooliProjekt.Application.Features.CarModels;
using KooliProjekt.Application.Features.Cars;
using KooliProjekt.Application.Infrastructure.Files;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.IO;
using System.Threading.Tasks;

namespace KooliProjekt.WebAPI.Controllers
{
    public class CarsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            var query = new GetCarQuery { Id = id };
            var car = await _mediator.Send(query);
            if (car == null)
            {
                return NotFound();
            }
            return Result(car);
        }

        [HttpGet("list/{page}/{pageSize}")]
        public async Task<IActionResult> List(int page, int pageSize)
        {
            var query = new ListCarsQuery
            {
                Page = page,
                PageSize = pageSize
            };

            var cars = await _mediator.Send(query);
            return Result(cars);
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save(SaveCarCommand command)
        {
            var result = await _mediator.Send(command);
            return Result(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCarCommand command)
        {
            var result = await _mediator.Send(command);
            return Result(result);
        }

        [HttpPost("AddFile")]
        public async Task<IActionResult> AddFile(int id, IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            var fileName = Guid.NewGuid().ToString() + extension;
            using var inputStream = file.OpenReadStream();

            var command = new AddFileCommand();
            command.CarId = id;
            command.FileName = fileName;
            command.InputStream = inputStream;

            var result = await _mediator.Send(command);
            return Result(result);
        }

        [HttpDelete("DeleteFile")]
        public async Task<IActionResult> DeleteFile([FromBody] DeleteFileCommand command)
        {
            var result = await _mediator.Send(command);
            return Result(result);
        }

        [HttpGet("GetFile")]
        public async Task<IActionResult> GetFile(int carId)
        {
            if (carId <= 0)
            {
                return BadRequest();
            }

            var command = new GetFileCommand
            {
                CarId = carId,
            };

            var storedFile = await _mediator.Send(command);
            if (storedFile == null)
            {
                return NotFound();
            }

            var contentTypeProvider = new FileExtensionContentTypeProvider();
            if (!contentTypeProvider.TryGetContentType(storedFile.FileName, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            return File(storedFile.Content, contentType, storedFile.FileName);
        }

        [HttpGet("ListFiles")]
        public async Task<IActionResult> ListFiles()
        {
            var files = await _mediator.Send(new ListFilesCommand());
            return Ok(files);
        }
    }
}
