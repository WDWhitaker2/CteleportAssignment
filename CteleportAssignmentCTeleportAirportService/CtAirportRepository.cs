using CteleportAssignment.Domain;
using CteleportAssignment.Domain.Interfaces;
using CteleportAssignmentCTeleportAirportService.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;

namespace CteleportAssignmentCTeleportAirportService
{
    public class CtAirportRepository : IAirportRepository
    {
        public CtAirportRepository()
        {
            BaseUrl = "https://places-dev.cteleport.com";
        }


        private string BaseUrl { get; set; }
        public Airport GetAirportByCode(string code)
        {
            var result = GetRequest<AirportModel>($"airports/{code}");
            if (result != null)
            {
                var model = new Airport();
                model.Code = code;
                model.Latitude = Convert.ToDecimal(result?.location?.lat, CultureInfo.InvariantCulture);
                model.Longitude = Convert.ToDecimal(result?.location?.lon, CultureInfo.InvariantCulture);
                return model;
            }
            else
            {
                throw new Exception($"Airport with code '{code}' not found.");
            }
        }

        private T GetRequest<T>(string url) where T : new()
        {
            RestClient _RestClient = new RestClient(BaseUrl);
            IRestRequest request = new RestRequest(url, Method.GET);
            request.RequestFormat = DataFormat.Json;
            var response = _RestClient.Execute<T>(request);

            return response.Data;
        }
    }
}
