package pr.movies.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import pr.movies.models.Movie;
import pr.movies.repositories.MovieRepository;

@Controller
@RequestMapping("/movies")
public class MovieController {
    private final MovieRepository movieRepository;

    public MovieController(MovieRepository movieRepository) {
        this.movieRepository = movieRepository;
    }

    @GetMapping()
    public String getAllMovies(Model model) {
        model.addAttribute(new Movie());
        model.addAttribute("movies", movieRepository.findAll());
        return "movies";
    }

    @PostMapping()
    public String createMovie(Movie movie) {
        movieRepository.save(movie);
        return "redirect:/movies";
    }
}
