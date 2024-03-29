using System;
using System.Collections.Generic;
using System.Diagnostics;
using Libcuda.Api.Jit;
using Libcuda.Api.Native.DataTypes;
using Libcuda.Api.Run;
using Libcuda.DataTypes;
using XenoGears.Functional;
using XenoGears.Assertions;
using System.Linq;

namespace Libcuda
{
    // todo. think better about run API
    // currently it's very tedious to use it correctly (i.e. to guarantee zero leaks)

    [DebuggerNonUserCode]
    public static class RunFacade
    {
        public static KernelResult Run(this JittedKernel kernel, dim3 gridDim, dim3 blockDim, params KernelArgument[] args)
        {
            kernel.AssertNotNull();
            args = args ?? Seq.Empty<KernelArgument>().ToArray();
            CudaDriver.Ensure();

            return kernel.Function.Run(gridDim, blockDim, args);
        }

        public static KernelResult Run(this JittedKernel kernel, dim3 gridDim, dim3 blockDim, IEnumerable<KernelArgument> args)
        {
            kernel.AssertNotNull();
            args = args ?? Seq.Empty<KernelArgument>().ToArray();
            CudaDriver.Ensure();

            return kernel.Function.Run(gridDim, blockDim, args);
        }

        public static KernelResult Run(this JittedFunction function, dim3 gridDim, dim3 blockDim, params KernelArgument[] args)
        {
            function.AssertNotNull();
            args = args ?? Seq.Empty<KernelArgument>().ToArray();
            CudaDriver.Ensure();

            return function.Run(gridDim, blockDim, (IEnumerable<KernelArgument>)args);
        }

        public static KernelResult Run(this JittedFunction function, dim3 gridDim, dim3 blockDim, IEnumerable<KernelArgument> args)
        {
            function.AssertNotNull();
            args = args ?? Seq.Empty<KernelArgument>().ToArray();
            CudaDriver.Ensure();

            var invocation = new KernelInvocation(function, args);
            return invocation.Launch(gridDim, blockDim);
        }

        public static KernelResult Run(this CUfunction function, dim3 gridDim, dim3 blockDim, params KernelArgument[] args)
        {
            function.IsNotNull.AssertTrue();
            args = args ?? Seq.Empty<KernelArgument>().ToArray();
            CudaDriver.Ensure();

            return new JittedFunction(function).Run(gridDim, blockDim, args);
        }

        public static KernelResult Run(this CUfunction function, dim3 gridDim, dim3 blockDim, IEnumerable<KernelArgument> args)
        {
            function.IsNotNull.AssertTrue();
            args = args ?? Seq.Empty<KernelArgument>().ToArray();
            CudaDriver.Ensure();

            return new JittedFunction(function).Run(gridDim, blockDim, args);
        }

        public static Object Invoke(this JittedKernel kernel, dim3 gridDim, dim3 blockDim, params KernelArgument[] args)
        {
            kernel.AssertNotNull();
            args = args ?? Seq.Empty<KernelArgument>().ToArray();
            CudaDriver.Ensure();

            return kernel.Function.Invoke(gridDim, blockDim, args);
        }

        public static Object Invoke(this JittedKernel kernel, dim3 gridDim, dim3 blockDim, IEnumerable<KernelArgument> args)
        {
            kernel.AssertNotNull();
            args = args ?? Seq.Empty<KernelArgument>().ToArray();
            CudaDriver.Ensure();

            return kernel.Function.Invoke(gridDim, blockDim, args);
        }

        public static Object Invoke(this JittedFunction function, dim3 gridDim, dim3 blockDim, params KernelArgument[] args)
        {
            function.AssertNotNull();
            args = args ?? Seq.Empty<KernelArgument>().ToArray();
            CudaDriver.Ensure();

            return function.Invoke(gridDim, blockDim, (IEnumerable<KernelArgument>)args);
        }

        public static Object Invoke(this JittedFunction function, dim3 gridDim, dim3 blockDim, IEnumerable<KernelArgument> args)
        {
            function.AssertNotNull();
            args = args ?? Seq.Empty<KernelArgument>().ToArray();
            CudaDriver.Ensure();

            var invocation = new KernelInvocation(function, args);
            var invocation_result = invocation.Launch(gridDim, blockDim);
            var result = invocation_result.Result;
            args.ForEach(arg => arg.Dispose());
            return result;
        }

        public static Object Invoke(this CUfunction function, dim3 gridDim, dim3 blockDim, params KernelArgument[] args)
        {
            function.IsNotNull.AssertTrue();
            args = args ?? Seq.Empty<KernelArgument>().ToArray();
            CudaDriver.Ensure();

            return new JittedFunction(function).Invoke(gridDim, blockDim, args);
        }

        public static Object Invoke(this CUfunction function, dim3 gridDim, dim3 blockDim, IEnumerable<KernelArgument> args)
        {
            function.IsNotNull.AssertTrue();
            args = args ?? Seq.Empty<KernelArgument>().ToArray();
            CudaDriver.Ensure();

            return new JittedFunction(function).Invoke(gridDim, blockDim, args);
        }
    }
}