using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QaProjectReader.Helpers
{
    internal static class ByteSpanExtensions
    {
        public static short ToInt16(this ReadOnlySpan<byte> data, ref int pos)
        {
            pos += 2;
            return BitConverter.ToInt16(data.Slice(pos-2, 2));
        }

        public static int ToInt32(this ReadOnlySpan<byte> data, ref int pos)
        {
            pos += 4;
            return BitConverter.ToInt32(data.Slice(pos - 4, 4));
        }

        public static long ToInt64(this ReadOnlySpan<byte> data, ref int pos)
        {
            pos += 8;
            return BitConverter.ToInt64(data.Slice(pos - 8, 8));
        }

        public static float ToSingle(this ReadOnlySpan<byte> data, ref int pos)
        {
            pos += 4;
            return BitConverter.ToSingle(data.Slice(pos - 4, 4));
        }

        public static bool ToBoolean(this ReadOnlySpan<byte> data, ref int pos)
        {
            pos++;
            return BitConverter.ToBoolean(data.Slice(pos - 1, 1));
        }

        public static float[] ToSingleArray(this ReadOnlySpan<byte> data, int len, ref int pos)
        {
            var res = new float[len];
            for (var i = 0; i < len; i++)
                res[i] = data.ToSingle(ref pos);
            return res;
        }

        public static int[]? ToInt32Array(this ReadOnlySpan<byte> data, ref int pos)
        {
            var count = data.ToInt32(ref pos);
            if (count < 0)
                return null;
            var arr = new int[count];
            for (var i = 0; i < count; i++)
            {
                arr[i] = data.ToInt32(ref pos);
            }
            return arr;
        }

        public static bool[]? ToBooleanArray(this ReadOnlySpan<byte> data, ref int pos)
        {
            var count = data.ToInt32(ref pos);
            if (count < 0)
                return null;
            var arr = new bool[count];
            for (var i = 0; i < count; i++)
            {
                arr[i] = data.ToBoolean(ref pos);
            }
            return arr;
        }

        public static string ToAscii(this ReadOnlySpan<byte> data, int len, ref int pos)
        {
            pos += len;
            return Encoding.ASCII.GetString(data.Slice(pos - len, len));
        }

        public static string? GetString(this ReadOnlySpan<byte> data, ref int pos)
        {
            var len = data.ToInt16(ref pos);
            if (len < 0)
                return null;
            pos += len;
            return Encoding.UTF8.GetString(data.Slice(pos-len, len));
        }

    }
}
