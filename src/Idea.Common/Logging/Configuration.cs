using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idea.Common.Logging
{
    public static class Configuration
    {

        /// <summary>
        /// Inicializa log4Net para que escriba en disco
        /// </summary>
        public static void SetupFile()
        {
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();

            PatternLayout patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = "%date [%thread] %-5level %logger - %message%newline";
            patternLayout.ActivateOptions();

            RollingFileAppender roller = new RollingFileAppender();
            roller.AppendToFile = false;
            roller.File = @"Logs\IdeaLog.txt";
            roller.Layout = patternLayout;
            roller.MaxSizeRollBackups = 5;
            roller.MaximumFileSize = "1GB";
            roller.RollingStyle = RollingFileAppender.RollingMode.Size;
            roller.StaticLogFileName = true;            
            roller.ActivateOptions();
            hierarchy.Root.AddAppender(roller);
        }
        /// <summary>
        /// Inicializa log4Net para que escriba en memoria
        /// </summary>
        public static void SetupMem()
        {
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();

            PatternLayout patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = "%date [%thread] %-5level %logger - %message%newline";
            patternLayout.ActivateOptions();

            MemoryAppender memory = new MemoryAppender();
            memory.Layout = patternLayout;
            memory.ActivateOptions();
            hierarchy.Root.AddAppender(memory);
            hierarchy.Root.Level = Level.Info;
            hierarchy.Configured = true;
        }

      
    }
}

