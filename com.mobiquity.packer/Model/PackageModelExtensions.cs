using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mobiquity.packer
{
    public static class PackageModelExtensions
    {
        /// <summary>
        /// Determines the best mix of items to include in the package
        /// Items are selected based on Cost (desc) and Weight (asc)
        /// </summary>
        /// <param name="package">The package</param>
        public static void DetermineItemsToInclude(this PackageModel package)
        {
            var items = package.Items.OrderByDescending(x => x.Cost).ThenBy(x => x.Weight).ToList();

            var currentWeight = 0.0;
            foreach (var item in items)
            {
                if (item.Weight + currentWeight == package.PackageWeight)
                {
                    package.ItemsToSend.Add(item.Index);
                    break;
                }
                else if (item.Weight + currentWeight < package.PackageWeight)
                {
                    package.ItemsToSend.Add(item.Index);
                    currentWeight += item.Weight;
                }
            }
        }
    }
}
