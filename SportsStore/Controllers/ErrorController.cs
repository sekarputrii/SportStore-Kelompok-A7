using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Controllers {


    /// <summary>
    /// class error controller
    /// </summary>
    public class ErrorController : Controller {

        public ViewResult Error() => View();
    }
}
