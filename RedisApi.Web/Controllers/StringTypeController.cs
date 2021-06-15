using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedisApi.Web.Services;
using StackExchange.Redis;

namespace RedisApi.Web.Controllers
{
    public class StringTypeController : Controller
    {
        private readonly RedisService _redisService;

        private readonly IDatabase db;

        public StringTypeController(RedisService redisService)
        {
            _redisService = redisService;
            db = _redisService.GetDb(0);
        }

        public IActionResult Index()
        {
            db.StringSet("name", "Ali Osman ÜNAL");
            db.StringSet("ziyaretci", 100);

            return View();
        }

        public IActionResult Show()
        {
            var value = db.StringLength("name");

            // db.StringIncrement("ziyaretci", 10);

            // var count = db.StringDecrementAsync("ziyaretci", 1).Result;

            db.StringDecrementAsync("ziyaretci", 10).Wait();

            ViewBag.value = value.ToString();

            return View();
        }
    }
}
