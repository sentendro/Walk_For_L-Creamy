using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class SaveLoad
{

    #region serialize
    public static string ObjectToString(Object obj)
    {
        using (var memoryStream = new MemoryStream())
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(memoryStream, obj);
            memoryStream.Flush();
            memoryStream.Position = 0;

            return Convert.ToBase64String(memoryStream.ToArray());
        }
    }
    #endregion

    #region Deserialize
    public static T Deserialize<T>(string xmlText)
    {
        if (xmlText != null && xmlText != String.Empty)
        {
            byte[] b = Convert.FromBase64String(xmlText);
            using (var stream = new MemoryStream(b))
            {
                var formatter = new BinaryFormatter();
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
        else
        {
            return default(T);
        }
    }
    #endregion
}
