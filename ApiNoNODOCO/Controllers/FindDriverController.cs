using Data_Tier.Models;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Data_Store;
using Data_Store.Models;
using Newtonsoft.Json;
using Data_Store.Reponsitory;
using ApiNoNODOCO.Service;
using ApiNoNODOCO.Service.IService;
using Data_Tier.Models.Models_Customize;

namespace ApiNoNODOCO.Controllers
{
    [Route("api/v1/findDriver")]
    [ApiController]
    public class FindDriverController : ControllerBase
    {
        private IDriverService _driverService;

        public FindDriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpGet]
        public  ActionResult FindDriver(String customerId, double Latitude, double Longitude)
        {

            DriverStoreReponsitory driverStoreReponsitory = new DriverStoreReponsitory();
            List<DriverStore> listDriver = driverStoreReponsitory.GetAll();

            if (listDriver.Count == 0)
            {
                return NotFound("Không tìm được tài xế!!!");
            }
            DriverStore minDriver = listDriver.First<DriverStore>();
            foreach (var item in listDriver)
            {
                DriverStore tempDriver = item;
                if (Calculate(tempDriver.Latitude, tempDriver.Longitude, Latitude, Longitude) < Calculate(tempDriver.Latitude, tempDriver.Longitude, Latitude, Longitude))
                {
                    minDriver = tempDriver;
                }
            }

            
            Driver driver = _driverService.GetDriverInfo(new LoginRequest(minDriver.Email));
           
            return Ok(new 
            {
                driver = driver,
                driverLocation = minDriver
            });
        }

        private double Calculate(double sLatitude, double sLongitude, double eLatitude,
                               double eLongitude)
        {
            var radiansOverDegrees = (Math.PI / 180.0);

            var sLatitudeRadians = sLatitude * radiansOverDegrees;
            var sLongitudeRadians = sLongitude * radiansOverDegrees;
            var eLatitudeRadians = eLatitude * radiansOverDegrees;
            var eLongitudeRadians = eLongitude * radiansOverDegrees;

            var dLongitude = eLongitudeRadians - sLongitudeRadians;
            var dLatitude = eLatitudeRadians - sLatitudeRadians;

            var result1 = Math.Pow(Math.Sin(dLatitude / 2.0), 2.0) +
                          Math.Cos(sLatitudeRadians) * Math.Cos(eLatitudeRadians) *
                          Math.Pow(Math.Sin(dLongitude / 2.0), 2.0);

            // Using 3956 as the number of miles around the earth
            var result2 = 3956.0 * 2.0 *
                          Math.Atan2(Math.Sqrt(result1), Math.Sqrt(1.0 - result1));

            return result2;
        }
    }
}
                                                                                        