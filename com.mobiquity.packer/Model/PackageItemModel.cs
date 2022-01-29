namespace com.mobiquity.packer
{
    public class PackageItemModel
    {
        public int Index { get; }
        public double Weight { get; }
        public double Cost { get; }

        /// <summary>
        /// Instantiates and populates <c>PackageItemModel</c> instance
        /// </summary>
        /// <param name="itemDetails">(<c>Index</c>,<c>Weight</c>, <c>Cost</c>) E.g. "(1,15.3,€34)"</param>
        /// <exception cref="APIException"></exception>
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
            {
                throw new APIException($"Invalid weight: {objects[1]}");
            }
            else
            {
                if (weight <= 100)
                    Weight = weight;
                else
                    throw new APIException($"Weight must be <= 100: {weight}");
            }

            if (!double.TryParse(objects[2][1..], out double cost))
            {
                throw new APIException($"Invalid cost: {objects[2]}");
            }
            else
            {
                if (cost <= 100)
                    Cost = cost;
                else
                    throw new APIException($"Cost must be <= 100: {weight}");
            }
        }
    }
}