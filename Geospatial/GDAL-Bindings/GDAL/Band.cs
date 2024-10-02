//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (https://www.swig.org).
// Version 4.2.1
//
// Do not make changes to this file unless you know what you are doing - modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace OSGeo.GDAL {

using global::System;
using global::System.Runtime.InteropServices;

public class Band : MajorObject {
  private HandleRef swigCPtr;

  public Band(IntPtr cPtr, bool cMemoryOwn, object parent) : base(GdalPINVOKE.Band_SWIGUpcast(cPtr), cMemoryOwn, parent) {
    swigCPtr = new HandleRef(this, cPtr);
  }

  public static HandleRef getCPtr(Band obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }
  public static HandleRef getCPtrAndDisown(Band obj, object parent) {
    if (obj != null)
    {
      obj.swigCMemOwn = false;
      obj.swigParentRef = parent;
      return obj.swigCPtr;
    }
    else
    {
      return new HandleRef(null, IntPtr.Zero);
    }
  }
  public static HandleRef getCPtrAndSetReference(Band obj, object parent) {
    if (obj != null)
    {
      obj.swigParentRef = parent;
      return obj.swigCPtr;
    }
    else
    {
      return new HandleRef(null, IntPtr.Zero);
    }
  }

  ~Band() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          throw new global::System.MethodAccessException("C++ destructor does not have public access");
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }
/*! Eight bit unsigned integer */ /*@SWIG:C:/GDAL/Windows/gdal/swig/include/csharp\gdal_csharp.i,92,%rasterio_functions@*/
 public CPLErr ReadRaster(int xOff, int yOff, int xSize, int ySize, byte[] buffer, int buf_xSize, int buf_ySize, int pixelSpace, int lineSpace) {
      CPLErr retval;
      GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
      try {
          retval = ReadRaster(xOff, yOff, xSize, ySize, handle.AddrOfPinnedObject(), buf_xSize, buf_ySize, DataType.GDT_Byte, pixelSpace, lineSpace);
      } finally {
          handle.Free();
      }
      GC.KeepAlive(this);
      return retval;
  }
  public CPLErr WriteRaster(int xOff, int yOff, int xSize, int ySize, byte[] buffer, int buf_xSize, int buf_ySize, int pixelSpace, int lineSpace) {
      CPLErr retval;
      GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
      try {
          retval = WriteRaster(xOff, yOff, xSize, ySize, handle.AddrOfPinnedObject(), buf_xSize, buf_ySize, DataType.GDT_Byte, pixelSpace, lineSpace);
      } finally {
          handle.Free();
      }
      GC.KeepAlive(this);
      return retval;
  }
  public CPLErr ReadRaster(int xOff, int yOff, int xSize, int ySize, byte[] buffer, int buf_xSize, int buf_ySize, int pixelSpace, int lineSpace, RasterIOExtraArg extraArg) {
      CPLErr retval;
      GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
      try {
          retval = ReadRaster(xOff, yOff, xSize, ySize, handle.AddrOfPinnedObject(), buf_xSize, buf_ySize, DataType.GDT_Byte, pixelSpace, lineSpace, extraArg);
      } finally {
          handle.Free();
      }
      GC.KeepAlive(this);
      return retval;
  }
  public CPLErr WriteRaster(int xOff, int yOff, int xSize, int ySize, byte[] buffer, int buf_xSize, int buf_ySize, int pixelSpace, int lineSpace, RasterIOExtraArg extraArg) {
      CPLErr retval;
      GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
      try {
          retval = WriteRaster(xOff, yOff, xSize, ySize, handle.AddrOfPinnedObject(), buf_xSize, buf_ySize, DataType.GDT_Byte, pixelSpace, lineSpace, extraArg);
      } finally {
          handle.Free();
      }
      GC.KeepAlive(this);
      return retval;
  }

