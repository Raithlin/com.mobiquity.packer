using System.IO;
namespace com.mobiquity.packer
{
    public static class Packer
    {
        public static string Pack(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) throw new APIException("filePath may not be empty");
            if (!File.Exists(filePath)) throw new APIException($"File does not exist at filePath: {filePath}");

            using (FileStream fs = File.OpenRead(filePath))
            {
                if (fs.Length == 0) throw new APIException($"File is empty: {filePath}");
            }

            return string.Empty;
        }

    }
}