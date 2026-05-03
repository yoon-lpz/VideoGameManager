using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoGameManager.Services;

namespace VideoGameManager.Pages.Games
{
    public class FilesModel : PageModel
    {
        private readonly GameService _gameService;

        public FilesModel(GameService gameService)
        {
            _gameService = gameService;
        }

        public void OnGet()
        {
        }
    }
}
