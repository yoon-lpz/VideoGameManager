using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoGameManager.Services;

namespace VideoGameManager.Pages.Games
{
    public class FilesModel : PageModel
    {
        private readonly GameService _gameService;
        public List<string> Log { get; set; } = new();

        public FilesModel(GameService gameService)
        {
            _gameService = gameService;
        }

        public void OnGet()
        {
            if (System.IO.File.Exists(_gameService.logPath))
            {
                Log = System.IO.File.ReadAllLines(_gameService.logPath).ToList();
            }
        }
    }
}
