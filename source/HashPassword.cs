using System; 
using System.Text; 
using System.Security.Cryptography;

public class HashPassword
{
    public static string getHash(string input)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(input);
        
        SHA256Managed hashstring = new SHA256Managed();
        byte[] hash = hashstring.ComputeHash(bytes);
        string hashString = string.Empty;
        
        foreach (byte x in hash)
        {
            hashString += String.Format("{0:x2}", x);
        }
        
        return hashString;
    }
}