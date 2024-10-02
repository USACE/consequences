//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (https://www.swig.org).
// Version 4.2.1
//
// Do not make changes to this file unless you know what you are doing - modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace OSGeo.OGR {

using global::System;
using global::System.Runtime.InteropServices;

public class Feature : global::System.IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;
  protected object swigParentRef;

  protected static object ThisOwn_true() { return null; }
  protected object ThisOwn_false() { return this; }

  public Feature(IntPtr cPtr, bool cMemoryOwn, object parent) {
    swigCMemOwn = cMemoryOwn;
    swigParentRef = parent;
    swigCPtr = new HandleRef(this, cPtr);
  }

  public static HandleRef getCPtr(Feature obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }
  public static HandleRef getCPtrAndDisown(Feature obj, object parent) {
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
  public static HandleRef getCPtrAndSetReference(Feature obj, object parent) {
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

  ~Feature() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          OgrPINVOKE.delete_Feature(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public Feature(FeatureDefn feature_def) : this(OgrPINVOKE.new_Feature(FeatureDefn.getCPtr(feature_def)), true, null) {
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
  }

  public FeatureDefn GetDefnRef() {
    IntPtr cPtr = OgrPINVOKE.Feature_GetDefnRef(swigCPtr);
    FeatureDefn ret = (cPtr == IntPtr.Zero) ? null : new FeatureDefn(cPtr, false, ThisOwn_false());
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public int SetGeometry(Geometry geom) {
    int ret = OgrPINVOKE.Feature_SetGeometry(swigCPtr, Geometry.getCPtr(geom));
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public int SetGeometryDirectly(Geometry geom) {
    int ret = OgrPINVOKE.Feature_SetGeometryDirectly(swigCPtr, Geometry.getCPtrAndDisown(geom, ThisOwn_false()));
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public Geometry GetGeometryRef() {
    IntPtr cPtr = OgrPINVOKE.Feature_GetGeometryRef(swigCPtr);
    Geometry ret = (cPtr == IntPtr.Zero) ? null : new Geometry(cPtr, false, ThisOwn_false());
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }
    
    public IntPtr GetGeometryRefPtr() {
    IntPtr cPtr = OgrPINVOKE.Feature_GetGeometryRef(swigCPtr);
    //Geometry ret = (cPtr == IntPtr.Zero) ? null : new Geometry(cPtr, false, ThisOwn_false());
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return cPtr;
  }

    public static IntPtr GetGeometryRefPtr(object owner, IntPtr ftPtr)
    {
      IntPtr cPtr = OgrPINVOKE.Feature_GetGeometryRef(new HandleRef(owner, ftPtr));
      //Geometry ret = (cPtr == IntPtr.Zero) ? null : new Geometry(cPtr, false, ThisOwn_false());
      if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
      return cPtr;
    }

    public int SetGeomField(int iField, Geometry geom) {
    int ret = OgrPINVOKE.Feature_SetGeomField__SWIG_0(swigCPtr, iField, Geometry.getCPtr(geom));
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public int SetGeomField(string field_name, Geometry geom) {
    int ret = OgrPINVOKE.Feature_SetGeomField__SWIG_1(swigCPtr, field_name, Geometry.getCPtr(geom));
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public int SetGeomFieldDirectly(int iField, Geometry geom) {
    int ret = OgrPINVOKE.Feature_SetGeomFieldDirectly__SWIG_0(swigCPtr, iField, Geometry.getCPtrAndDisown(geom, ThisOwn_false()));
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public int SetGeomFieldDirectly(string field_name, Geometry geom) {
    int ret = OgrPINVOKE.Feature_SetGeomFieldDirectly__SWIG_1(swigCPtr, field_name, Geometry.getCPtrAndDisown(geom, ThisOwn_false()));
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public Geometry GetGeomFieldRef(int iField) {
    IntPtr cPtr = OgrPINVOKE.Feature_GetGeomFieldRef__SWIG_0(swigCPtr, iField);
    Geometry ret = (cPtr == IntPtr.Zero) ? null : new Geometry(cPtr, false, ThisOwn_false());
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public Geometry GetGeomFieldRef(string field_name) {
    IntPtr cPtr = OgrPINVOKE.Feature_GetGeomFieldRef__SWIG_1(swigCPtr, field_name);
    Geometry ret = (cPtr == IntPtr.Zero) ? null : new Geometry(cPtr, false, ThisOwn_false());
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public Feature Clone() {
    IntPtr cPtr = OgrPINVOKE.Feature_Clone(swigCPtr);
    Feature ret = (cPtr == IntPtr.Zero) ? null : new Feature(cPtr, true, ThisOwn_true());
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool Equal(Feature feature) {
    bool ret = OgrPINVOKE.Feature_Equal(swigCPtr, Feature.getCPtr(feature));
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public int GetFieldCount() {
    int ret = OgrPINVOKE.Feature_GetFieldCount(swigCPtr);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public FieldDefn GetFieldDefnRef(int id) {
    IntPtr cPtr = OgrPINVOKE.Feature_GetFieldDefnRef__SWIG_0(swigCPtr, id);
    FieldDefn ret = (cPtr == IntPtr.Zero) ? null : new FieldDefn(cPtr, false, ThisOwn_false());
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public FieldDefn GetFieldDefnRef(string field_name) {
    IntPtr cPtr = OgrPINVOKE.Feature_GetFieldDefnRef__SWIG_1(swigCPtr, field_name);
    FieldDefn ret = (cPtr == IntPtr.Zero) ? null : new FieldDefn(cPtr, false, ThisOwn_false());
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public int GetGeomFieldCount() {
    int ret = OgrPINVOKE.Feature_GetGeomFieldCount(swigCPtr);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public GeomFieldDefn GetGeomFieldDefnRef(int id) {
    IntPtr cPtr = OgrPINVOKE.Feature_GetGeomFieldDefnRef__SWIG_0(swigCPtr, id);
    GeomFieldDefn ret = (cPtr == IntPtr.Zero) ? null : new GeomFieldDefn(cPtr, false, ThisOwn_false());
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public GeomFieldDefn GetGeomFieldDefnRef(string field_name) {
    IntPtr cPtr = OgrPINVOKE.Feature_GetGeomFieldDefnRef__SWIG_1(swigCPtr, field_name);
    GeomFieldDefn ret = (cPtr == IntPtr.Zero) ? null : new GeomFieldDefn(cPtr, false, ThisOwn_false());
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public string GetFieldAsString(int id) {
        /* %typemap(csout) (const char *utf8_path) */
        IntPtr cPtr = OgrPINVOKE.Feature_GetFieldAsString__SWIG_0(swigCPtr, id);
        string ret = Ogr.Utf8BytesToString(cPtr);
        
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
        return ret;
}

  public string GetFieldAsString(string field_name) {
        /* %typemap(csout) (const char *utf8_path) */
        IntPtr cPtr = OgrPINVOKE.Feature_GetFieldAsString__SWIG_1(swigCPtr, field_name);
        string ret = Ogr.Utf8BytesToString(cPtr);
        
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
        return ret;
  }

    // Zach M has made this function to bypass string allocation
    public IntPtr GetFieldAsStringPtr(string field_name)
    {
      /* %typemap(csout) (const char *utf8_path) */
      IntPtr cPtr = OgrPINVOKE.Feature_GetFieldAsString__SWIG_1(swigCPtr, field_name);

      if (OgrPINVOKE.SWIGPendingException.Pending)
        throw OgrPINVOKE.SWIGPendingException.Retrieve();

      return cPtr;
    }

    public string GetFieldAsISO8601DateTime(int id, string[] options) {
    string ret = OgrPINVOKE.Feature_GetFieldAsISO8601DateTime__SWIG_0(swigCPtr, id, (options != null)? new OgrPINVOKE.StringListMarshal(options)._ar : null);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public string GetFieldAsISO8601DateTime(string field_name, string[] options) {
    string ret = OgrPINVOKE.Feature_GetFieldAsISO8601DateTime__SWIG_1(swigCPtr, field_name, (options != null)? new OgrPINVOKE.StringListMarshal(options)._ar : null);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public int GetFieldAsInteger(int id) {
    int ret = OgrPINVOKE.Feature_GetFieldAsInteger__SWIG_0(swigCPtr, id);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public int GetFieldAsInteger(string field_name) {
    int ret = OgrPINVOKE.Feature_GetFieldAsInteger__SWIG_1(swigCPtr, field_name);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public long GetFieldAsInteger64(int id) {
    long res = OgrPINVOKE.Feature_GetFieldAsInteger64__SWIG_0(swigCPtr, id);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return res;
}

  public long GetFieldAsInteger64(string field_name) {
    long res = OgrPINVOKE.Feature_GetFieldAsInteger64__SWIG_1(swigCPtr, field_name);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return res;
}

  public double GetFieldAsDouble(int id) {
    double ret = OgrPINVOKE.Feature_GetFieldAsDouble__SWIG_0(swigCPtr, id);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public double GetFieldAsDouble(string field_name) {
    double ret = OgrPINVOKE.Feature_GetFieldAsDouble__SWIG_1(swigCPtr, field_name);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void GetFieldAsDateTime(int id, out int pnYear, out int pnMonth, out int pnDay, out int pnHour, out int pnMinute, out float pfSecond, out int pnTZFlag) {
    OgrPINVOKE.Feature_GetFieldAsDateTime__SWIG_0(swigCPtr, id, out pnYear, out pnMonth, out pnDay, out pnHour, out pnMinute, out pfSecond, out pnTZFlag);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
  }

  public void GetFieldAsDateTime(string field_name, out int pnYear, out int pnMonth, out int pnDay, out int pnHour, out int pnMinute, out float pfSecond, out int pnTZFlag) {
    OgrPINVOKE.Feature_GetFieldAsDateTime__SWIG_1(swigCPtr, field_name, out pnYear, out pnMonth, out pnDay, out pnHour, out pnMinute, out pfSecond, out pnTZFlag);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
  }

  public int[] GetFieldAsIntegerList(int id, out int count) {
        /* %typemap(csout) int *intList */
        IntPtr cPtr = OgrPINVOKE.Feature_GetFieldAsIntegerList(swigCPtr, id, out count);
        int[] ret = new int[count];
        if (count > 0) {
	        System.Runtime.InteropServices.Marshal.Copy(cPtr, ret, 0, count);
        }
        
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
        return ret;
}

  public double[] GetFieldAsDoubleList(int id, out int count) {
        /* %typemap(csout) int *intList */
        IntPtr cPtr = OgrPINVOKE.Feature_GetFieldAsDoubleList(swigCPtr, id, out count);
        double[] ret = new double[count];
        if (count > 0) {
	        System.Runtime.InteropServices.Marshal.Copy(cPtr, ret, 0, count);
        }
        
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
        return ret;
}

  public string[] GetFieldAsStringList(int id) {
        /* %typemap(csout) char**options */
        IntPtr cPtr = OgrPINVOKE.Feature_GetFieldAsStringList(swigCPtr, id);
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
        
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
        return ret;
}

  public bool IsFieldSet(int id) {
    bool ret = OgrPINVOKE.Feature_IsFieldSet__SWIG_0(swigCPtr, id);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool IsFieldSet(string field_name) {
    bool ret = OgrPINVOKE.Feature_IsFieldSet__SWIG_1(swigCPtr, field_name);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool IsFieldNull(int id) {
    bool ret = OgrPINVOKE.Feature_IsFieldNull__SWIG_0(swigCPtr, id);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool IsFieldNull(string field_name) {
    bool ret = OgrPINVOKE.Feature_IsFieldNull__SWIG_1(swigCPtr, field_name);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool IsFieldSetAndNotNull(int id) {
    bool ret = OgrPINVOKE.Feature_IsFieldSetAndNotNull__SWIG_0(swigCPtr, id);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool IsFieldSetAndNotNull(string field_name) {
    bool ret = OgrPINVOKE.Feature_IsFieldSetAndNotNull__SWIG_1(swigCPtr, field_name);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public int GetFieldIndex(string field_name) {
    int ret = OgrPINVOKE.Feature_GetFieldIndex(swigCPtr, field_name);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public int GetGeomFieldIndex(string field_name) {
    int ret = OgrPINVOKE.Feature_GetGeomFieldIndex(swigCPtr, field_name);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public long GetFID() {
    long res = OgrPINVOKE.Feature_GetFID(swigCPtr);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return res;
}

  public int SetFID(long fid) {
    int ret = OgrPINVOKE.Feature_SetFID(swigCPtr, fid);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void DumpReadable() {
    OgrPINVOKE.Feature_DumpReadable(swigCPtr);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
  }

  public string DumpReadableAsString(string[] options) {
    string ret = OgrPINVOKE.Feature_DumpReadableAsString(swigCPtr, (options != null)? new OgrPINVOKE.StringListMarshal(options)._ar : null);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void UnsetField(int id) {
    OgrPINVOKE.Feature_UnsetField__SWIG_0(swigCPtr, id);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
  }

  public void UnsetField(string field_name) {
    OgrPINVOKE.Feature_UnsetField__SWIG_1(swigCPtr, field_name);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetFieldNull(int id) {
    OgrPINVOKE.Feature_SetFieldNull__SWIG_0(swigCPtr, id);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetFieldNull(string field_name) {
    OgrPINVOKE.Feature_SetFieldNull__SWIG_1(swigCPtr, field_name);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetField(int id, string value) {
    OgrPINVOKE.Feature_SetField__SWIG_0(swigCPtr, id, Ogr.StringToUtf8Bytes(value));
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetField(string field_name, string value) {
    OgrPINVOKE.Feature_SetField__SWIG_1(swigCPtr, field_name, Ogr.StringToUtf8Bytes(value));
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetFieldInteger64(int id, long value) {
    OgrPINVOKE.Feature_SetFieldInteger64(swigCPtr, id, value);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetField(int id, int value) {
    OgrPINVOKE.Feature_SetField__SWIG_2(swigCPtr, id, value);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetField(string field_name, int value) {
    OgrPINVOKE.Feature_SetField__SWIG_3(swigCPtr, field_name, value);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetField(int id, double value) {
    OgrPINVOKE.Feature_SetField__SWIG_4(swigCPtr, id, value);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetField(string field_name, double value) {
    OgrPINVOKE.Feature_SetField__SWIG_5(swigCPtr, field_name, value);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetField(int id, int year, int month, int day, int hour, int minute, float second, int tzflag) {
    OgrPINVOKE.Feature_SetField__SWIG_6(swigCPtr, id, year, month, day, hour, minute, second, tzflag);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetField(string field_name, int year, int month, int day, int hour, int minute, float second, int tzflag) {
    OgrPINVOKE.Feature_SetField__SWIG_7(swigCPtr, field_name, year, month, day, hour, minute, second, tzflag);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetFieldIntegerList(int id, int nList, int[] pList) {
    OgrPINVOKE.Feature_SetFieldIntegerList(swigCPtr, id, nList, pList);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetFieldDoubleList(int id, int nList, double[] pList) {
    OgrPINVOKE.Feature_SetFieldDoubleList(swigCPtr, id, nList, pList);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetFieldStringList(int id, string[] pList) {
    OgrPINVOKE.Feature_SetFieldStringList(swigCPtr, id, (pList != null)? new OgrPINVOKE.StringListMarshal(pList)._ar : null);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetFieldBinaryFromHexString(int id, string pszValue) {
    OgrPINVOKE.Feature_SetFieldBinaryFromHexString__SWIG_0(swigCPtr, id, pszValue);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetFieldBinaryFromHexString(string field_name, string pszValue) {
    OgrPINVOKE.Feature_SetFieldBinaryFromHexString__SWIG_1(swigCPtr, field_name, pszValue);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
  }

  public int SetFrom(Feature other, int forgiving) {
    int ret = OgrPINVOKE.Feature_SetFrom(swigCPtr, Feature.getCPtr(other), forgiving);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public int SetFromWithMap(Feature other, int forgiving, int nList, int[] pList) {
    int ret = OgrPINVOKE.Feature_SetFromWithMap(swigCPtr, Feature.getCPtr(other), forgiving, nList, pList);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public string GetStyleString() {
    string ret = OgrPINVOKE.Feature_GetStyleString(swigCPtr);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void SetStyleString(string the_string) {
    OgrPINVOKE.Feature_SetStyleString(swigCPtr, the_string);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
  }

  public FieldType GetFieldType(int id) {
    FieldType ret = (FieldType)OgrPINVOKE.Feature_GetFieldType__SWIG_0(swigCPtr, id);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public FieldType GetFieldType(string field_name) {
    FieldType ret = (FieldType)OgrPINVOKE.Feature_GetFieldType__SWIG_1(swigCPtr, field_name);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public int Validate(int flags, int bEmitError) {
    int ret = OgrPINVOKE.Feature_Validate(swigCPtr, flags, bEmitError);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void FillUnsetWithDefault(int bNotNullableOnly, string[] options) {
    OgrPINVOKE.Feature_FillUnsetWithDefault(swigCPtr, bNotNullableOnly, (options != null)? new OgrPINVOKE.StringListMarshal(options)._ar : null);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
  }

  public string GetNativeData() {
    string ret = OgrPINVOKE.Feature_GetNativeData(swigCPtr);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public string GetNativeMediaType() {
    string ret = OgrPINVOKE.Feature_GetNativeMediaType(swigCPtr);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void SetNativeData(string nativeData) {
    OgrPINVOKE.Feature_SetNativeData(swigCPtr, nativeData);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetNativeMediaType(string nativeMediaType) {
    OgrPINVOKE.Feature_SetNativeMediaType(swigCPtr, nativeMediaType);
    if (OgrPINVOKE.SWIGPendingException.Pending) throw OgrPINVOKE.SWIGPendingException.Retrieve();
  }

}

}
