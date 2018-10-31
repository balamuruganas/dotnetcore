using System;
using System.IO;

namespace Seaknots.TCMS.Core.Logging
{
  public class Logger
  {
    public Logger(string logFile)
    {
      logPath = logFile;
      try
      {
        _logFile = new StreamWriter(logPath, true);
        _logFile.WriteLine();
        _logFile.WriteLine(string.Format("Logging session started on {0}", DateTime.Now.ToString("dd-MMM-yyyy @ hh:mm tt")));
        _logFile.WriteLine("==============================================================================");
        _logFile.Close();
      }
      catch {}
    }

    public void Log(string message, string heading="", LogLevel logLevel = LogLevel.Info)
    {
      string logLevelMsg = string.Empty;
      switch(logLevel)
      {
        case LogLevel.Warning:
          logLevelMsg = "Warning! ";
          break;
        case LogLevel.Error:
          logLevelMsg = "Error! ";
          break;
        case LogLevel.Fatal:
          logLevelMsg = "Fatal! ";
          break;
      }

      try
      {
        _logFile = new StreamWriter(logPath, true);
        if (!string.IsNullOrEmpty(heading))
          _logFile.WriteLine(string.Format("{0} {1}: {2)", logLevelMsg, heading, message));
        else
          _logFile.WriteLine(string.Format("{0} {1)", logLevelMsg, message));

        _logFile.Close();
      }
      catch {}
    }

    public bool IsLogging => (File.Exists(logPath) && _logFile != null && _logFile.BaseStream != null);
    public enum LogLevel { Fatal, Error, Warning, Info};
    private readonly string logPath = string.Empty;
    private StreamWriter _logFile = null;
  }
}
