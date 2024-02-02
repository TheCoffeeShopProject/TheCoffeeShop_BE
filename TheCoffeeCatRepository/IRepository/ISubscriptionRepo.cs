using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject;

namespace TheCoffeeCatRepository.IRepository
{
    public interface ISubscriptionRepo
    {
        public List<Subscription> GetSubscriptions();
        public Subscription GetSubscriptionById(Guid id);
        public void AddSubscription(Subscription subscription);
        public void UpdateSubscription(Subscription subscription);
        public bool ChangeStatus(Subscription subscription);
        public IQueryable<Subscription> SearchSubscriptionByname(string name);
    }
}
