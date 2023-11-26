using RentingMovies.Data;
using RentingMovies.Models;
using RentingMovies.Models.DBObjects;

namespace RentingMovies.Repository
{
    public class MovieRepository
    {
        private ApplicationDbContext dbContext;
        public MovieRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }
        public MovieRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<MovieModel> GetAllMovies()
        {
            List<MovieModel> movieList = new List<MovieModel>();
            foreach(Movie dbMovie in dbContext.Movies)
            {
                movieList.Add(MapDbObjectToModel(dbMovie));
            }
            return movieList;
        }
        public MovieModel GetMovieByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Movies.FirstOrDefault(x => x.IdMovie == ID));
        }
        public MovieModel GetMovieByName(string name)
        {
            return MapDbObjectToModel(dbContext.Movies.FirstOrDefault(x => x.Name == name));
        }
        public List<MovieModel> GetAllAvailableMovies()
        {
            List<MovieModel> movieList = new List<MovieModel>();
            foreach (Movie dbMovie in dbContext.Movies.Where(x=>x.AvailableQuantity>0))
            {
                movieList.Add(MapDbObjectToModel(dbMovie));
            }
            return movieList;
        }
        public void InsertMovie(MovieModel movieModel)
        {
            movieModel.IdMovie=Guid.NewGuid();
            dbContext.Movies.Add(MapModelToDbObject(movieModel));
            dbContext.SaveChanges();
        }
        public void UpdateMovie(MovieModel movieModel)
        {
            Movie existingMovie=dbContext.Movies.FirstOrDefault(x=>x.IdMovie==movieModel.IdMovie);
            if(existingMovie!=null)
            {
                existingMovie.IdMovie=movieModel.IdMovie;
                existingMovie.Name=movieModel.Name;
                existingMovie.Quantity=movieModel.Quantity;
                existingMovie.AvailableQuantity=movieModel.AvailableQuantity;
                existingMovie.Price=movieModel.Price;
                existingMovie.Date=movieModel.Date;
                dbContext.SaveChanges();
            }
        }
        public void DeleteMovie(Guid id)
        {
            //Movie existingMovie = dbContext.Movies.FirstOrDefault(x => x.IdMovie == movieModel.IdMovie);
            Movie existingMovie = dbContext.Movies.FirstOrDefault(x => x.IdMovie == id);
            if ( existingMovie!=null )
            {
                dbContext.Movies.Remove(existingMovie);
                dbContext.SaveChanges();
            }
        }
        private Movie MapModelToDbObject(MovieModel movieModel)
        {
            Movie movie=new Movie();
            if(movieModel!=null)
            {
                movie.IdMovie=movieModel.IdMovie;
                movie.Name=movieModel.Name;
                movie.Quantity=movieModel.Quantity;
                movie.AvailableQuantity=movieModel.AvailableQuantity;
                movie.Price=movieModel.Price;
                movie.Date=movieModel.Date;
            }
            return movie;
        }

        private MovieModel MapDbObjectToModel(Movie dbMovie)
        {
            MovieModel movieModel=new MovieModel();
            if(dbMovie!=null)
            {
                movieModel.IdMovie=dbMovie.IdMovie;
                movieModel.Name=dbMovie.Name;
                movieModel.Quantity=dbMovie.Quantity;
                movieModel.AvailableQuantity=dbMovie.AvailableQuantity;
                movieModel.Price = (float)dbMovie.Price;
                movieModel.Date=dbMovie.Date;
            }
            return movieModel;
        }
    }
}