/*@SWIG@*/
/*! Sixteen bit signed integer */ /*@SWIG:C:/GDAL/Windows/gdal/swig/include/csharp\gdal_csharp.i,92,%rasterio_functions@*/
 public CPLErr ReadRaster(int xOff, int yOff, int xSize, int ySize, short[] buffer, int buf_xSize, int buf_ySize, int pixelSpace, int lineSpace) {
      CPLErr retval;
      GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
      try {
          retval = ReadRaster(xOff, yOff, xSize, ySize, handle.AddrOfPinnedObject(), buf_xSize, buf_ySize, DataType.GDT_Int16, pixelSpace, lineSpace);
      } finally {
          handle.Free();
      }
      GC.KeepAlive(this);
      return retval;
  }
  public CPLErr WriteRaster(int xOff, int yOff, int xSize, int ySize, short[] buffer, int buf_xSize, int buf_ySize, int pixelSpace, int lineSpace) {
      CPLErr retval;
      GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
      try {
          retval = WriteRaster(xOff, yOff, xSize, ySize, handle.AddrOfPinnedObject(), buf_xSize, buf_ySize, DataType.GDT_Int16, pixelSpace, lineSpace);
      } finally {
          handle.Free();
      }
      GC.KeepAlive(this);
      return retval;
  }
  public CPLErr ReadRaster(int xOff, int yOff, int xSize, int ySize, short[] buffer, int buf_xSize, int buf_ySize, int pixelSpace, int lineSpace, RasterIOExtraArg extraArg) {
      CPLErr retval;
      GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
      try {
          retval = ReadRaster(xOff, yOff, xSize, ySize, handle.AddrOfPinnedObject(), buf_xSize, buf_ySize, DataType.GDT_Int16, pixelSpace, lineSpace, extraArg);
      } finally {
          handle.Free();
      }
      GC.KeepAlive(this);
      return retval;
  }
  public CPLErr WriteRaster(int xOff, int yOff, int xSize, int ySize, short[] buffer, int buf_xSize, int buf_ySize, int pixelSpace, int lineSpace, RasterIOExtraArg extraArg) {
      CPLErr retval;
      GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
      try {
          retval = WriteRaster(xOff, yOff, xSize, ySize, handle.AddrOfPinnedObject(), buf_xSize, buf_ySize, DataType.GDT_Int16, pixelSpace, lineSpace, extraArg);
      } finally {
          handle.Free();
      }
      GC.KeepAlive(this);
      return retval;
  }

/*@SWIG@*/
/*! Thirty two bit signed integer */ /*@SWIG:C:/GDAL/Windows/gdal/swig/include/csharp\gdal_csharp.i,92,%rasterio_functions@*/
 public CPLErr ReadRaster(int xOff, int yOff, int xSize, int ySize, int[] buffer, int buf_xSize, int buf_ySize, int pixelSpace, int lineSpace) {
      CPLErr retval;
      GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
      try {
          retval = ReadRaster(xOff, yOff, xSize, ySize, handle.AddrOfPinnedObject(), buf_xSize, buf_ySize, DataType.GDT_Int32, pixelSpace, lineSpace);
      } finally {
          handle.Free();
      }
      GC.KeepAlive(this);
      return retval;
  }
  public CPLErr WriteRaster(int xOff, int yOff, int xSize, int ySize, int[] buffer, int buf_xSize, int buf_ySize, int pixelSpace, int lineSpace) {
      CPLErr retval;
      GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
      try {
          retval = WriteRaster(xOff, yOff, xSize, ySize, handle.AddrOfPinnedObject(), buf_xSize, buf_ySize, DataType.GDT_Int32, pixelSpace, lineSpace);
      } finally {
          handle.Free();
      }
      GC.KeepAlive(this);
      return retval;
  }
  public CPLErr ReadRaster(int xOff, int yOff, int xSize, int ySize, int[] buffer, int buf_xSize, int buf_ySize, int pixelSpace, int lineSpace, RasterIOExtraArg extraArg) {
      CPLErr retval;
      GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
      try {
          retval = ReadRaster(xOff, yOff, xSize, ySize, handle.AddrOfPinnedObject(), buf_xSize, buf_ySize, DataType.GDT_Int32, pixelSpace, lineSpace, extraArg);
      } finally {
          handle.Free();
      }
      GC.KeepAlive(this);
      return retval;
  }
  public CPLErr WriteRaster(int xOff, int yOff, int xSize, int ySize, int[] buffer, int buf_xSize, int buf_ySize, int pixelSpace, int lineSpace, RasterIOExtraArg extraArg) {
      CPLErr retval;
      GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
      try {
          retval = WriteRaster(xOff, yOff, xSize, ySize, handle.AddrOfPinnedObject(), buf_xSize, buf_ySize, DataType.GDT_Int32, pixelSpace, lineSpace, extraArg);
      } finally {
          handle.Free();
      }
      GC.KeepAlive(this);
      return retval;
  }

