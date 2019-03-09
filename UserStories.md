# User Stories

### User Story 1: As a User, I want a landing page for when a I visit the site
#### Features:
- Construct an index Razor page
- Build out the footer
- Build out the header

#### Acceptance Tests:
- Index page is rendered upon page load
- Header displays with proper layout
  
### User Story 2: As a developer, I want to build out a table within my landing page to hold the game board
#### Features:
-	Build out the logic within the razor page to pull in the sudoku board
-   Build out the Index view to hold the given sudoku board
-   Within the game board, build out the functionality to have user inputs with forms that route to given methods

#### Acceptance Tests:
- Verify that a sudoku board can display upon page load
- Verify that user inputs are being sent
-
### User Story 3: As a developer, I want to construct an algorithm to build a Sudoku Board
#### Features:
-	Construct a matrix for the Sudoku board
-	Build a method that fills in sudoku board with a solvable board

#### Acceptance Test:
- Validate that a matrix is made
- Validate that the matrix made is a valid board

### User Story 4: As a developer, I want to have validation based on user input within my Sudoku Board 
#### Features:
-	Build out a method that hides masks spaces on board
-   Build out method to validate coordinate with coordinate in Squares table to unmask space.

#### Acceptance Tests:
- Validate that board generated has hidden squares
- Validate that incorrect move will not unmask space
- Validate that a correct move will unmask space.

### User Story 5: As a User, I want to be able to access the site along with additional users
#### Features:
-	Test and ensure Signal R is working properly
-   Add JQuery commands that update the client browser with new data sent using Signal R

#### Acceptance Tests:
- Verify that two users can successfully input on a given board
- Verify that board updates on all client boards

### User Story 7: As a User, I want to see when I've made an incorrect input
#### Features:
- Build out a Signal R trigger within server logic to target client browswer that sent the incorrect input
- Implement client based logic to listen for Signal R message and display output to user indicating wrong move

#### Acceptance Tests:
- Verify that Signal R message is sent when incorrect move is made
- Verify that client browser recieves Signal R trigger and only that client browser
- Ensure that visual display occurrs and looks accurate

### User Story 8: As a User, I want to know when I've won a game
#### Features:
- Indicate Visually when a user has won a game
- Create a new game board upon completion

#### Acceptance Tests:
- Client browser receives a Signal R message when a game is completed
- Client browser successfully renders desired completion message
- Successfully generate a new board
- Verify new board is displayed when page is loaded


### User Story 9: As a User, I want an intuitive and engaging interface
#### Features:
-	Clean up the layout of the webpage
-	Add animation to the Board
-	Style the header

#### Acceptance Tests:
- Header looks professional
- Board shakes when an incorrect input is given
- Layout of website looks professional

### Stretch:
-	Add Identity
-	Add user registration for when they access the site
-	Enable the ability to have multiple game stats in different lobbies
-	Enable player vs player

