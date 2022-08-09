using NLog;

namespace Net6_NlogDemo
{
    public static class NewLoggerExtension
    {
        public static void LogInformation<T>(this ILogger<T> logger, string userName, string message, Exception exception)
        {
            //抓取Nlog.config rule
            Logger log = LogManager.GetLogger("info");

            //新增參數
            var theEvent = new LogEventInfo();
            theEvent.Properties["userName"] = userName;
            theEvent.Message = message;
            theEvent.Exception = exception;
            theEvent.Level = NLog.LogLevel.Info;
            //寫入資料庫
            log.Log(theEvent);
        }
    }
}
