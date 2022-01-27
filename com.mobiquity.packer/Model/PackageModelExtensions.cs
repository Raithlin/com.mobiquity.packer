using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mobiquity.packer
{
    public static class PackageModelExtensions
    {
        public static void DeterminePackagesToInclude(this PackageModel package)
        {
            var items = package.Items.OrderByDescending(x => x.Cost).ThenBy(x => x.Weight).ToList();

            var currentWeight = 0.0;
            foreach (var item in items)
            {
                if (item.Weight + currentWeight == package.PackageWeight)
                {
                    package.PackagesToSend.Add(item.Index);
                    break;
                }
                else if (item.Weight + currentWeight < package.PackageWeight)
                {
                    package.PackagesToSend.Add(item.Index);
                    currentWeight += item.Weight;
                }
            }
        }
    }
}
