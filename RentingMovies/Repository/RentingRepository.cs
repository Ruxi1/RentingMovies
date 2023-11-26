using RentingMovies.Data;
using RentingMovies.Models;
using RentingMovies.Models.DBObjects;

namespace RentingMovies.Repository
{
    public class RentingRepository
    {
        private ApplicationDbContext dbContext;
        public RentingRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }
        public RentingRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<RentingModel> GetAllRentings()
        {
            List<RentingModel> rentingList = new List<RentingModel>();
            foreach(Renting dbRenting in dbContext.Rentings)
            {
                rentingList.Add(MapDbObjectToModel(dbRenting));
            }
            return rentingList;
        }
        public RentingModel GetRentingByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Rentings.FirstOrDefault(x => x.IdRenting == ID));
        }
        public List<RentingModel> GetRentingsByClientID(Guid IDClient)
        {
            List<RentingModel> rentingList = new List<RentingModel>();
            foreach (Renting dbRenting in dbContext.Rentings.Where(x=>x.IdClient== IDClient))
            {
                rentingList.Add(MapDbObjectToModel(dbRenting));
            }
            return rentingList;
        }
        public List<RentingModel> GetRentingsByMovieID(Guid IDMovie)
        {
            List<RentingModel> rentingList = new List<RentingModel>();
            foreach (Renting dbRenting in dbContext.Rentings.Where(x=>x.IdMovie== IDMovie))
            {
                rentingList.Add(MapDbObjectToModel(dbRenting));
            }
            return rentingList;
        }
        public List<RentingModel> GetRentingsWithoutEndDate()
        {
            List<RentingModel> rentingList=new List<RentingModel>();
            foreach(Renting dbRenting in dbContext.Rentings.Where(x=>x.EndDate== null))
            {
                rentingList.Add(MapDbObjectToModel(dbRenting));
            }
            return rentingList;
        }
        public void InsertRenting(RentingModel rentingModel)
        {
            rentingModel.IdRenting=Guid.NewGuid();
            dbContext.Rentings.Add(MapModelToDbObject(rentingModel));
            Movie movie=dbContext.Movies.FirstOrDefault(x=>x.IdMovie==rentingModel.IdMovie);
            movie.AvailableQuantity--;
            dbContext.SaveChanges();
        }
        public void UpdateRenting(RentingModel rentingModel)
        {
            Renting existingRenting = dbContext.Rentings.FirstOrDefault(x => x.IdRenting == rentingModel.IdRenting);
            if(existingRenting != null)
            {
                existingRenting.IdRenting = rentingModel.IdRenting;
                existingRenting.IdMovie = rentingModel.IdMovie; ;
                existingRenting.IdClient= rentingModel.IdClient;
                existingRenting.StartDate= rentingModel.StartDate;
                existingRenting.EndDate= rentingModel.EndDate;
                dbContext.SaveChanges();
            }
            if(existingRenting.EndDate!=null)
            {
                Movie movie=dbContext.Movies.FirstOrDefault(x => x.IdMovie==existingRenting.IdMovie);
                movie.AvailableQuantity++;
                dbContext.SaveChanges();
            }
        }
        public void DeleteRenting(Guid id)
        {
            Renting existingRenting= dbContext.Rentings.FirstOrDefault(x => x.IdRenting == id);
            if( existingRenting != null )
            {
                dbContext.Rentings.Remove(existingRenting);
                dbContext.SaveChanges();
            }
        }
        private Renting MapModelToDbObject(RentingModel rentingModel)
        {
            Renting renting= new Renting();
            if( rentingModel != null )
            {
                renting.IdRenting = rentingModel.IdRenting;
                renting.IdMovie = rentingModel.IdMovie;
                renting.IdClient= rentingModel.IdClient;
                renting.StartDate= rentingModel.StartDate;
                renting.EndDate= rentingModel.EndDate;
            }
            return renting;
        }

        private RentingModel MapDbObjectToModel(Renting dbRenting)
        {
            RentingModel rentingModel=new RentingModel();
            if(dbRenting!=null)
            {
                rentingModel.IdRenting = dbRenting.IdRenting;
                rentingModel.IdMovie= dbRenting.IdMovie;
                rentingModel.IdClient= dbRenting.IdClient;
                rentingModel.StartDate= dbRenting.StartDate;
                rentingModel.EndDate= dbRenting.EndDate;
            }
            return rentingModel;
        }
    }
}
