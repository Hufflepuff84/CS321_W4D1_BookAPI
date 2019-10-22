using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W4D1_BookAPI.Models;

namespace CS321_W4D1_BookAPI.Services
{
    public interface IPublisherService
    {
        IEnumerable<Publisher> GetAll();
        Publisher Get(int id);
        Publisher Add(Publisher newPublisher);
        Publisher Update(Publisher updatedPublisher);
        void Remove(Publisher publisher);
    }
}
