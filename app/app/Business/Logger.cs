using app.Models;
using app.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business
{
    public class Logger
    {
        private static LogsRepo _logsRepo = new LogsRepo();

        public static void SaveLog(LogTypes type, string method, string message, string stack = null)
        {
            Logs log = new Logs()
            {
                Method = method,
                Message = message,
                Stack = stack,
                Type = (int)type,
                Created = DateTime.Now
            };

            switch (type)
            {
                case LogTypes.Info:
                    LogInfo(log);
                    break;
                case LogTypes.Warning:
                    LogWarning(log);
                    break;
                case LogTypes.Error:
                    LogError(log);
                    break;
                case LogTypes.Critical:
                    LogCritical(log);
                    break;
                case LogTypes.Fatal:
                    LogFatal(log);
                    break;
            }
        }

        private static void LogInfo(Logs log)
        {
            _logsRepo.Add(log);
        }
        private static void LogWarning(Logs log)
        {
            _logsRepo.Add(log);
        }
        private static void LogError(Logs log)
        {
            _logsRepo.Add(log);
        }
        private static void LogCritical(Logs log)
        {
            _logsRepo.Add(log);
        }
        private static void LogFatal(Logs log)
        {
            _logsRepo.Add(log);
        }
    }
}