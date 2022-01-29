namespace com.mobiquity.packer
{
    public class PackageModel
    {
        public int PackageWeight { get; }
        public List<PackageItemModel> Items { get; }
        public List<int> ItemsToSend { get; }

        /// <summary>
        /// Instantiates and populates <c>PackageModel</c> instance
        /// </summary>
        /// <param name="input"><c>PackageWeight</c> : (<c>Index</c>,<c>Weight</c>, <c>Cost</c>) 
        /// E.g. "8 : (1,15.3,€34)[ (2,14.8,€52)]"</param>
        /// <exception cref="APIException"></exception>
        public PackageModel(string input)
        {
            if (input == null) throw new APIException("Input not supplied");
            
            /* Initialize lists */
            Items = new List<PackageItemModel>();
            ItemsToSend = new List<int>();

            string[] splitInput = input.Split(':');
            var weightInput = splitInput[0].Trim();
            if (!int.TryParse(weightInput, out int packageWeight)) 
                throw new APIException($"Invalid package weight: {weightInput}");

            if (packageWeight > 100)
                throw new APIException($"Package weight must be <= 100: {packageWeight}");

            PackageWeight = packageWeight;
            var line = splitInput[1].Trim();
            if (line.Count(x => x == '(') > 15)
                throw new APIException($"No more than 15 items allowed per package");

            foreach (var item in line.Split(" (", StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries))
            {
                Items.Add(new PackageItemModel(item));
            }
        }
    }
}
