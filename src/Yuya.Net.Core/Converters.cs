using System;

namespace Yuya.Net.Core
{
    /// <summary>
    /// Bu sınıf temel MS.Net tiplerine olan tip dönüşümleri için kullanacağımız statik sınıftır.
    /// </summary>
    public static class Converters
    {
        /// <summary>
        /// Gets the Boolean(bool) value.
        /// </summary>
        /// <param name="sourceValue">The source value.</param>
        /// <returns>The target value.</returns>
        public static Boolean? GetBoolean(object sourceValue)
        {
            if (sourceValue == null) return null;
            if (sourceValue == DBNull.Value) return null;
            if (sourceValue is Boolean realValue) return realValue;
            if (Boolean.TryParse(sourceValue.ToString(), out realValue)) return realValue;
            return null;
        }

        /// <summary>
        /// Gets the Byte(byte) value.
        /// </summary>
        /// <param name="sourceValue">The source value.</param>
        /// <returns>The target value.</returns>
        public static Byte? GetByte(object sourceValue)
        {
            if (sourceValue == null) return null;
            if (sourceValue == DBNull.Value) return null;
            if (sourceValue is Byte realValue) return realValue;
            if (Byte.TryParse(sourceValue.ToString(), out realValue)) return realValue;
            return null;
        }

        /// <summary>
        /// Gets the SByte(sbyte) value.
        /// </summary>
        /// <param name="sourceValue">The source value.</param>
        /// <returns>The target value.</returns>
        public static SByte? GetSByte(object sourceValue)
        {
            if (sourceValue == null) return null;
            if (sourceValue == DBNull.Value) return null;
            if (sourceValue is SByte realValue) return realValue;
            if (SByte.TryParse(sourceValue.ToString(), out realValue)) return realValue;
            return null;
        }

        /// <summary>
        /// Gets the Int16(short) value.
        /// </summary>
        /// <param name="sourceValue">The source value.</param>
        /// <returns>The target value.</returns>
        public static Int16? GetInt16(object sourceValue)
        {
            if (sourceValue == null) return null;
            if (sourceValue == DBNull.Value) return null;
            if (sourceValue is Int16 realValue) return realValue;
            if (Int16.TryParse(sourceValue.ToString(), out realValue)) return realValue;
            return null;
        }

        /// <summary>
        /// Gets the UInt16(ushort) value.
        /// </summary>
        /// <param name="sourceValue">The source value.</param>
        /// <returns>The target value.</returns>
        public static UInt16? GetUInt16(object sourceValue)
        {
            if (sourceValue == null) return null;
            if (sourceValue == DBNull.Value) return null;
            if (sourceValue is UInt16 realValue) return realValue;
            if (UInt16.TryParse(sourceValue.ToString(), out realValue)) return realValue;
            return null;
        }

        /// <summary>
        /// Gets the Int32(int) value.
        /// </summary>
        /// <param name="sourceValue">The source value.</param>
        /// <returns>The target value.</returns>
        public static Int32? GetInt32(object sourceValue)
        {
            if (sourceValue == null) return null;
            if (sourceValue == DBNull.Value) return null;
            if (sourceValue is Int32 realValue) return realValue;
            if (Int32.TryParse(sourceValue.ToString(), out realValue)) return realValue;
            return null;
        }

        /// <summary>
        /// Gets the UInt32(uint) value.
        /// </summary>
        /// <param name="sourceValue">The source value.</param>
        /// <returns>The target value.</returns>
        public static UInt32? GetUInt32(object sourceValue)
        {
            if (sourceValue == null) return null;
            if (sourceValue == DBNull.Value) return null;
            if (sourceValue is UInt32 realValue) return realValue;
            if (UInt32.TryParse(sourceValue.ToString(), out realValue)) return realValue;
            return null;
        }

        /// <summary>
        /// Gets the Int64(long) value.
        /// </summary>
        /// <param name="sourceValue">The source value.</param>
        /// <returns>The target value.</returns>
        public static Int64? GetInt64(object sourceValue)
        {
            if (sourceValue == null) return null;
            if (sourceValue == DBNull.Value) return null;
            if (sourceValue is Int64 realValue) return realValue;
            if (Int64.TryParse(sourceValue.ToString(), out realValue)) return realValue;
            return null;
        }

