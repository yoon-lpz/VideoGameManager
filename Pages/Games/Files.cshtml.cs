using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoGameManager.Models;
using VideoGameManager.Services;

namespace VideoGameManager.Pages.Games
{
    public class FilesModel : PageModel
    {
        private readonly GameRepository _repository;
        private readonly GameService _gameService;
        private List<Game> _games;
        public List<string> Log { get; set; } = new();

        public FilesModel(GameService gameService, GameRepository repository)
        {
            _gameService = gameService;
            _repository = repository;
        }

        public void OnGet()
        {
            if (System.IO.File.Exists(_gameService.logPath))
            {
                Log = System.IO.File.ReadAllLines(_gameService.logPath).ToList();
            }
        }

        public IActionResult OnPostExportJson()
        {
            _repository.SaveAll(_gameService.GetAll());
            return RedirectToPage();
        }

        public IActionResult OnPostImportJson()
        {
            _games = _repository.LoadAll();
            _gameService.GetAll().Clear();
            _gameService.GetAll().AddRange(_games);
            return RedirectToPage();
        }
    }
}
