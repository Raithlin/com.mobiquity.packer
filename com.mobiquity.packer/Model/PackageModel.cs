namespace com.mobiquity.packer
{
    public class PackageModel
    {
        public int PackageWeight { get; set; }
        public List<PackageItemModel> Items { get; }
        public List<int> PackagesToSend { get; set; }

        public PackageModel(string input)
        {
            if (input == null) throw new APIException("Input not supplied");
            
            /* Initialize lists */
            Items = new List<PackageItemModel>();
            PackagesToSend = new List<int>();

            string[] splitInput = input.Split(':');
            var weightInput = splitInput[0].Trim();
            if (!int.TryParse(weightInput, out int packageWeight)) 
                throw new APIException($"Invalid package weight: {weightInput}");

            PackageWeight = packageWeight;
            var line = splitInput[1].Trim();
            foreach (var item in line.Split(" (", StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries))
            {
                Items.Add(new PackageItemModel(item));
            }
        }
    }
}
