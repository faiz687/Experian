﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPlacesApi
{
    public static class VersioningExtension
    {
        public static void AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(
               config =>
               {
                   config.ReportApiVersions = true;
                   config.AssumeDefaultVersionWhenUnspecified = true;
                   config.DefaultApiVersion = new ApiVersion(1, 0);
                   config.ApiVersionReader = new HeaderApiVersionReader("api-version");
               });
            services.AddVersionedApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'VVV";

                    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                    // can also be used to control the format of the API version in route templates
                    options.SubstituteApiVersionInUrl = true;
                });
        }
    }
}