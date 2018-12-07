using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class AES
{
    private const string password = "testjumpy";
    private const string rgbIV = "testjvUy/ye7Cd7k89QQgQ==";
    private const string rgbSalt = "testjvkyhye5/d7k8OrLgM==";
    private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
    private static byte[] IVs = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

    private static RijndaelManaged m_AESProvider = new RijndaelManaged();
    private static bool bSetRijndael = false;

    private static void CreateRijndael()
    {
        if (bSetRijndael == false)
        {
            bSetRijndael = true;

            //Something wrong whit key size
            //m_AESProvider.Key =Keys;
            //m_AESProvider.IV = IVs;

            m_AESProvider.Mode = CipherMode.ECB;
            m_AESProvider.Padding = PaddingMode.PKCS7;
        }
    }

    public static byte[] AESEncrypt(string EncryptString)
    {
        byte[] EncryptByte = Encoding.UTF8.GetBytes(EncryptString);
        //byte[] EncryptByte = Convert.FromBase64String(EncryptString);
        byte[] m_strEncrypt;

        if (EncryptByte.Length == 0)
        {
            return null;
        }

        CreateRijndael();

        using (MemoryStream m_stream = new MemoryStream())
        {
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, Convert.FromBase64String(rgbSalt));
            ICryptoTransform transform = m_AESProvider.CreateEncryptor(pdb.GetBytes(32), Convert.FromBase64String(rgbIV));

            using (CryptoStream m_csstream = new CryptoStream(m_stream, transform, CryptoStreamMode.Write))
            {
                m_csstream.Write(EncryptByte, 0, EncryptByte.Length);
                m_csstream.FlushFinalBlock();
                m_strEncrypt = m_stream.ToArray();

                m_csstream.Close();
                m_csstream.Dispose();
            }
            m_stream.Close();
            m_stream.Dispose();
        }

        return m_strEncrypt;

    }

    public static string AESDecrypt(byte[] DecryptByte)
    {

        string pToEncrypt = Convert.ToBase64String(DecryptByte);
        byte[] m_DecryptByte = Convert.FromBase64String(pToEncrypt);
        byte[] m_strDecrypt = null;

        if (m_DecryptByte.Length == 0)
        {
            return null;
        }

        CreateRijndael();

        using (MemoryStream m_stream = new MemoryStream())
        {
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, Convert.FromBase64String(rgbSalt));
            ICryptoTransform transform = m_AESProvider.CreateDecryptor(pdb.GetBytes(32), Convert.FromBase64String(rgbIV));

            // another method decrypt
            //return Convert.ToBase64String( transform.TransformFinalBlock(m_DecryptByte, 0, m_DecryptByte.Length));
            //return Encoding.UTF8.GetString(transform.TransformFinalBlock(m_DecryptByte, 0, m_DecryptByte.Length));

            using (CryptoStream m_csstream = new CryptoStream(m_stream, transform, CryptoStreamMode.Write))
            {
                m_csstream.Write(DecryptByte, 0, DecryptByte.Length);
                m_csstream.FlushFinalBlock();
                m_strDecrypt = m_stream.ToArray();
                m_csstream.Close();
                m_csstream.Dispose();
            }
            m_stream.Close();
            m_stream.Dispose();
        }

        //return Convert.ToBase64String(m_strDecrypt);
        return Encoding.UTF8.GetString(m_strDecrypt);
    }

}