using ACILogin.Models;
using ACILogin.Services;
using ACILogin.Services.StoredProcedure.GetSet;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using Utility;

namespace ACILogin.Controllers
{
    public class HomeController : baseController
    {
        private readonly IConfiguration _config;
        public HomeController(IDataService layer, IConfiguration config) : base(layer)
        {
            _config = config;
        }

        ////private readonly IBusinessAccess _layer;
        //private readonly IDataService _layer;
        //private readonly ILog _ILog;
        ////private ConcurrentDictionary<string, object> _SqlParameter;

        //private readonly IMoviesParam _MoviesParam;
        //private readonly IGetBasicDataParam _GetBasicDataParam;


        //// Dependency Injection - we inject IBusinessAccess
        //public HomeController(IDataService layer)
        //{
        //    _layer = layer;             
        //    _ILog = Log.getInstance;
        //    //_SqlParameter = new ConcurrentDictionary<string, object>();
        //    _MoviesParam = new MoviesParam();
        //    _GetBasicDataParam = new GetBasicDataParam();
        //}

        public IActionResult Index()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("fno", typeof(int));
            dt.Columns.Add("name", typeof(string));

            dt.Rows.Add(101, "John");
            dt.Rows.Add(201, "Robert");
            dt.Rows.Add(301, "Peter");

            //_SqlParameter.AddOrUpdate("Action", 2, (key, oldValue) => 2);
            _MoviesParam.Action = 2;
            _MoviesParam.DataTable = dt;
            ViewBag.Data = _layer.Movies(_MoviesParam);


            _MoviesParam.Action = 3;
            ViewBag.Movies = _layer.Movies(_MoviesParam);

            //_SqlParameter.AddOrUpdate("Action", 3, (key, oldValue) => 3);
            _GetBasicDataParam.Action = 4;
            _GetBasicDataParam.R1 = "29";
            ViewBag.State = _layer.GetBasicData(_GetBasicDataParam);

            ViewBag.method1 = "Hello".ToString();

            ViewBag.Environment = _config.GetSection("DataConnection").GetChildren().ToDictionary(a => a.Key, a => a.Value);

            return View();
        }
    }
}