/*@SWIG@*/
/*! Thirty two bit floating point */ /*@SWIG:C:/GDAL/Windows/gdal/swig/include/csharp\gdal_csharp.i,92,%rasterio_functions@*/
 public CPLErr ReadRaster(int xOff, int yOff, int xSize, int ySize, float[] buffer, int buf_xSize, int buf_ySize, int pixelSpace, int lineSpace) {
      CPLErr retval;
      GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
      try {
          retval = ReadRaster(xOff, yOff, xSize, ySize, handle.AddrOfPinnedObject(), buf_xSize, buf_ySize, DataType.GDT_Float32, pixelSpace, lineSpace);
      } finally {
          handle.Free();
      }
      GC.KeepAlive(this);
      return retval;
  }
  public CPLErr WriteRaster(int xOff, int yOff, int xSize, int ySize, float[] buffer, int buf_xSize, int buf_ySize, int pixelSpace, int lineSpace) {
      CPLErr retval;
      GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
      try {
          retval = WriteRaster(xOff, yOff, xSize, ySize, handle.AddrOfPinnedObject(), buf_xSize, buf_ySize, DataType.GDT_Float32, pixelSpace, lineSpace);
      } finally {
          handle.Free();
      }
      GC.KeepAlive(this);
      return retval;
  }
  public CPLErr ReadRaster(int xOff, int yOff, int xSize, int ySize, float[] buffer, int buf_xSize, int buf_ySize, int pixelSpace, int lineSpace, RasterIOExtraArg extraArg) {
      CPLErr retval;
      GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
      try {
          retval = ReadRaster(xOff, yOff, xSize, ySize, handle.AddrOfPinnedObject(), buf_xSize, buf_ySize, DataType.GDT_Float32, pixelSpace, lineSpace, extraArg);
      } finally {
          handle.Free();
      }
      GC.KeepAlive(this);
      return retval;
  }
  public CPLErr WriteRaster(int xOff, int yOff, int xSize, int ySize, float[] buffer, int buf_xSize, int buf_ySize, int pixelSpace, int lineSpace, RasterIOExtraArg extraArg) {
      CPLErr retval;
      GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
      try {
          retval = WriteRaster(xOff, yOff, xSize, ySize, handle.AddrOfPinnedObject(), buf_xSize, buf_ySize, DataType.GDT_Float32, pixelSpace, lineSpace, extraArg);
      } finally {
          handle.Free();
      }
      GC.KeepAlive(this);
      return retval;
  }

