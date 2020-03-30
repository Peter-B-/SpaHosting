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
        [FunctionName(nameof(GetUsersCars))]
        public static async Task<IActionResult> GetUsersCars(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "users/{userId}/cars")]
            HttpRequest req,
            string userId,
            ILogger log)
        {
            return new OkObjectResult(new Car {UserId = userId, Brand = "Faraday"});
        }
    }
}