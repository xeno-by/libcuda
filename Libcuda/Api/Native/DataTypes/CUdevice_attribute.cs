﻿namespace Libcuda.Api.Native.DataTypes
{
    // http://developer.download.nvidia.com/compute/cuda/3_1/toolkit/docs/online/group__CUDA__TYPES_g3b9f561d2a42733dde99b2cedcaa413a.html
    public enum CUdevice_attribute
    {
        MaxThreadsPerBlock = 1,
        MaxBlockDimX = 2,
        MaxBlockDimY = 3,
        MaxBlockDimZ = 4,
        MaxGridDimX = 5,
        MaxGridDimY = 6,
        MaxGridDimZ = 7,
        MaxSharedMemoryPerBlock = 8,
        TotalConstantMemory = 9,
        WarpSize = 10,
        MaxPitch = 11,
        MaxRegistersPerBlock = 12,
        ClockRate = 13,
        TextureAlignment = 14,
        GPUOverlap = 15,
        MultiProcessorCount = 16,
        KernelExecTimeout = 17,
        Integrated = 18,
        CanMapHostMemory = 19,
        ComputeMode = 20,
        MaxTexture1dWidth = 21,
        MaxTexture2dWidth = 22,
        MaxTexture2dHeight = 23,
        MaxTexture3dWidth = 24,
        MaxTexture3dHeight = 25,
        MaxTexture3dDepth = 26,
        MaxTexture2dArrayWidth = 27,
        MaxTexture2dArrayHeight = 28,
        MaxTexture2dArrayNumSlices = 29,
        SurfaceAlignment = 30,
        ConcurrentKernels = 31,
        EccEnabled = 32,
        PciBusId = 33,
        PciDeviceId = 34,
    }
}