/*@SWIG@*/
/*! Sixty four bit floating point */ /*@SWIG:C:/GDAL/Windows/gdal/swig/include/csharp\gdal_csharp.i,92,%rasterio_functions@*/
 public CPLErr ReadRaster(int xOff, int yOff, int xSize, int ySize, double[] buffer, int buf_xSize, int buf_ySize, int pixelSpace, int lineSpace) {
      CPLErr retval;
      GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
      try {
          retval = ReadRaster(xOff, yOff, xSize, ySize, handle.AddrOfPinnedObject(), buf_xSize, buf_ySize, DataType.GDT_Float64, pixelSpace, lineSpace);
      } finally {
          handle.Free();
      }
      GC.KeepAlive(this);
      return retval;
  }
  public CPLErr WriteRaster(int xOff, int yOff, int xSize, int ySize, double[] buffer, int buf_xSize, int buf_ySize, int pixelSpace, int lineSpace) {
      CPLErr retval;
      GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
      try {
          retval = WriteRaster(xOff, yOff, xSize, ySize, handle.AddrOfPinnedObject(), buf_xSize, buf_ySize, DataType.GDT_Float64, pixelSpace, lineSpace);
      } finally {
          handle.Free();
      }
      GC.KeepAlive(this);
      return retval;
  }
  public CPLErr ReadRaster(int xOff, int yOff, int xSize, int ySize, double[] buffer, int buf_xSize, int buf_ySize, int pixelSpace, int lineSpace, RasterIOExtraArg extraArg) {
      CPLErr retval;
      GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
      try {
          retval = ReadRaster(xOff, yOff, xSize, ySize, handle.AddrOfPinnedObject(), buf_xSize, buf_ySize, DataType.GDT_Float64, pixelSpace, lineSpace, extraArg);
      } finally {
          handle.Free();
      }
      GC.KeepAlive(this);
      return retval;
  }
  public CPLErr WriteRaster(int xOff, int yOff, int xSize, int ySize, double[] buffer, int buf_xSize, int buf_ySize, int pixelSpace, int lineSpace, RasterIOExtraArg extraArg) {
      CPLErr retval;
      GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
      try {
          retval = WriteRaster(xOff, yOff, xSize, ySize, handle.AddrOfPinnedObject(), buf_xSize, buf_ySize, DataType.GDT_Float64, pixelSpace, lineSpace, extraArg);
      } finally {
          handle.Free();
      }
      GC.KeepAlive(this);
      return retval;
  }

