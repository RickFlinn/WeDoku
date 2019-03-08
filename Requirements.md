# Software Requirements

## Vision

- We are building a an interactive, multiplayer Sudoku platform. This will provide a collaborative environment for Sudoku lovers to break out of isolation and come together with other like minded individuals. Sudoku is traditionally a single player game. We will be facilitating an environment where several players can interactively collaborate on a game. This is an enexplored dimension to the game that we will pioneer, bringing an entirely new element into the equation.

## Scope-In

- The web application will provide users a solveable Sudoku Game Board.

- The web will provide a platform for multiple users to input Moves.

- Each user move will be validated against a Game Board Key.

- Upon solving the puzzle, a new Game Board will display.

## Scope-Out

- Our website will never be pay to play.

- Our website will not offer suggested next moves.

## MVP

- A Game state that is always running.

- Utilization of Signal R to provide live updates.

- More than one person can access the site and interact with the game board.

## Stretch

- Player registration.

- Track each incorrect game moves.

- Create a Player versus player game mode.

- User Profiles with stats on wins/loses.

- Game Lobby for more than one concurrent game.

- Chat box functionality.

## Functional Requirements

- A solvable Sudoku Game Board will always be running on landing page.

- A user can interact with the game board.

- A new game will display upon solving the game.

## Non-Functional Requirments

#### Availability 

- The availability of the solution is 100% readily available at all times, running parallel in the background so that it does not conflict with testability.

#### Maintainability 

- The maintainability of the game board will have clear maintainence because players are playing with one specific solution per game, which maximizes the product’s efficiency so that it is running a system of continuous reliability and uncompromised integrity.

## Data Flow

 - When a user makes an initial request to our main page, we pull the singular Board with its associated Gamespace entries, which maps the values for a Sudoku board to display. With our MVP, a single board state - a board entry in the Boards table and 81 Gamespace entries for a solved Sudoku board, with some spaces “masked”, i.e. to be shown as an empty space - will always be returned. 

- When a user wishes to make a move, i.e. place a number on the board, they simply select the desired number for the board space. Each masked board space is a form, containing the space’s coordinates, the desired value to place in that space, and the Board’s ID. When the user selects a value for a space, a call is made to a controller endpoint that manages user inputs. The controller takes in the form data, using the BoardID, XCoord and YCoord as a composite key to locate the corresponding Gamespace entry, and compares its value with the one from the form; as each sudoku board should only have a single solution, this indicates whether the user’s choice was “correct”. If a correct square is unmasked, we will add to our counter.

- If the user attempted to place an incorrect entry, only their browser is updated to indicate that they placed an “incorrect” answer. If the user placed a correct entry, the Gamespace entry is updated to be “unmasked”, and all other board spaces are checked to see if there are any remaining “unmasked” spaces on the board. If there are still unmasked spaces, SignalR is used to update all client browsers with the new entry. Scripting on each client’s browser listens for this SignalR update, executing a jQuery command that alters the display of the webpage to unmask the correctly guessed value for that gamespace - “filling in” the space.

- If all our counter is greater than 80, a separate SignalR command is sent to all client browsers indicating that the board has been completed. Then, an algorithm builds a randomized sudoku solution, and saves each space’s value to the corresponding Gamespace entry. Then, spaces are ‘removed’ from the solution array, each time checking the number of possible solutions for the gameboard, and marking the corresponding gamespace as “masked”. This continues until we have a sufficiently sparse board, with only one solution. Once this board is constructed, all client browsers are updated to reflect the new board. 
