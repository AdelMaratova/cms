using ContainerManagementSystem.DAL;
using ContainerManagementSystem.Models;
using ContainerManagementSystem.Models.ShipmentRoute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContainerManagementSystem.Controllers.Shared
{
    public class SharedControllerBase : Controller
    {
        protected CMSContext context = new CMSContext();

        public string GetCityOptionsByCounmtryId(Guid country_id)
        {
            string options = string.Empty;

            List<City> cities = new List<City>();

            cities = context.Cities.Where(x => x.CountryId == country_id).ToList();

            foreach (City city in cities)
            {
                options += "<option value=\"" + city.CityId.ToString() + "\">" + city.CityName + "</option>";
            }

            return options;
        }

        public string GetRandomString(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[length];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            return finalString;
        }

        public string GetRoutesByCountryCity(Guid sender_country_id, Guid sender_city_id, Guid destination_country_id, Guid destination_city_id)
        {
            string options = string.Empty;

            List<ShipmentRoute> routes = new List<ShipmentRoute>();

            routes = context.ShipmentRoutes.Where(x => x.SenderCountryId == sender_country_id
                                                    && x.SenderCityId == sender_city_id
                                                    && x.DestinationCountryId == destination_country_id
                                                    && x.DestinationCityId == destination_city_id).ToList();

            foreach (ShipmentRoute route in routes)
            {
                options += "<option value=\"" + route.ShipmentRouteId.ToString() + "\">" + route.ShipmentRouteName + "</option>";
            }

            return options;
        }
    }
}