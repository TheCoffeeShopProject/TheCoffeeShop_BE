using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatRepository.IRepository;
using TheCoffeeCatService.IServices;

namespace TheCoffeeCatService.Services
{
    public class TableServices : ITableServices
    {
        private readonly ITableRepo _tableRepo;
        public TableServices(ITableRepo tableRepo)
        {
            _tableRepo = tableRepo;
        }
        public void AddNewTable(Table table) => _tableRepo.AddNewTable(table);

        public List<Table> GetAllTable() => _tableRepo.GetAllTable();

        public Table GetTableByID(Guid id) => _tableRepo.GetTableByID(id);

        public void UpdateTable(Table table) => _tableRepo.UpdateTable(table);

    }
}
