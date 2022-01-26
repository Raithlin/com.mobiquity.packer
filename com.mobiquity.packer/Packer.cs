namespace com.mobiquity.packer
{
    public static class Packer
    {
        public static string Pack(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) throw new APIException("filePath may not be empty");
            return string.Empty;
        }

    }
}