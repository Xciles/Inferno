using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inferno.BurnApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inferno.BurnApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Drone")]
    public class DroneController : Controller
    {
        private readonly InfernoDbContext _context;

        public DroneController(InfernoDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<Domain.DroneAssignment> GetNextAssignment()
        {
            return new Domain.DroneAssignment()
            {
            };
        }
    }
}