using System;
using System.Diagnostics;
using Libcuda.Tracing;

namespace Libcuda.Api.Native
{
    [DebuggerNonUserCode]
    internal static class Log
    {
        public static void Write(Object o)
        {
            Traces.Init.Write(o);
        }

        public static void Write(String message, params Object[] args)
        {
            Traces.Init.Write(String.Format(message, args));
        }

        public static void WriteLine(Object o)
        {
            Write(o);
            WriteLine();
        }

        public static void WriteLine(String message, params Object[] args)
        {
            Write(message, args);
            WriteLine();
        }

        public static void WriteLine()
        {
            Write(Environment.NewLine);
        }
    }
}