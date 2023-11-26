using RentingMovies.Data;
using RentingMovies.Models;
using RentingMovies.Models.DBObjects;

namespace RentingMovies.Repository
{
    public class ClientRepository
    {
        private ApplicationDbContext dbContext;
        public ClientRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }
        public ClientRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<ClientModel> GetAllClients()
        {
            List<ClientModel> clientList = new List<ClientModel>();
            foreach(Client dbclient in dbContext.Clients)
            {
                clientList.Add(MapDbObjectToModel(dbclient));
            }
            return clientList;
        }
        public ClientModel GetClientByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Clients.FirstOrDefault(x => x.IdClient == ID));
        }
        public ClientModel GetClientByEmail(string Email)
        {
            return MapDbObjectToModel(dbContext.Clients.FirstOrDefault(x => x.Email == Email));
        }
        public void InsertClient(ClientModel clientModel)
        {
            clientModel.IdClient=Guid.NewGuid();
            dbContext.Clients.Add(MapModelToDbObject(clientModel));
            dbContext.SaveChanges();
        }
        public void UpdateClient(ClientModel clientModel)
        {
            Client existingClient=dbContext.Clients.FirstOrDefault(x => x.IdClient==clientModel.IdClient);
            if(existingClient!=null)
            {
                existingClient.IdClient = clientModel.IdClient;
                existingClient.Name = clientModel.Name;
                existingClient.Email = clientModel.Email;
                existingClient.Phone=clientModel.Phone;
                dbContext.SaveChanges();
            }
        }
        public void DeleteCient(Guid id)
        {
            Client existingClient=dbContext.Clients.FirstOrDefault(x => x.IdClient == id);
            if( existingClient!=null )
            {
                dbContext.Clients.Remove(existingClient);
                dbContext.SaveChanges();
            }
        }

        private Client MapModelToDbObject(ClientModel clientModel)
        {
            Client client = new Client();
            if(clientModel!=null)
            {
                client.IdClient = clientModel.IdClient;
                client.Name = clientModel.Name;
                client.Email = clientModel.Email;
                client.Phone = clientModel.Phone;
            }
            return client;
        }

        private ClientModel MapDbObjectToModel(Client dbclient)
        {
            ClientModel clientModel = new ClientModel();
            if(dbclient!=null)
            {
                clientModel.IdClient = dbclient.IdClient;
                clientModel.Name = dbclient.Name;
                clientModel.Email = dbclient.Email;
                clientModel.Phone = dbclient.Phone;
            }
            return clientModel;
        }
    }
}