/*@SWIG@*/
  public int XSize {
    get {
      int ret = GdalPINVOKE.Band_XSize_get(swigCPtr);
      if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public int YSize {
    get {
      int ret = GdalPINVOKE.Band_YSize_get(swigCPtr);
      if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public DataType DataType {
    get {
      DataType ret = (DataType)GdalPINVOKE.Band_DataType_get(swigCPtr);
      if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public Dataset GetDataset() {
    IntPtr cPtr = GdalPINVOKE.Band_GetDataset(swigCPtr);
    Dataset ret = (cPtr == IntPtr.Zero) ? null : new Dataset(cPtr, false, ThisOwn_false());
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public int GetBand() {
    int ret = GdalPINVOKE.Band_GetBand(swigCPtr);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void GetBlockSize(out int pnBlockXSize, out int pnBlockYSize) {
    GdalPINVOKE.Band_GetBlockSize(swigCPtr, out pnBlockXSize, out pnBlockYSize);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
  }

  public ColorInterp GetColorInterpretation() {
    ColorInterp ret = (ColorInterp)GdalPINVOKE.Band_GetColorInterpretation(swigCPtr);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public ColorInterp GetRasterColorInterpretation() {
    ColorInterp ret = (ColorInterp)GdalPINVOKE.Band_GetRasterColorInterpretation(swigCPtr);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public CPLErr SetColorInterpretation(ColorInterp val) {
    CPLErr ret = (CPLErr)GdalPINVOKE.Band_SetColorInterpretation(swigCPtr, (int)val);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public CPLErr SetRasterColorInterpretation(ColorInterp val) {
    CPLErr ret = (CPLErr)GdalPINVOKE.Band_SetRasterColorInterpretation(swigCPtr, (int)val);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void GetNoDataValue(out double val, out int hasval) {
    GdalPINVOKE.Band_GetNoDataValue(swigCPtr, out val, out hasval);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
  }

  public CPLErr SetNoDataValue(double d) {
    CPLErr ret = (CPLErr)GdalPINVOKE.Band_SetNoDataValue(swigCPtr, d);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public CPLErr DeleteNoDataValue() {
    CPLErr ret = (CPLErr)GdalPINVOKE.Band_DeleteNoDataValue(swigCPtr);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public string GetUnitType() {
    string ret = GdalPINVOKE.Band_GetUnitType(swigCPtr);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public CPLErr SetUnitType(string val) {
    CPLErr ret = (CPLErr)GdalPINVOKE.Band_SetUnitType(swigCPtr, val);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public string[] GetRasterCategoryNames() {
        /* %typemap(csout) char**options */
        IntPtr cPtr = GdalPINVOKE.Band_GetRasterCategoryNames(swigCPtr);
        IntPtr objPtr;
        int count = 0;
        if (cPtr != IntPtr.Zero) {
            while (Marshal.ReadIntPtr(cPtr, count*IntPtr.Size) != IntPtr.Zero)
                ++count;
        }
        string[] ret = new string[count];
        if (count > 0) {
	        for(int cx = 0; cx < count; cx++) {
                objPtr = System.Runtime.InteropServices.Marshal.ReadIntPtr(cPtr, cx * System.Runtime.InteropServices.Marshal.SizeOf(typeof(IntPtr)));
                ret[cx]= (objPtr == IntPtr.Zero) ? null : System.Runtime.InteropServices.Marshal.PtrToStringAnsi(objPtr);
            }
        }
        
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
        return ret;
}

  public CPLErr SetRasterCategoryNames(string[] names) {
    CPLErr ret = (CPLErr)GdalPINVOKE.Band_SetRasterCategoryNames(swigCPtr, (names != null)? new GdalPINVOKE.StringListMarshal(names)._ar : null);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void GetMinimum(out double val, out int hasval) {
    GdalPINVOKE.Band_GetMinimum(swigCPtr, out val, out hasval);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
  }

  public void GetMaximum(out double val, out int hasval) {
    GdalPINVOKE.Band_GetMaximum(swigCPtr, out val, out hasval);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
  }

  public void GetOffset(out double val, out int hasval) {
    GdalPINVOKE.Band_GetOffset(swigCPtr, out val, out hasval);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
  }

  public void GetScale(out double val, out int hasval) {
    GdalPINVOKE.Band_GetScale(swigCPtr, out val, out hasval);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
  }

  public CPLErr SetOffset(double val) {
    CPLErr ret = (CPLErr)GdalPINVOKE.Band_SetOffset(swigCPtr, val);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public CPLErr SetScale(double val) {
    CPLErr ret = (CPLErr)GdalPINVOKE.Band_SetScale(swigCPtr, val);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public CPLErr GetStatistics(int approx_ok, int force, out double min, out double max, out double mean, out double stddev) {
    CPLErr ret = (CPLErr)GdalPINVOKE.Band_GetStatistics(swigCPtr, approx_ok, force, out min, out max, out mean, out stddev);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public CPLErr ComputeStatistics(bool approx_ok, out double min, out double max, out double mean, out double stddev, Gdal.GDALProgressFuncDelegate callback, string callback_data) {
    CPLErr ret = (CPLErr)GdalPINVOKE.Band_ComputeStatistics(swigCPtr, approx_ok, out min, out max, out mean, out stddev, callback, callback_data);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public CPLErr SetStatistics(double min, double max, double mean, double stddev) {
    CPLErr ret = (CPLErr)GdalPINVOKE.Band_SetStatistics(swigCPtr, min, max, mean, stddev);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public int GetOverviewCount() {
    int ret = GdalPINVOKE.Band_GetOverviewCount(swigCPtr);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public Band GetOverview(int i) {
    IntPtr cPtr = GdalPINVOKE.Band_GetOverview(swigCPtr, i);
    Band ret = (cPtr == IntPtr.Zero) ? null : new Band(cPtr, false, ThisOwn_false());
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public int Checksum(int xoff, int yoff, ref int xsize, ref int ysize) {
    int ret = GdalPINVOKE.Band_Checksum(swigCPtr, xoff, yoff, (IntPtr)xsize, (IntPtr)ysize);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void ComputeRasterMinMax(double[] argout, int approx_ok) {
    GdalPINVOKE.Band_ComputeRasterMinMax(swigCPtr, argout, approx_ok);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
  }

  public void ComputeBandStats(double[] argout, int samplestep) {
    GdalPINVOKE.Band_ComputeBandStats(swigCPtr, argout, samplestep);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
  }

  public CPLErr Fill(double real_fill, double imag_fill) {
    CPLErr ret = (CPLErr)GdalPINVOKE.Band_Fill(swigCPtr, real_fill, imag_fill);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void FlushCache() {
    GdalPINVOKE.Band_FlushCache(swigCPtr);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
  }

  public ColorTable GetRasterColorTable() {
    IntPtr cPtr = GdalPINVOKE.Band_GetRasterColorTable(swigCPtr);
    ColorTable ret = (cPtr == IntPtr.Zero) ? null : new ColorTable(cPtr, false, ThisOwn_false());
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public ColorTable GetColorTable() {
    IntPtr cPtr = GdalPINVOKE.Band_GetColorTable(swigCPtr);
    ColorTable ret = (cPtr == IntPtr.Zero) ? null : new ColorTable(cPtr, false, ThisOwn_false());
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public int SetRasterColorTable(ColorTable arg) {
    int ret = GdalPINVOKE.Band_SetRasterColorTable(swigCPtr, ColorTable.getCPtr(arg));
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public int SetColorTable(ColorTable arg) {
    int ret = GdalPINVOKE.Band_SetColorTable(swigCPtr, ColorTable.getCPtr(arg));
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public RasterAttributeTable GetDefaultRAT() {
    IntPtr cPtr = GdalPINVOKE.Band_GetDefaultRAT(swigCPtr);
    RasterAttributeTable ret = (cPtr == IntPtr.Zero) ? null : new RasterAttributeTable(cPtr, false, ThisOwn_false());
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public int SetDefaultRAT(RasterAttributeTable table) {
    int ret = GdalPINVOKE.Band_SetDefaultRAT(swigCPtr, RasterAttributeTable.getCPtr(table));
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public Band GetMaskBand() {
    IntPtr cPtr = GdalPINVOKE.Band_GetMaskBand(swigCPtr);
    Band ret = (cPtr == IntPtr.Zero) ? null : new Band(cPtr, false, ThisOwn_false());
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public int GetMaskFlags() {
    int ret = GdalPINVOKE.Band_GetMaskFlags(swigCPtr);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public CPLErr CreateMaskBand(int nFlags) {
    CPLErr ret = (CPLErr)GdalPINVOKE.Band_CreateMaskBand(swigCPtr, nFlags);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool IsMaskBand() {
    bool ret = GdalPINVOKE.Band_IsMaskBand(swigCPtr);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public CPLErr GetHistogram(double min, double max, int buckets, int[] panHistogram, int include_out_of_range, int approx_ok, Gdal.GDALProgressFuncDelegate callback, string callback_data) {
    CPLErr ret = (CPLErr)GdalPINVOKE.Band_GetHistogram(swigCPtr, min, max, buckets, panHistogram, include_out_of_range, approx_ok, callback, callback_data);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public CPLErr GetDefaultHistogram(out double min_ret, out double max_ret, out int buckets_ret, out int[] ppanHistogram, int force, Gdal.GDALProgressFuncDelegate callback, string callback_data) {
    CPLErr ret = (CPLErr)GdalPINVOKE.Band_GetDefaultHistogram(swigCPtr, out min_ret, out max_ret, out buckets_ret, out ppanHistogram, force, callback, callback_data);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public CPLErr SetDefaultHistogram(double min, double max, int buckets_in, int[] panHistogram_in) {
    CPLErr ret = (CPLErr)GdalPINVOKE.Band_SetDefaultHistogram(swigCPtr, min, max, buckets_in, panHistogram_in);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool HasArbitraryOverviews() {
    bool ret = GdalPINVOKE.Band_HasArbitraryOverviews(swigCPtr);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public string[] GetCategoryNames() {
        /* %typemap(csout) char**options */
        IntPtr cPtr = GdalPINVOKE.Band_GetCategoryNames(swigCPtr);
        IntPtr objPtr;
        int count = 0;
        if (cPtr != IntPtr.Zero) {
            while (Marshal.ReadIntPtr(cPtr, count*IntPtr.Size) != IntPtr.Zero)
                ++count;
        }
        string[] ret = new string[count];
        if (count > 0) {
	        for(int cx = 0; cx < count; cx++) {
                objPtr = System.Runtime.InteropServices.Marshal.ReadIntPtr(cPtr, cx * System.Runtime.InteropServices.Marshal.SizeOf(typeof(IntPtr)));
                ret[cx]= (objPtr == IntPtr.Zero) ? null : System.Runtime.InteropServices.Marshal.PtrToStringAnsi(objPtr);
            }
        }
        
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
        return ret;
}

  public CPLErr SetCategoryNames(string[] papszCategoryNames) {
    CPLErr ret = (CPLErr)GdalPINVOKE.Band_SetCategoryNames(swigCPtr, (papszCategoryNames != null)? new GdalPINVOKE.StringListMarshal(papszCategoryNames)._ar : null);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public CPLErr AdviseRead(int xoff, int yoff, int xsize, int ysize, SWIGTYPE_p_int buf_xsize, SWIGTYPE_p_int buf_ysize, ref int buf_type, string[] options) {
    CPLErr ret = (CPLErr)GdalPINVOKE.Band_AdviseRead(swigCPtr, xoff, yoff, xsize, ysize, SWIGTYPE_p_int.getCPtr(buf_xsize), SWIGTYPE_p_int.getCPtr(buf_ysize), (IntPtr)buf_type, (options != null)? new GdalPINVOKE.StringListMarshal(options)._ar : null);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public MDArray AsMDArray() {
    IntPtr cPtr = GdalPINVOKE.Band_AsMDArray(swigCPtr);
    MDArray ret = (cPtr == IntPtr.Zero) ? null : new MDArray(cPtr, true, ThisOwn_true());
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void _EnablePixelTypeSignedByteWarning(bool b) {
    GdalPINVOKE.Band__EnablePixelTypeSignedByteWarning(swigCPtr, b);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
  }

  public CPLErr ReadRaster(int xOff, int yOff, int xSize, int ySize, IntPtr buffer, int buf_xSize, int buf_ySize, DataType buf_type, int pixelSpace, int lineSpace) {
    CPLErr ret = (CPLErr)GdalPINVOKE.Band_ReadRaster__SWIG_0(swigCPtr, xOff, yOff, xSize, ySize, buffer, buf_xSize, buf_ySize, (int)buf_type, pixelSpace, lineSpace);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public CPLErr WriteRaster(int xOff, int yOff, int xSize, int ySize, IntPtr buffer, int buf_xSize, int buf_ySize, DataType buf_type, int pixelSpace, int lineSpace) {
    CPLErr ret = (CPLErr)GdalPINVOKE.Band_WriteRaster__SWIG_0(swigCPtr, xOff, yOff, xSize, ySize, buffer, buf_xSize, buf_ySize, (int)buf_type, pixelSpace, lineSpace);
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public CPLErr ReadRaster(int xOff, int yOff, int xSize, int ySize, IntPtr buffer, int buf_xSize, int buf_ySize, DataType buf_type, int pixelSpace, int lineSpace, RasterIOExtraArg extraArg) {
    CPLErr ret = (CPLErr)GdalPINVOKE.Band_ReadRaster__SWIG_1(swigCPtr, xOff, yOff, xSize, ySize, buffer, buf_xSize, buf_ySize, (int)buf_type, pixelSpace, lineSpace, RasterIOExtraArg.getCPtr(extraArg));
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public CPLErr WriteRaster(int xOff, int yOff, int xSize, int ySize, IntPtr buffer, int buf_xSize, int buf_ySize, DataType buf_type, int pixelSpace, int lineSpace, RasterIOExtraArg extraArg) {
    CPLErr ret = (CPLErr)GdalPINVOKE.Band_WriteRaster__SWIG_1(swigCPtr, xOff, yOff, xSize, ySize, buffer, buf_xSize, buf_ySize, (int)buf_type, pixelSpace, lineSpace, RasterIOExtraArg.getCPtr(extraArg));
    if (GdalPINVOKE.SWIGPendingException.Pending) throw GdalPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

}

}
