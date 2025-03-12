using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace experiencesAPI
{
    // POCO class 
    public class Experience
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; } // ? means that the value can be null
    }
}