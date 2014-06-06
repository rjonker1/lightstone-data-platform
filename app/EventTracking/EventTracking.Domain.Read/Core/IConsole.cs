﻿using System;
namespace EventTracking.Domain.Read.Core
{
    public interface IConsole
    {
        void Log(ConsoleColor color, string message, params object[] arguments);
        void Log(string message, params object[] arguments);
        void Green(string message, params object[] arguments);
        void Timings(string message, params object[] arguments);
        void Magenta(string message, params object[] arguments);
        void Cyan(string message, params object[] arguments);
        void Error(string message, params object[] arguments);
        void Important(string message, params object[] arguments);

        void ReadKey(string message = null);
    }
}
