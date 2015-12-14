using Monad.EHR.Domain.Entities;
using Monad.EHR.Services.Interface;
using Monad.EHR.Web.App.Models;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using Microsoft.AspNet.Authorization;

namespace Monad.EHR.Web.App.Controllers
{

    [Route("api/[controller]")]
    public class WeightController : Controller
    {
        private IWeightService _weightService;
        public WeightController(IWeightService weightService)
        {
            _weightService = weightService;
        }


        [HttpPost]        
        [Route("AddWeight")]
        [Authorize(Policy = "TokenAuth", Roles = "Weight.AddWeight")]
        public IActionResult AddWeight([FromBody]WeightViewModel model)
        {
            if (ModelState.IsValid)
            {
                var weight = new Weight
                {
                    Date = model.Date,
                    Wt = model.Wt,
                    PatientID = model.PatientID,

                    CreatedDateUtc = System.DateTime.UtcNow,
                    LastModifiedDateUtc = System.DateTime.UtcNow,
                    LastModifiedBy = 1
                };
                _weightService.AddWeight(weight);
            }
            return new HttpStatusCodeResult(200);
        }


        [HttpPost]
        [Route("EditWeight")]
        [Authorize(Policy = "TokenAuth", Roles = "Weight.EditWeight")]
        public IActionResult EditWeight([FromBody]EditWeightViewModel model)
        {
            if (ModelState.IsValid)
            {
                var weight = new Weight
                {
                    Id = model.Id,
                    Date = model.Date,
                    Wt = model.Wt,
                    PatientID = model.PatientID,

                    // CreatedDateUtc = model.CreatedDateUtc,
                    LastModifiedDateUtc = System.DateTime.UtcNow,
                    LastModifiedBy = 1
                };
                _weightService.EditWeight(weight);
            }
            return new HttpStatusCodeResult(200);
        }

        [HttpPost]
        [Route("DeleteWeight")]
        [Authorize(Policy = "TokenAuth", Roles = "Weight.DeleteWeight")]
        public IActionResult DeleteWeight([FromBody]EditWeightViewModel model)
        {
            if (ModelState.IsValid)
            {
                var weight = new Weight
                {
                    Id = model.Id,
                    Date = model.Date,
                    Wt = model.Wt,
                    PatientID = model.PatientID,

                    // CreatedDateUtc = model.CreatedDateUtc,
                    LastModifiedDateUtc = System.DateTime.UtcNow,
                    LastModifiedBy = 1
                };
                _weightService.DeleteWeight(weight);
            }
            return new HttpStatusCodeResult(200);
        }

        [HttpGet]
        [Route("GetAllWeights")]
        [Authorize(Policy = "TokenAuth", Roles = "Weight.GetAllWeights")]
        public IEnumerable<Weight> GetAllWeights()
        {
            return _weightService.GetAllWeight();
        }

        [HttpGet]
        [Route("GetWeight")]
        [Authorize(Policy = "TokenAuth", Roles = "Weight.GetWeight")]
        public Weight GetWeight(int weightId)
        {
            return _weightService.GetWeightById(weightId);
        }


        [HttpGet]
        [Route("GetWeightForPatient")]
        [Authorize(Policy = "TokenAuth", Roles = "Weight.GetWeightForPatient")]
        public IEnumerable<Weight> GetWeightForPatient(int patientId)
        {
            return _weightService.GetAllWeightByPatientId(patientId);
        }

    }
}
