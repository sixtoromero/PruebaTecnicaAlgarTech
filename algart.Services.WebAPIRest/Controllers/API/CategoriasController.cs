using algart.Application.DTO;
using algart.Application.Interface;
using algart.Services.WebAPIRest.Helpers;
using algart.Transversal.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace algart.Services.WebAPIRest.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriasController : Controller
    {
        private readonly ICategoriasApplication _Application;
        private readonly AppSettings _appSettings;

        public CategoriasController(ICategoriasApplication _Application,
                                  IOptions<AppSettings> appSettings)
        {
            this._Application = _Application;
            _appSettings = appSettings.Value;
        }


        [HttpPost]
        public async Task<IActionResult> InsertAsync(CategoriasDTO modelDto)
        {
            Response<string> response = new Response<string>();

            try
            {
                if (modelDto == null)
                    return BadRequest();

                response = await _Application.InsertAsync(modelDto);
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
                response.Data = string.Empty;
                response.IsSuccess = false;
                response.ReponseCode = (int)HttpStatusCode.InternalServerError;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(CategoriasDTO modelDto)
        {
            Response<string> response = new Response<string>();

            try
            {
                if (modelDto == null)
                    return BadRequest();

                response = await _Application.UpdateAsync(modelDto);
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
                response.Data = string.Empty;
                response.IsSuccess = false;
                response.ReponseCode = (int)HttpStatusCode.InternalServerError;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            Response<string> response = new Response<string>();

            try
            {
                response = await _Application.DeleteAsync(Id);
                if (response.IsSuccess)
                {
                    response.IsSuccess = true;
                    response.Message = string.Empty;
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
                response.Data = string.Empty;
                response.IsSuccess = false;
                response.ReponseCode = (int)HttpStatusCode.InternalServerError;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            Response<IEnumerable<CategoriasDTO>> response = new Response<IEnumerable<CategoriasDTO>>();

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
