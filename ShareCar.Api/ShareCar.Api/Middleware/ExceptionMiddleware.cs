﻿using Microsoft.AspNetCore.Http;
using ShareCar.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ShareCar.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);

                if (ex is UnauthorizedAccessException)
                {
                    httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                }
                else if (ex is NoSeatsInRideException)
                {
                    httpContext.Response.StatusCode = StatusCodes.Status409Conflict;
                }else
                {
                    httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                }
            }
        }

        }
    }

