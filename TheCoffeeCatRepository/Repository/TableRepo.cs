using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatDAO.DAOs;
using TheCoffeeCatRepository.IRepository;

namespace TheCoffeeCatRepository.Repository
{
    public class TableRepo : ITableRepo
    {
        TableDAO dao = new TableDAO();
        public void AddNewTable(Table table) => dao.AddNewTable(table);

        public List<Table> GetAllTable() => dao.GetAllTable();

        public Table GetTableByID(Guid id) => dao.GetTableByID(id);

        public void UpdateTable(Table table) => dao.UpdateTable(table);

    }
}
