using System.Collections.Generic;
using SSDModel;

namespace SSDDL
{
    public interface IInventoryDL
    {
        List<Inventories> GetAllInventories();
    }
}