﻿using Model.Version1;

namespace DAL.Repository.CosmosDB
{
    public class ClientRepository : IRepository<Client>
    {
        public void Add(Client entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Client> FindAll(Predicate<Client> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Client> GetAll()
        {
            throw new NotImplementedException();
        }

        public Client GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Client newentity)
        {
            throw new NotImplementedException();
        }
    }
}
