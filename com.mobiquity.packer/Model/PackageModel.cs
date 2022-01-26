namespace com.mobiquity.packer
{
    public class PackageModel
    {
        public int PackageWeight { get; set; }
        public List<PackageItemModel> Items { get; }

        public PackageModel(string input)
        {
            if (input == null) throw new APIException("Input not supplied");
            
            Items = new List<PackageItemModel>();
            
            var weightInput = input.Split(':')[0].Trim();
            if (!int.TryParse(weightInput, out int packageWeight)) 
                throw new APIException($"Invalid package weight: {weightInput}");

            PackageWeight = packageWeight;
            var line = input.Split(':')[1].Trim();
            foreach (var item in line.Split(" (", StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries))
            {
                Items.Add(new PackageItemModel(item));
            }
        }
    }
}
