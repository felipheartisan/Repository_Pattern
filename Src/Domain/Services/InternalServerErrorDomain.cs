using backend.Domain;
using Microsoft.AspNetCore.Mvc;

namespace backend.src.Domain.Services
{
    public class InternalServerErrorDomain<T> : ControllerBase where T : class
    {
        public IActionResult InternalServerError(ResultApplicationDomain<T> resultApplication, Exception ex)
        {
            resultApplication.Success = false;
            resultApplication.Message = ex.Message;
            return StatusCode(StatusCodes.Status500InternalServerError, resultApplication);
        }

        public IActionResult DadosInvalidos(ResultApplicationDomain<T> resultApplication)
        {
            resultApplication.Success = false;
            resultApplication.Message = "Há dados não informados!";
            resultApplication.Error = ModelState.ToString();
            return BadRequest(resultApplication);
        }
    }
}