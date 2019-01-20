using System.Linq;
using BloodpressureApi.Models.Bloodpressure;
using BloodpressureApp.Entities;
using BloodpressureApp.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BloodpressureApp.Controllers
{
    public class BloodpressureController : Controller
    {
        private BloodPressureInfoContext _ctx;

        public BloodpressureController(BloodPressureInfoContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        [Route("api/BloodPressure")]
        //[EnableCors("CorsSpecificOrigin")]
        [DisableCors]
        public JsonResult GetBloodPressure()
        {
            if (!ModelState.IsValid)
                return null;

            var bloodPressureList = _ctx.Bloodpressures.AsParallel();
            return Json(bloodPressureList.ToList().OrderByDescending(o => o.Date));
        }

        [HttpGet]
        [Route("api/BloodPressure/{id}", Name = "GetBloodpressureId")]
        [EnableCors("CorsSpecificOrigin")]
        public IActionResult GetBloodPressure(int id)
        {
            var bloodpressure = _ctx.Bloodpressures.FirstOrDefault(p => p.Id == id);
            if (bloodpressure == null)
                return BadRequest();

            return Ok(bloodpressure);
        }

        [HttpPost("api/Bloodpressure", Name = "PostPressure" )]
        [EnableCors("CorsSpecificOrigin")]
        public IActionResult CreateBloodpressure([FromBody] BloodpressureCreateDto bloodpressure)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (bloodpressure == null)
                return BadRequest();

            var bp = new Bloodpressure()
            {
                PersonId = bloodpressure.PersonId,
                Systolic = bloodpressure.Systolic,
                Diastolic = bloodpressure.Diastolic,
                Heartrate = bloodpressure.Heartrate,
                Date = bloodpressure.Date,
                Time = bloodpressure.Time,
                Comment = bloodpressure.Comment
            };

            _ctx.Bloodpressures.Add(bp);
            _ctx.SaveChanges();

            return CreatedAtRoute("GetBloodpressureId", new {  id = bloodpressure.PersonId}, bp);
        }

        [HttpPut("api/Bloodpressure/{id}", Name = "UpdatePressure")]
        [EnableCors("CorsSpecificOrigin")]
        public IActionResult UpdateBloodpressure( [FromBody] BloodpressureUpdateDto bloodpressure)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (bloodpressure == null)
                return BadRequest();

            var bp = new Bloodpressure()
            {
                Id =  bloodpressure.Id,
                PersonId = bloodpressure.PersonId,
                Systolic = bloodpressure.Systolic,
                Diastolic = bloodpressure.Diastolic,
                Heartrate = bloodpressure.Heartrate,
                Date = bloodpressure.Date,
                Time = bloodpressure.Time,
                Comment = bloodpressure.Comment
            };

            _ctx.Bloodpressures.Update(bp);
            _ctx.SaveChanges();

            return CreatedAtRoute("GetBloodpressureId", new { id = bloodpressure.PersonId }, bp);
        }
    }
}