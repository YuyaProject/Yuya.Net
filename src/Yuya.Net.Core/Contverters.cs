using System;

namespace Yuya.Net.Core
{
    public static class Contverters
    {
        public static Boolean? GetBoolean(object value)
        {
            if (value == null) return null;
            if (value == DBNull.Value) return null;
            if (value is Boolean realValue) return realValue;
            if (Boolean.TryParse(value.ToString(), out realValue)) return realValue;
            return null;
        }

        public static Byte? GetByte(object value)
        {
            if (value == null) return null;
            if (value == DBNull.Value) return null;
            if (value is Byte realValue) return realValue;
            if (Byte.TryParse(value.ToString(), out realValue)) return realValue;
            return null;
        }

        public static SByte? GetSByte(object value)
        {
            if (value == null) return null;
            if (value == DBNull.Value) return null;
            if (value is SByte realValue) return realValue;
            if (SByte.TryParse(value.ToString(), out realValue)) return realValue;
            return null;
        }

        public static Int16? GetInt16(object value)
        {
            if (value == null) return null;
            if (value == DBNull.Value) return null;
            if (value is Int16 realValue) return realValue;
            if (Int16.TryParse(value.ToString(), out realValue)) return realValue;
            return null;
        }

        public static UInt16? GetUInt16(object value)
        {
            if (value == null) return null;
            if (value == DBNull.Value) return null;
            if (value is UInt16 realValue) return realValue;
            if (UInt16.TryParse(value.ToString(), out realValue)) return realValue;
            return null;
        }

        public static Int32? GetInt32(object value)
        {
            if (value == null) return null;
            if (value == DBNull.Value) return null;
            if (value is Int32 realValue) return realValue;
            if (Int32.TryParse(value.ToString(), out realValue)) return realValue;
            return null;
        }

        public static UInt32? GetUInt32(object value)
        {
            if (value == null) return null;
            if (value == DBNull.Value) return null;
            if (value is UInt32 realValue) return realValue;
            if (UInt32.TryParse(value.ToString(), out realValue)) return realValue;
            return null;
        }

        public static Int64? GetInt64(object value)
        {
            if (value == null) return null;
            if (value == DBNull.Value) return null;
            if (value is Int64 realValue) return realValue;
            if (Int64.TryParse(value.ToString(), out realValue)) return realValue;
            return null;
        }

        public static UInt64? GetUInt64(object value)
        {
            if (value == null) return null;
            if (value == DBNull.Value) return null;
            if (value is UInt64 realValue) return realValue;
            if (UInt64.TryParse(value.ToString(), out realValue)) return realValue;
            return null;
        }

        public static Single? GetSingle(object value)
        {
            if (value == null) return null;
            if (value == DBNull.Value) return null;
            if (value is Single realValue) return realValue;
            if (Single.TryParse(value.ToString(), out realValue)) return realValue;
            return null;
        }

        public static Double? GetDouble(object value)
        {
            if (value == null) return null;
            if (value == DBNull.Value) return null;
            if (value is Double realValue) return realValue;
            if (Double.TryParse(value.ToString(), out realValue)) return realValue;
            return null;
        }

        public static Decimal? GetDecimal(object value)
        {
            if (value == null) return null;
            if (value == DBNull.Value) return null;
            if (value is Decimal realValue) return realValue;
            if (Decimal.TryParse(value.ToString(), out realValue)) return realValue;
            return null;
        }

        public static DateTime? GetDateTime(object value)
        {
            if (value == null) return null;
            if (value is DateTime realValue) return realValue;
            if (value == DBNull.Value) return null;
            if (DateTime.TryParse(value.ToString(), out realValue)) return realValue;
            return null;
        }

        public static DateTimeOffset? GetDateTimeOffset(object value)
        {
            if (value == null) return null;
            if (value == DBNull.Value) return null;
            if (value is DateTimeOffset realValue) return realValue;
            if (DateTimeOffset.TryParse(value.ToString(), out realValue)) return realValue;
            return null;
        }

        public static TimeSpan? GetTimeSpan(object value)
        {
            if (value == null) return null;
            if (value == DBNull.Value) return null;
            if (value is TimeSpan realValue) return realValue;
            if (TimeSpan.TryParse(value.ToString(), out realValue)) return realValue;
            return null;
        }

        public static Guid? GetGuid(object value)
        {
            if (value == null) return null;
            if (value == DBNull.Value) return null;
            if (value is Guid realValue) return realValue;
            if (Guid.TryParse(value.ToString(), out realValue)) return realValue;
            return null;
        }
    }
}
