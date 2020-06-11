# GuessBasketWeight
Develop a game with multiple computer players.

The goal of the game is to guess the weight of a fruit basket. 
The weight of the basket will be between 40 – 140 kilos. (Whole numbers)

Rules:
The game ends when a player identifies the weight correctly or there were 100 attempts.

The game has 5 types of players:
1) Random player: guesses a random number between 40 and 140.
2) Memory player: guesses a random number between 40 and 140 but doesn’t try the same number more than once.
3) Thorough player: tries all numbers by order – 41, 42, 43…
4) Cheater player: guesses a random number between 40 and 140 – but doesn’t try any of the numbers that other players had already tried.
5) Thorough Cheater player: tries all numbers by order – 41, 42, 43… but skips numbers that were already been tried before by any of the players.

The order in which players make their guesses is calculated randomly in each game.

If a player guessed a number incorrectly – he will have to skip one or more rounds calculated by the formula:
R = (ABS(W - G) / 10) - 1, where    
R - number of rounds to skip (whole number, minimal value is 0),
ABS - absolute function,
W - real weight of the basket,
G - player's guess

A Round starts with the guess of 1st player and ends with the guess of the last player.

For example, the real number is 100 – the guess was 70 – the player will wait for (3 - 1 = 2) rounds. If his guess is 130 – he will also wait for 2 rounds. 

Inputs:
1. The amount of participating players – 2 through 8
2. For each player – his name and his type. 

Outputs:
1. At the begging of the game – the real weight of the basket.
2. At the end of the game:
a. If there was a winner – his name and the total amount of attempts in the game.
b. In case there wasn’t a winner – the name of the player who was the closest (absolute) and his guess. If there were more than one – the one that was the first.His guess should be printed as well.
