using ACILogin.Models;
using ACILogin.Services;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Diagnostics;
using Utility;

namespace ACILogin.Controllers
{
    public class Home1Controller : Controller
    {
        //private readonly ILogger<Home1Controller> _logger;

        //public Home1Controller(ILogger<Home1Controller> logger)
        //{
        //    _logger = logger;
        //}        

        private readonly IBusinessLayer _layer;
        private readonly ILog _ILog;
        private ConcurrentDictionary<string, object> _SqlParameter;

        // Dependency Injection - we inject IBusinessLayer
        public Home1Controller(IBusinessLayer layer)
        {
            _layer = layer;             
            _ILog = Log.getInstance;
            _SqlParameter = new ConcurrentDictionary<string, object>();
        }

        public IActionResult Index()
        {
            Parallel.Invoke(
                ()=>method1(),
                ()=>method2()
                );

            method3();

            // Exception Logger
            //try { var x = 0; var y = 7 / x; } catch (Exception ex) { _ILog.LogException("Message: " + ex.Message + Environment.NewLine + "Description: " + ex.StackTrace); }

            _SqlParameter.AddOrUpdate("Action", 1, (key, oldValue) => 1);
            ViewBag.Movies = _layer.getMovies(_SqlParameter);

            _SqlParameter.AddOrUpdate("Action", 2, (key, oldValue) => 2);
            ViewBag.State = _layer.getMovies(_SqlParameter);


            //ViewBag.State = _layer.getState();
            return View();
        }

        private void method1()
        {
            ViewBag.method1 = "1. " + _layer.getGuid();

        }

        private void method2()
        {
            ViewBag.method2 = "2. " + _layer.getGuid();
        }

        private void method3()
        {
            ViewBag.method3 = "3. " + _layer.getGuid();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
