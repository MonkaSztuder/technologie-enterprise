package pr.movies.repositories;

import org.springframework.data.repository.CrudRepository;
import pr.movies.models.Movie;

public interface MovieRepository extends CrudRepository<Movie, Long>{

}
