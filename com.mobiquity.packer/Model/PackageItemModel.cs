namespace com.mobiquity.packer
{
    public class PackageItemModel
    {
        public int Index { get; set; }
        public double Weight { get; set; }
        public double Cost { get; set; }

        public PackageItemModel(string itemDetails)
        {
            if (itemDetails == null) throw new APIException("No details provided for package item");
            itemDetails = itemDetails.Trim('(', ')');
            var objects = itemDetails.Split(',');
            if (objects.Length != 3) throw new APIException($"Invalid item format: {itemDetails}");

            _ = int.TryParse(objects[0], out int index);
            if (index == 0) throw new APIException($"Invalid index: {objects[0]}");            
            Index = index;

            _ = double.TryParse(objects[1], out double weight);
            if (weight == 0.0) throw new APIException($"Invalid weight: {objects[1]}");
            Weight = weight;

            _ = double.TryParse(objects[2].Substring(1, objects[2].Length-1), out double cost);
            if (cost == 0.0) throw new APIException($"Invalid cost: {objects[2]}");
            Cost = cost;
        }
    }
}