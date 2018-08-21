# battleships
Battleships tech test

This is a .net core 2.1 web api. Running the api on kestrel will open the swagger page where you can take the api for a spin.

POST /api/boards 
Will return a new board

POST /api/boards/{board}/battleship/{battleship}/add
{
  "row": 3,
  "column": "B",
  "placement": "northSouth"
}
Will add the battleships returned in the new board to the board

POST /api/boards/{board}/attack
{
  "column": "B",
  "row": 2
}
Will return 404 or miss

POST /api/boards/{board}/attack
{
  "column": "B",
  "row": 3..5
}
Will return 200 or hit

POST /api/boards/{board}/attack
{
  "column": "B",
  "row": 6
}
Will return 410 gone or game over.

Tried to only implement the functionality needed. Unit tests have been added to cover the core logic.
