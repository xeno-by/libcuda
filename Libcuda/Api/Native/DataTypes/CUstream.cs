using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Libcuda.Api.Native.DataTypes
{
    [StructLayout(LayoutKind.Sequential)]
    [DebuggerNonUserCode]
    public struct CUstream
    {
        public IntPtr Handle;

        public static CUstream Null { get { return (CUstream)IntPtr.Zero; } }
        public bool IsNull { get { return Handle == Null; } }
        public bool IsNotNull { get { return !IsNull; } }
        public static implicit operator IntPtr(CUstream @this) { return @this.Handle; }
        public static explicit operator CUstream(IntPtr handle) { return new CUstream{Handle = handle}; }

        public bool Equals(CUstream other) { return other.Handle.Equals(Handle); }
        public override bool Equals(Object obj) { if (ReferenceEquals(null, obj)) return false; if (obj.GetType() != typeof(CUstream)) return false; return Equals((CUstream)obj); }
        public override int GetHashCode() { return Handle.GetHashCode(); }
        public static bool operator ==(CUstream left, CUstream right) { return left.Equals(right); }
        public static bool operator !=(CUstream left, CUstream right) { return !left.Equals(right); }

        public override String ToString()
        {
            if (this == Null) return "CUstream null";
            return String.Format("CUstream 0x{0}", Handle.ToString("x8"));
        }
    }
}