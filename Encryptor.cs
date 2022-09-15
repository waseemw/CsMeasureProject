using System.Security.Cryptography;
using System.Text;

public class Encryptor
{
    private readonly string _key;

    public Encryptor(string key)
    {
        _key = key;
    }

    public string Encrypt(string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);
        var aes = Aes.Create();
        var iv = RandomNumberGenerator.GetBytes(16);
        var encryptor = aes.CreateEncryptor(Encoding.UTF8.GetBytes(_key), iv);
        var result = iv.Concat(encryptor.TransformFinalBlock(bytes, 0, bytes.Length));
        return Convert.ToHexString(result.ToArray());
    }

    public string Decrypt(string value)
    {
        var aes = Aes.Create();
        var decodeBytes = Convert.FromHexString(value);
        var decryptor = aes.CreateDecryptor(Encoding.UTF8.GetBytes(_key), decodeBytes[..16]);
        var encryptedBytes = decodeBytes[16..];
        var decryptedResult = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
        return Encoding.UTF8.GetString(decryptedResult);
    }
}