using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using We_Doku.Models;
using We_Doku.Models.Helpers;
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
            GameBoard.GameSpaces.Sort(delegate (GameSpace space1, GameSpace space2)
            {
                int compareY = space1.Y.CompareTo(space2.Y);
                if (compareY == 0)
                {
                    return space1.X.CompareTo(space2.X);
                }
                return compareY;
            });
        }

    }
}