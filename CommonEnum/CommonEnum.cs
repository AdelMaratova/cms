using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContainerManagementSystem.CommonEnum
{
    public enum ShippingMethod
    {
        Plane,
        Ship
    }

    public enum AjaxReturnStatus
    {
        Success,
        Error
    }

    public enum ShipmentStatus
    { 
        New,
        Dispatched,
        Arrived,
        Delivered
    }

    public class CommonEnum
    {
        
    }
}