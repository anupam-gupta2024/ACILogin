using ACILogin.Models;
using ACILogin.Services;
using ACILogin.Services.StoredProcedure.GetSet;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Utility;

namespace ACILogin.Controllers
{
    public class baseController : Controller
    {
        protected readonly IDataService _layer;
        protected readonly ILog _ILog;
        protected readonly IMoviesParam _MoviesParam;
        protected readonly IGetBasicDataParam _GetBasicDataParam;


        // Dependency Injection - we inject IBusinessAccess
        public baseController(IDataService layer)
        {
            _layer = layer;
            _ILog = Log.getInstance;
            //_SqlParameter = new ConcurrentDictionary<string, object>();
            _MoviesParam = new MoviesParam();
            _GetBasicDataParam = new GetBasicDataParam();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var execeptionHandlerPathFeture = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ErrorViewModel model = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                ErrorMessage = execeptionHandlerPathFeture.Error.Message,
                Source = execeptionHandlerPathFeture.Error.Source,
                ErrorPath = execeptionHandlerPathFeture.Path,
                StackTrace = execeptionHandlerPathFeture.Error.StackTrace,
                InnerException = Convert.ToString(execeptionHandlerPathFeture.Error.InnerException)
            };

            _ILog.LogException(
                String.Format(Environment.NewLine +
                    "Request ID: {1}{0}" +
                    "Error Message: {2}{0}" +
                    "Source: {3}{0}" +
                    "ErrorPath: {4}{0}" +
                    "InnerException: {5}{0}" +
                    "StackTrace: {6}",
                    Environment.NewLine + Environment.NewLine,    // 0
                    model.RequestId,    // 1
                    model.ErrorMessage, // 2
                    model.Source,   // 3
                    model.ErrorPath,    // 4
                    model.InnerException,   // 5
                    model.StackTrace    // 6
                ));


            return View(model);
           
            //ErrorViewModel model = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
            //_ILog.LogException(model.RequestId + Environment.NewLine 
            //    + model.ShowRequestId + Environment.NewLine
            //    + model.typeOfException + Environment.NewLine);

            //return View(model);
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
