using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatBusinessObject.BusinessObject;

namespace TheCoffeeCatDAO.DAOs
{
    public class TableDAO
    {
        private readonly TheCoffeeStoreDBContext _context;
        public TableDAO()
        {
            _context = new TheCoffeeStoreDBContext();
        }

        public List<Table> GetAllTable()
        {
            try
            {
                return _context.Tables.Include(a => a.CoffeeShop)
                                      .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddNewTable(Table table)
        {
            try
            {
                _context.Add(table);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Table GetTableByID(Guid id)
        {
            try
            {
                var table = _context.Tables.Include(a => a.CoffeeShop)
                                           .SingleOrDefault(c => c.TableID == id);
                return table;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateTable(Table table)
        {
            try
            {
                var existingTable = _context.Tables.FirstOrDefault(t => t.TableID == table.TableID);
                if (existingTable != null)
                {
                    existingTable.Status = table.Status;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




    }
}