        /// <summary>
        /// Gets the UInt64(ulong) value.
        /// </summary>
        /// <param name="sourceValue">The source value.</param>
        /// <returns>The target value.</returns>
        public static UInt64? GetUInt64(object sourceValue)
        {
            if (sourceValue == null) return null;
            if (sourceValue == DBNull.Value) return null;
            if (sourceValue is UInt64 realValue) return realValue;
            if (UInt64.TryParse(sourceValue.ToString(), out realValue)) return realValue;
            return null;
        }

        /// <summary>
        /// Gets the Single(float) value.
        /// </summary>
        /// <param name="sourceValue">The source value.</param>
        /// <returns>The target value.</returns>
        public static Single? GetSingle(object sourceValue)
        {
            if (sourceValue == null) return null;
            if (sourceValue == DBNull.Value) return null;
            if (sourceValue is Single realValue) return realValue;
            if (Single.TryParse(sourceValue.ToString(), out realValue)) return realValue;
            return null;
        }

        /// <summary>
        /// Gets the Double(double) value.
        /// </summary>
        /// <param name="sourceValue">The source value.</param>
        /// <returns>The target value.</returns>
        public static Double? GetDouble(object sourceValue)
        {
            if (sourceValue == null) return null;
            if (sourceValue == DBNull.Value) return null;
            if (sourceValue is Double realValue) return realValue;
            if (Double.TryParse(sourceValue.ToString(), out realValue)) return realValue;
            return null;
        }

        /// <summary>
        /// Gets the Decimal(decimal) value.
        /// </summary>
        /// <param name="sourceValue">The source value.</param>
        /// <returns>The target value.</returns>
        public static Decimal? GetDecimal(object sourceValue)
        {
            if (sourceValue == null) return null;
            if (sourceValue == DBNull.Value) return null;
            if (sourceValue is Decimal realValue) return realValue;
            if (Decimal.TryParse(sourceValue.ToString(), out realValue)) return realValue;
            return null;
        }

        /// <summary>
        /// Gets the DateTime value.
        /// </summary>
        /// <param name="sourceValue">The source value.</param>
        /// <returns>The target value.</returns>
        public static DateTime? GetDateTime(object sourceValue)
        {
            if (sourceValue == null) return null;
            if (sourceValue is DateTime realValue) return realValue;
            if (sourceValue == DBNull.Value) return null;
            if (DateTime.TryParse(sourceValue.ToString(), out realValue)) return realValue;
            return null;
        }

        /// <summary>
        /// Gets the DateTimeOffset value.
        /// </summary>
        /// <param name="sourceValue">The source value.</param>
        /// <returns>The target value.</returns>
        public static DateTimeOffset? GetDateTimeOffset(object sourceValue)
        {
            if (sourceValue == null) return null;
            if (sourceValue == DBNull.Value) return null;
            if (sourceValue is DateTimeOffset realValue) return realValue;
            if (DateTimeOffset.TryParse(sourceValue.ToString(), out realValue)) return realValue;
            return null;
        }

        /// <summary>
        /// Gets the TimeSpan value.
        /// </summary>
        /// <param name="sourceValue">The source value.</param>
        /// <returns>The target value.</returns>
        public static TimeSpan? GetTimeSpan(object sourceValue)
        {
            if (sourceValue == null) return null;
            if (sourceValue == DBNull.Value) return null;
            if (sourceValue is TimeSpan realValue) return realValue;
            if (TimeSpan.TryParse(sourceValue.ToString(), out realValue)) return realValue;
            return null;
        }

        /// <summary>
        /// Gets the GUID value.
        /// </summary>
        /// <param name="sourceValue">The source value.</param>
        /// <returns>The target value.</returns>
        public static Guid? GetGuid(object sourceValue)
        {
            if (sourceValue == null) return null;
            if (sourceValue == DBNull.Value) return null;
            if (sourceValue is Guid realValue) return realValue;
            if (Guid.TryParse(sourceValue.ToString(), out realValue)) return realValue;
            return null;
        }

        /// <summary>
        /// Gets the String(string) value.
        /// </summary>
        /// <param name="sourceValue">The source value.</param>
        /// <returns>The target value.</returns>
        public static string GetString(object sourceValue)
        {
            if (sourceValue == null) return null;
            if (sourceValue == DBNull.Value) return null;
            if (sourceValue is string realValue) return realValue;
            return sourceValue.ToString();
        }
    }
}
