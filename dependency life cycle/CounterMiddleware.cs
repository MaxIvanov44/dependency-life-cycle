using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dependency_life_cycle
{
    public class CounterMiddleware
    {
        int i = 0;
        public CounterMiddleware(RequestDelegate next)
        {

        }
        public async Task InvokeAsync(HttpContext context, 
            Icounter counter, CounterService counterService)
        {
            i++;
            await context.Response.WriteAsync($"Request: {i} Icounter: {counter.Value}" +
                $" CounterService: {counterService.Counter.Value}");
        }
    }
}
