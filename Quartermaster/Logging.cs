using System;

class LoggerFactory
{
    public static Logger GetLogger<T>()
    {
        return new Logger(typeof(T).FullName);
    }
}

class Logger
{
    private readonly string prefix;

    public Logger(string typeName)
    {
        prefix = "[" + typeName + "] ";
    }

#if DEBUG
    public void Debug(string format, params object[] args)
    {
        UnityEngine.Debug.Log(prefix + String.Format(format, args ?? new object[0]));
    }
    public void Debug(Exception exception, string format, params object[] args)
    {
        UnityEngine.Debug.Log(prefix + String.Format(format, args ?? new object[0]));
        UnityEngine.Debug.Log(exception.ToString());
    }
    public bool IsDebugEnabled { get { return true; } }
#endif

#if !DEBUG
    public void Debug(string format, params object[] args)
    {
    }
    public void Debug(Exception exception, string format, params object[] args)
    {
    }
    public bool IsDebugEnabled { get { return false; } }
#endif

    public void Information(string format, params object[] args)
    {
        UnityEngine.Debug.Log(prefix + String.Format(format, args ?? new object[0]));
    }
    public void Information(Exception exception, string format, params object[] args)
    {
        UnityEngine.Debug.Log(prefix + String.Format(format, args ?? new object[0]));
        UnityEngine.Debug.Log(exception.ToString());
    }
    public bool IsInformationEnabled { get { return true; } }

    public void Warning(string format, params object[] args)
    {
        UnityEngine.Debug.LogWarning(prefix + String.Format(format, args ?? new object[0]));
    }
    public void Warning(Exception exception, string format, params object[] args)
    {
        UnityEngine.Debug.LogWarning(prefix + String.Format(format, args ?? new object[0]));
        UnityEngine.Debug.LogWarning(exception.ToString());
    }
    public bool IsWarningEnabled { get { return true; } }

    public void Error(string format, params object[] args)
    {
        UnityEngine.Debug.LogError(prefix + String.Format(format, args ?? new object[0]));
    }
    public void Error(Exception exception, string format, params object[] args)
    {
        UnityEngine.Debug.LogError(prefix + String.Format(format, args ?? new object[0]));
        UnityEngine.Debug.LogError(exception.ToString());
    }
    public bool IsErrorEnabled { get { return true; } }
}