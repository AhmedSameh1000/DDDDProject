using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BuberDinner.Application.Bases;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("Api/[Controller]")]
    public class AppControllerBase : ControllerBase
    {
        public ObjectResult NewResult<T>(Response<T> response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return Ok(response);

                case HttpStatusCode.Created:
                    return Created(string.Empty, response);

                case HttpStatusCode.Unauthorized:
                    return Unauthorized(response);

                case HttpStatusCode.BadRequest:
                    return BadRequest(response);

                case HttpStatusCode.NotFound:
                    return NotFound(response);

                case HttpStatusCode.Accepted:
                    return Accepted(string.Empty, response);

                case HttpStatusCode.UnprocessableEntity:
                    return UnprocessableEntity(response);

                default:
                    return BadRequest(response);
            }
        }
    }
}
