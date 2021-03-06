﻿using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ConsoleAppFramework
{
    public interface IConsoleAppInterceptor
    {
        /// <summary>
        /// Called once when ConsoleAppFramework is stareted.
        /// </summary>
        ValueTask OnEngineBeginAsync(IServiceProvider serviceProvider, ILogger<ConsoleAppEngine> logger);

        /// <summary>
        /// Called when ConsoleAppMethod is called.
        /// </summary>
        ValueTask OnMethodBeginAsync(ConsoleAppContext context);

        /// <summary>
        /// Called once when ConsoleAppMethod is finished.
        /// </summary>
        ValueTask OnMethodEndAsync(ConsoleAppContext context, string? errorMessageIfFailed, Exception? exceptionIfExists);

        /// <summary>
        /// Called when ConsoleAppFramework is error or completed.
        /// </summary>
        ValueTask OnEngineCompleteAsync(IServiceProvider serviceProvider, ILogger<ConsoleAppEngine> logger);
    }

    public class NullConsoleAppInterceptor : IConsoleAppInterceptor
    {
        public static readonly IConsoleAppInterceptor Default = new NullConsoleAppInterceptor();
        readonly ValueTask Empty = default(ValueTask);

        public ValueTask OnEngineBeginAsync(IServiceProvider serviceProvider, ILogger<ConsoleAppEngine> logger)
        {
            return Empty;
        }

        public ValueTask OnMethodEndAsync(ConsoleAppContext context, string? errorMessageIfFailed, Exception? exceptionIfExists)
        {
            return Empty;
        }

        public ValueTask OnMethodBeginAsync(ConsoleAppContext context)
        {
            return Empty;
        }

        public ValueTask OnEngineCompleteAsync(IServiceProvider serviceProvider, ILogger<ConsoleAppEngine> logger)
        {
            return Empty;
        }
    }
}
