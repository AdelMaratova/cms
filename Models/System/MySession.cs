using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContainerManagementSystem.Models.System
{
    public class MySession
    {
        public Guid UserId { get; set; }
        public DateTime LoginDate { get; set; }

        private static MySession _CurrentSession;
        public static MySession CurrentSession
        {
            get
            {
                if (_CurrentSession == null)
                {
                    if (HttpContext.Current.Session != null)
                    {
                        if (HttpContext.Current.Session["MySession"] != null)
                        {
                            _CurrentSession = (MySession)HttpContext.Current.Session["MySession"];
                        }
                    }
                }

                return _CurrentSession;
            }
            set
            {
                if (value != null)
                    HttpContext.Current.Session["MySession"] = value;
            }
        }
    }
}