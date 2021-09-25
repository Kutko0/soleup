using System;
using Soleup.API.Models;

namespace Soleup.API.DTOs
{
    public class ResponseWithObject
    {
        public string Message { get; set; }
        public object Item { get; set; }
    }


    
}