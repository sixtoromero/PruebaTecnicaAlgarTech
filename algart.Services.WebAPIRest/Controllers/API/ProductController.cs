using algart.Application.DTO;
using algart.Application.Interface;
using algart.Services.WebAPIRest.Helpers;
using algart.Transversal.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System;

namespace algart.Services.WebAPIRest.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductApplication _Application;
        private readonly AppSettings _appSettings;

        public ProductController(IProductApplication _Application,
                                  IOptions<AppSettings> appSettings)
        {
            this._Application = _Application;
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            Response<IEnumerable<ProductDTO>> response = new Response<IEnumerable<ProductDTO>>();

            try
            {
                response = await _Application.GetAllAsync();
                if (response.IsSuccess)
                {
                    response.ReponseCode = response.ReponseCode = (int)HttpStatusCode.OK;
                    return Ok(response);
                }
                else
                {
                    response.ReponseCode = response.ReponseCode = (int)HttpStatusCode.PreconditionFailed;
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                response.ReponseCode = (int)HttpStatusCode.InternalServerError;

                return BadRequest(response);
            }
        }

    }
}
