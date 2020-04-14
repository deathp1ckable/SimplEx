using System;
using System.Text;

namespace SimplExServer.Model
{
    static class Encryptor
    {
        public static byte[] Encrypt(byte[] data, string key)
        {
            byte bKey = (byte)key.GetHashCode();
            byte[] keyBuff = Encoding.Unicode.GetBytes(key);
            byte[] result = new byte[data.Length + keyBuff.Length + 1];
            data.CopyTo(result, 0);
            keyBuff.CopyTo(result, data.Length);
            result[result.Length - 1] = (byte)new Random().Next(byte.MinValue, byte.MaxValue);
            for (int i = 0; i < result.Length - 1; i++)
            {
                result[i] ^= (byte)(bKey * result[result.Length - 1] * (result.Length - i));
                result[i] += result[result.Length - 1];
            }
            return result;
        }
        public static byte[] Decrypt(byte[] data, string key)
        {
            int i;
            byte bKey = (byte)key.GetHashCode();
            byte lKey = data[data.Length - 1];
            byte[] keyBuff = new byte[Encoding.Unicode.GetBytes(key).Length];
            byte[] tmp = new byte[data.Length - 1];
            for (i = 0; i < tmp.Length; i++)
                tmp[i] = data[i];
            for (i = 0; i < tmp.Length; i++)
            {
                tmp[i] -= lKey;
                tmp[i] ^= (byte)(bKey * lKey * (tmp.Length - i + 1));
            }
            for (i = tmp.Length - keyBuff.Length; i < tmp.Length; i++)
                keyBuff[i - (tmp.Length - keyBuff.Length)] = tmp[i];
            string tKey = Encoding.Unicode.GetString(keyBuff);
            byte[] result = new byte[tmp.Length - keyBuff.Length];
            if (tKey == key)
                for (i = 0; i < result.Length; i++)
                    result[i] = tmp[i];
            else
                for (i = 0; i < result.Length; i++)
                    result[i] = (byte)(data[i] - bKey - lKey * bKey);
            return result;
        }
    }
}
