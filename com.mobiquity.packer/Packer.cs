using System.IO;
namespace com.mobiquity.packer
{
    public static class Packer
    {
        public static string Pack(string filePath)
        {
            List<string> lines = ReadFromFile(filePath);

            var packages = ExtractPackagesFromFileData(lines);

            Parallel.For(0, packages.Count, x =>
             {
                 packages[x].DeterminePackagesToInclude();
             });

            List<string> output = new List<string>();
            foreach (var package in packages)
            {
                if (package.PackagesToSend.Count > 0)
                    output.Add(string.Join(',', () => package.PackagesToSend));
                else
                    output.Add("-");
            }

            return string.Join('\n', output);
        }

        private static List<string> ReadFromFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) throw new APIException("filePath may not be empty");
            if (!File.Exists(filePath)) throw new APIException($"File does not exist at filePath: {filePath}");

            List<string> lines = new List<string>();
            try
            {
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    if (fs.Length == 0) throw new APIException($"File is empty: {filePath}");
                    using (var file = new StreamReader(fs, System.Text.Encoding.UTF8))
                    {
                        string? line;
                        try
                        {
                            while ((line = file.ReadLine()) != null)
                            {
                                lines.Add(line);
                            }
                        } finally { 
                            file.Close(); 
                        }
                    }
                }
            } catch (Exception ex)
            {
                throw new APIException($"Error while reading file: {filePath}", ex);
            }

            return lines;
        }

        private static List<PackageModel> ExtractPackagesFromFileData(List<string> fileData)
        {
            var packages = new List<PackageModel>();
            foreach (var line in fileData)
            {
                packages.Add(new PackageModel(line));
            }
            return packages;
        }
    }
}