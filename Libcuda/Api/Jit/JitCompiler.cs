using System;
using System.Diagnostics;
using Libcuda.Api.Native;
using Libcuda.Api.Native.DataTypes;
using Libcuda.Versions;
using XenoGears.Functional;
using XenoGears.Strings;

namespace Libcuda.Api.Jit
{
    [DebuggerNonUserCode]
    public class JitCompiler
    {
        public HardwareIsa Target { get; set; }
        private int _optimizationLevel = 4; // 0..4, higher is better
        public int OptimizationLevel { get { return _optimizationLevel; } set { _optimizationLevel = value; } }
        public int MaxRegistersPerThread { get; set; }
        public int PlannedThreadsPerBlock { get; set; }

        // todo. cache jitted kernels
        public JitResult Compile(String ptx)
        {
            Log.WriteLine("Peforming JIT compilation...");
            Log.WriteLine("    PTX source text                              : {0}", "(see below)");
            Log.WriteLine("    Hardware ISA                                 : {0}", Target);
            Log.WriteLine("    Max registers per thread                     : {0}", MaxRegistersPerThread);
            Log.WriteLine("    Planned threads per block                    : {0}", PlannedThreadsPerBlock);
            Log.WriteLine("    Optimization level (0 - 4, higher is better) : {0}", OptimizationLevel);
            Log.WriteLine(Environment.NewLine + "*".Repeat(120));
            Log.WriteLine(ptx.QuoteBraces().TrimEnd());
            Log.WriteLine(120.Times("*"));
            Log.WriteLine();

            var options = new CUjit_options();
            options.MaxRegistersPerThread = MaxRegistersPerThread;
            options.PlannedThreadsPerBlock = PlannedThreadsPerBlock;
            options.OptimizationLevel = OptimizationLevel;
            options.TargetFromContext = false;
            options.Target = Target.ToCUjit_target();
            options.FallbackStrategy = CUjit_fallbackstrategy.PreferPtx;

            try
            {
                var result = nvcuda.cuModuleLoadDataEx(ptx, options);
                return new JitResult(this, ptx, result);
            }
            catch (CUjit_exception jex)
            {
                var result = new JitResult(this, ptx, jex.JitResult);
                throw new JitException(result);
            }
        }
    }
}