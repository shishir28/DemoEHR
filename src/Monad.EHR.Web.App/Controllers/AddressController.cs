using Monad.EHR.Domain.Entities;
using Monad.EHR.Services.Interface;
using Monad.EHR.Web.App.Models;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;

namespace Monad.EHR.Web.App.Controllers
{
    [Route("api/[controller]")]
    public class AddressController:Controller
    {
        private IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }
       

        [HttpPost]
        [AllowAnonymous]
        [Route("AddAddress")]
        public IActionResult AddAddress([FromBody]AddressViewModel model)
        {
            if (ModelState.IsValid)
            {
                var address = new Address
                {
                    Line1 = model.Line1,
Line2 = model.Line2,
City = model.City,
State = model.State,
Zip = model.Zip,
BeginDate = model.BeginDate,
EndDate = model.EndDate,
PatientID = model.PatientID,

                    CreatedDateUtc = System.DateTime.UtcNow,
                    LastModifiedDateUtc = System.DateTime.UtcNow,
                    LastModifiedBy = 1
                };
                _addressService.AddAddress(address);
            }
            return new HttpStatusCodeResult(200);
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("EditAddress")]
        public IActionResult EditAddress([FromBody]EditAddressViewModel model)
        {
            if (ModelState.IsValid)
            {
                var address = new Address
                {
                    Id = model.Id,   
					Line1 = model.Line1,
Line2 = model.Line2,
City = model.City,
State = model.State,
Zip = model.Zip,
BeginDate = model.BeginDate,
EndDate = model.EndDate,
PatientID = model.PatientID,

                   // CreatedDateUtc = model.CreatedDateUtc,
                    LastModifiedDateUtc = System.DateTime.UtcNow,
                    LastModifiedBy = 1
                };
                _addressService.EditAddress(address);
            }
            return new HttpStatusCodeResult(200);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("DeleteAddress")]
        public IActionResult DeleteAddress([FromBody]EditAddressViewModel model)
        {
            if (ModelState.IsValid)
            {
                var address = new Address
                {
                    Id = model.Id,
                   	Line1 = model.Line1,
Line2 = model.Line2,
City = model.City,
State = model.State,
Zip = model.Zip,
BeginDate = model.BeginDate,
EndDate = model.EndDate,
PatientID = model.PatientID,

                   // CreatedDateUtc = model.CreatedDateUtc,
                    LastModifiedDateUtc = System.DateTime.UtcNow,
                    LastModifiedBy = 1
                };
                _addressService.DeleteAddress(address);
            }
            return new HttpStatusCodeResult(200);
        }

		[HttpGet]
        [Route("GetAllAddresss")]
        public IEnumerable<Address> GetAllAddresss()
        {
            return _addressService.GetAllAddress();
        }

        [HttpGet]
        [Route("GetAddress")]
        public Address GetAddress(int addressId)
        {
            return _addressService.GetAddressById(addressId);
        }

		
		[HttpGet]
        [Route("GetAddressForPatient")]
        public IEnumerable<Address> GetAddressForPatient(int patientId)
        {
            return _addressService.GetAllAddressByPatientId(patientId);
        }

    }
}