using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using We_Doku.Models;
using We_Doku.Models.Interfaces;

namespace We_Doku.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IGameBoard _gameBoard;

        [BindProperty]
        public GameBoard GameBoard { get; set; }

        [FromRoute]
        public int? ID { get; set; }

        public IndexModel(IGameBoard gameBoard)
        {
            _gameBoard = gameBoard;

        }
        public async Task OnGet()
        {
            IEnumerable<GameBoard> allBoards = await _gameBoard.GetGameBoards();
            GameBoard = allBoards.FirstOrDefault();
        }
    }
}