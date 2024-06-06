using System;
using Serilog;
using Serilog.Core;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ahif_academy
{
    public class Log
    {
        public static Logger log = new LoggerConfiguration()
        .WriteTo.Console() // Logger soll in die Konsole loggen
        .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 7) // Logger soll in die Datei "log.txt" loggen
        .CreateLogger();
    }
}
