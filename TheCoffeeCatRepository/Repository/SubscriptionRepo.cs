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
    public class SubscriptionRepo : ISubscriptionRepo
    {
        private SubscriptionDAO _subscriptionDAO;
        public SubscriptionRepo()
        {
            _subscriptionDAO = new SubscriptionDAO();
        }

        public void AddSubscription(Subscription subscription)
        {
            _subscriptionDAO.AddSubscription(subscription);
        }

        public bool ChangeStatus(Subscription subscription)
        {
          return _subscriptionDAO.ChangeStatus(subscription);
        }

        public Subscription GetSubscriptionById(Guid id)
        {
            return _subscriptionDAO.GetSubscriptionById(id);
        }

        public List<Subscription> GetSubscriptions()
        {
            return _subscriptionDAO.GetSubscriptions();
        }

        public IQueryable<Subscription> SearchSubscriptionByname(string name)
        {
            return _subscriptionDAO.SearchSubscriptionByName(name);
        }

        public void UpdateSubscription(Subscription subscription)
        {
           _subscriptionDAO.UpdateSubscription(subscription);
        }
    }
}
