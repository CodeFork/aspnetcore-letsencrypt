﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApp.Extensions;
using WebApp.Internal.Abstractions;

namespace WebApp.Internal {
    internal class HostStartup {
        public void ConfigureServices(IServiceCollection services) {
            services.AddAcmeChallengeListener();
            services.AddSingleton<IHttpChallengeResponseStore, InMemoryHttpChallengeResponseStore>();
            services.AddSingleton<IHostedService, AcmeChallengeRequester>();
        }

        public void Configure(IApplicationBuilder app) {
            app.UseAcmeChallengeListener();
            app.Run(async context => {
                await context.Response.WriteAsync("Please fulfill the ACME challenge by requesting /.well-known/acme-challenge/{token}");
            });
        }
    }
}