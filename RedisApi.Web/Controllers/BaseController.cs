using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedisApi.Web.Services;
using StackExchange.Redis;

namespace RedisApi.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly RedisService _redisService;

        protected readonly IDatabase db;

        public BaseController(RedisService redisService)
        {
            _redisService = redisService;
            db = _redisService.GetDb(1);
        }
    }
}
