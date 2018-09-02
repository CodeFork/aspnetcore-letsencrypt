﻿using Microsoft.AspNetCore.Hosting;
using System;

namespace AspNetCore.LetsEncrypt.Extensions {
    internal static class WebHostBuilderExtensions {
        public static IWebHostBuilder UseExternalConfiguration(this IWebHostBuilder webHostBuilder, Action<IWebHostBuilder> configureAction)
        {
            configureAction?.Invoke(webHostBuilder);
            return webHostBuilder;
        }
    }
}
