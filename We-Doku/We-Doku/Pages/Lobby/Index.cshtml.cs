using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using We_Doku.Models;
using We_Doku.Models.Interfaces;

namespace We_Doku.Pages.Lobby
{
    public class IndexModel : PageModel
    {
        private IGameBoard _gameBoard;

        public IndexModel (IGameBoard gameBoard)
        {
            _gameBoard = gameBoard;
        }

        [FromRoute]
        public int ID { get; set; }
        public GameBoard GameBoard { get; set; }


    }







        public void OnGet()
        {
        }
    }
}