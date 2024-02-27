using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject;

namespace TheCoffeeCatService.IServices
{
    public interface ITableServices
    {
        List<Table> GetAllTable();
        void AddNewTable(Table table);
        Table GetTableByID(Guid id);
        void UpdateTable(Table table);
    }
}
