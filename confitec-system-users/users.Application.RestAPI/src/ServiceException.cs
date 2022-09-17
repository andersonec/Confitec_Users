using System;
using System.Collections.Generic;
using System.Text;

namespace users.Application.RestAPI.src
{
    public class ServiceException
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public string Trace { get; set; }


        public static ServiceException ThrowExeption(Exception ex)
        {
            return new ServiceException
            {
                Message = ex.Message,
                Trace = ex.StackTrace,
                Type = ex.GetType().Name
            };
        }
    }
}
