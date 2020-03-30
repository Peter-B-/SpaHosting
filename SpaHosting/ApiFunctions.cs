using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using SpaHosting.Models;

namespace SpaHosting
{
    public static class ApiFunctions
    {
        [FunctionName(nameof(GetUsers))]
        public static async Task<IActionResult> GetUsers(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "users")]
            HttpRequest req,
            ILogger log)
        {
            return new OkObjectResult(
                new[]
                {
                    new User {UserId = "hans", Name = "Hans Dampf"},
                    new User {UserId = "franz", Name = "Franz Nudel"}
                }
            );
        }

        [FunctionName(nameof(GetUsersCars_Route))]
        public static async Task<IActionResult> GetUsersCars_Route(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "users/{userId}/cars")]
            HttpRequest req,
            string userId,
            ILogger log)
        {
            return new OkObjectResult(new Car {UserId = userId, Brand = "Faraday"});
        }

        [FunctionName(nameof(GetUsersCars_Query))]
        public static async Task<IActionResult> GetUsersCars_Query(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "users/cars")]
            HttpRequest req,
            ILogger log)
        {
            var userId = req.Query["userId"].FirstOrDefault();

            return new OkObjectResult(new Car { UserId = userId, Brand = "Faraday" });
        }

    }
}