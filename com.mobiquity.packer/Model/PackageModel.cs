using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            foreach (var line in input.Split('\n'))
            {
                if (!line.Contains(':')) throw new APIException($"Invalid format: {line}");
                Items.Add(new PackageItemModel(line.Split(':')[1].Trim()));
            }
        }
    }
}
