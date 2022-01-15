using System;
using System.Collections.Generic;
using System.Linq;
namespace TaxiShare.Application
{
    public class SimpleResponse
    {
        public SimpleResponse(bool success)
        {
            Success = success;
        }

        public SimpleResponse(bool success, string? message)
        {
            Success = success;
            Message = message;
        }
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
