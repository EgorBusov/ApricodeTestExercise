# ApricodeTestExercise
      GetGames

Method: GET

Path: api/Game/GetGames

Description: Retrieve a list of all games in the library.



      GetGamesByGenre

Method: GET

Path: api/Game/GetGamesByGenre/{genre}

Description: Retrieve a list of games filtered by genre.

Parameters:
genre (string, path) - The name of the genre to filter by.


      AddGame
      
Method: POST

Path: api/Game/AddGame

Description: Add a new game to the library.

Request Body:

id (integer, required) - The ID of the game.

name (string, required) - The name of the game.

devStudio (string, required) - The name of the game's development studio.

genres (array of objects, required) - The genres associated with the game.

id (integer, required) - The ID of the genre.

name (string, required) - The name of the genre.


      UpdateGame
      
Method: PUT

Path: api/Game/UpdateGame

Description: Update an existing game in the library.

Request Body:
id (integer, required) - The ID of the game.

name (string, required) - The new name of the game.

devStudio (string, required) - The new name of the game's development studio.

genres (array of objects, required) - The new genres associated with the game.

id (integer, required) - The ID of the genre.

name (string, required) - The name of the genre.


      DeleteGame
      
Method: DELETE

Path: api/Game/DeleteGame/{id}

Description: Delete a game from the library.

Parameters:
id (integer, path) - The ID of the game to delete.

Response Codes

200 OK: The request was successful.

400 Bad Request: There was an error or the request was invalid.
