using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.Application.DBOperations;


namespace WebApi.Controllers{

    [ApiController]
    [Route("[controller]s")]
    public class AuthorController : ControllerBase
    {
        private IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public AuthorController (IBookStoreDbContext context, IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }
        [HttpGet]
        public ActionResult GetAuthors()
        {
            GetAuthorsQuery query=new GetAuthorsQuery(_context,_mapper);
            var obj=query.Handle();
            return Ok(obj);
        }
        [HttpGet("id")]
        public ActionResult GetAuthorDetail(int id)
        {
            GetAuthorDetailQuery query=new GetAuthorDetailQuery(_context,_mapper);
            query.AuthorId=id;
            GetAuthorDetailQueryValidator validator=new GetAuthorDetailQueryValidator();
            validator.ValidateAndThrow(query);
            var obj=query.Handle();
            return Ok(obj);
        }
        
       
        [HttpPut("id")]
        public IActionResult UpdateAuthor(int id,[FromBody] UpdateAuthorModel updateAuthor)
        {
            UpdateAuthorCommand command=new UpdateAuthorCommand(_context);
            command.Id=id;
            command.Model=updateAuthor;
            UpdateAuthorCommandValidator validator=new UpdateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();        
        }
        [HttpPost]
        public IActionResult CreateAuthor([FromBody] CreateAuthorModel newAuthor)
        {
            CreateAuthorCommand command=new CreateAuthorCommand(_context,_mapper);
            command.Model=newAuthor;
            CreateAuthorCommandValidator validator=new CreateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpDelete("id")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand command=new DeleteAuthorCommand(_context);
            command.AuthorId=id;
            DeleteAuthorCommandValidator validator=new DeleteAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();

        }



    }
}