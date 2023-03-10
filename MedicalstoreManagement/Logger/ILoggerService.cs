using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;
using MedicalstoreManagement.ExceptionHandlerMiddleware;
namespace MedicalstoreManagement.Logger
{
    public interface ILoggerService
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);
        void LogTrace(string message);
    }
}
