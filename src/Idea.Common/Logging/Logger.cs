using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idea.Common.Logging
{
    public class Logger: ILogger
    {
        #region Fields
        private static readonly ILog mLog = LogManager.GetLogger(typeof(Logger));
        #endregion Fields

        #region Constructor

        static Logger()
        {
            Debug.WriteLine("Server Logger initializing...");
            if (mLog != null)
            {
                Debug.WriteLine("Server Logger initialized");
                Debug.WriteLine(string.Format("Debug: {0}, Error: {1}, Info: {2}, Warning {3}",
                mLog.IsDebugEnabled, mLog.IsErrorEnabled, mLog.IsInfoEnabled, mLog.IsWarnEnabled));
            }
            else
            {
                Debug.WriteLine("Failed initializing Server Logger");
            }
        }

        #endregion Constructor

        #region Public Methods

        public void Exception(Exception exception)
        {
            if (mLog != null)
                Logger.mLog.Error("Exception", exception);
        }

        public void Verbose(string category, string message)
        {
            if (mLog != null)
                Logger.mLog.Debug(FormatMessage(category, message));
        }

        public void Info(string category, string message)
        {
            if (mLog != null)
                Logger.mLog.Info(FormatMessage(category, message));
        }

        public void Warning(string category, string message)
        {
            if (mLog != null)
                Logger.mLog.Warn(FormatMessage(category, message));
        }

        public void Error(string category, string message)
        {
            if (mLog != null)
                Logger.mLog.Error(FormatMessage(category, message));
        }

        public void Write(TraceLevel level, string category, string message)
        {
            switch (level)
            {
                case TraceLevel.Verbose:
                    Verbose(category, message);
                    break;
                case TraceLevel.Info:
                    Info(category, message);
                    break;
                case TraceLevel.Warning:
                    Warning(category, message);
                    break;
                case TraceLevel.Error:
                    Error(category, message);
                    break;
            }
        }

        #endregion Public Methods

        #region Private Methods

        private const string MessageFormat = "{0} | {1}";
        private const int MaxCategoryNameLength = 25;

        private static string FormatMessage(string category, string message)
        {
            string output = string.Format(MessageFormat, FormatName(category, MaxCategoryNameLength), message);
            return output;
        }

        private static string FormatName(string name, int minLength)
        {
            string result;
            string trimName = name != null ? name.Trim() : string.Empty;
            if (trimName.Length >= minLength)
                result = trimName;
            else
                result = trimName.PadRight(minLength);
            return result;
        }
        #endregion Private Methods
    }
}
