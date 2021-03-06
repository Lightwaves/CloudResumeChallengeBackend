using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CloudResumeChallengeBackend.Repository;
using CloudResumeChallengeBackend.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;

namespace CloudResumeChallengeBackend.Controllers

{
    [Route("api/visitor")]
    [ApiController]
    public class VisitorController : Controller
    {
        private VisitorsRepository trepo;

        public VisitorController(VisitorsRepository repo) {

            trepo = repo;
        
        }
        [HttpOptions]
        public IActionResult PreflightRoute()
        {
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetVisitorCount() {

            var count = trepo.GetTotalVisitors();
            return Ok(new { count=count });
        
        
        }
        [HttpPost]
        public IActionResult CreateVisitor(Visitor visitor) {


            
            var headerexist = !String.IsNullOrEmpty(HttpContext.Request.Headers["x-forwarded-for"]);
            var ip = "";
            if (headerexist)
            {
                var test = HttpContext.Request.Headers["x-forwarded-for"][0].Split(",");
                ip = test[0];
                

            }
            else
            {

                ip = "192.0.2.0"; //this code path should never be reached assuming there's an X-Forward-For which cloudfront has.

            }
            ip = ip.Trim().Replace("\\", "").Replace("\"", "").Replace("http://", "");
            var newip = IPAddress.Parse(ip);
            trepo.InsertVisitor(visitor.DateTime, newip, visitor.UserAgent, visitor.Width, visitor.Height);
            //Debug.WriteLine(String.Format("{0}\n, {1}\n, {2}, {3}\n {4}\n", visitor.DateTime, visitor.UserAgent, ip, visitor.Width, visitor.Height));
            return Ok();
        
        
        }






    }
}
