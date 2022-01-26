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

             if (!int.TryParse(objects[0], out int index))
                throw new APIException($"Invalid index: {objects[0]}");
             else
                Index = index;

            if (!double.TryParse(objects[1], out double weight))
                throw new APIException($"Invalid weight: {objects[1]}");
            else
                Weight = weight;

            if (!double.TryParse(objects[2][1..], out double cost))
                throw new APIException($"Invalid cost: {objects[2]}");
            else
                Cost = cost;
        }
    }
}