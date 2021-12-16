using Microsoft.AspNetCore.Mvc;


namespace MercadoEletronicoCore.Controllers
{
    public abstract class ApiControllerBase : ControllerBase
    {
        
        protected new IActionResult Response(object result = null)
        {            
            return Ok(new
                {
                    success = true,
                    data = result
                });

            return BadRequest(new
            {
                success = false
            });
        }


    }
}