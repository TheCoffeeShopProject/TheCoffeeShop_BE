using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatBusinessObject.BusinessObject;

namespace TheCoffeeCatDAO.DAOs
{
    public class SubscriptionDAO
    {
        public static SubscriptionDAO instance;
        public static SubscriptionDAO Instance
        {
            get
            {if (instance == null)
                {
                    instance = new SubscriptionDAO();
                }
            return instance;

            }
        }
        public List<Subscription> GetSubscriptions()
        {
            var _context = new TheCoffeeStoreDBContext();
            return _context.Subscriptions.ToList();
        }
        public Subscription GetSubscriptionById(Guid id)
        {
            var _context = new TheCoffeeStoreDBContext();
            return _context.Subscriptions.SingleOrDefault(s => s.SubscriptionID == id);
        }
        public bool AddSubscription(Subscription subscription)
        {

            var _context = new TheCoffeeStoreDBContext();
            var a = _context.Subscriptions.SingleOrDefault(d => d.SubscriptionID == subscription.SubscriptionID);
            if (a != null)
            {
                return false;
            }
            else
            {
                _context.Subscriptions.Add(subscription);
                _context.SaveChanges();
                return true;
            }

        }
        public bool UpdateSubscription(Subscription subscription)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.Subscriptions.SingleOrDefault(d => d.SubscriptionID == subscription.SubscriptionID);
            if (a == null)
            {
                return false;
            }
            else
            {
                _context.Entry(a).CurrentValues.SetValues(subscription);
                _context.SaveChanges();
                return true;
            }
        }
        public IQueryable<Subscription> SearchSubscriptionByName(string search)
        {
            var _context = new TheCoffeeStoreDBContext();
            return _context.Subscriptions.Where(a => a.Name.ToUpper().Contains(search.Trim().ToUpper()));
       }
        public bool ChangeStatus(Subscription subscription)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.Subscriptions.FirstOrDefault(d => d.SubscriptionID == subscription.SubscriptionID);
            if (a == null)
            {
                return false;
            }
            else
            {
                a.Status = false;
                _context.Entry(a).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }

        }

    }
}
