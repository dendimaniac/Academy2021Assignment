# Academy2021Assignment

## Instructions for playtesting
* Clone this repo
* Make sure you have Unity version **2021.1.17f1** on your local machine
* Open the project
* Open **Initialization** scene
* Press play

## Implemented features
### Gameplay
* Click to make the player jump
* Pick up stars to gain score
* Pick up color switchers to change player's color
* Collide with different color obstacle sections and die
* Be able to pass through the same color obstacle section
* Be able to kill player when going out of camera view
* Be able to simply click anywhere to try again
* Be able to have different score to gain for each star
* Show score popup with corresponding score gained amount when picking up stars
* Have scene separation to help decouple elements

### UI
* Be able to change the player icon in game-over menu
* Be able to have high score
* Show star count on the top left corner during gameplay

### Others
* Play non-stop background music
* Play sound effects for jumping, picking up stars, picking up color switchers, and dying.
* Show nice-looking particles when picking up stars or player dying
* Improve performance by having pools for different duplicate instantiation and destruction of objects

## Nice to have features
These are some of the features that I would implement for the game if I had more time:
1. The players can earn in-game currency for each star that they collect. Afterwards, before starting another run, they can use their earned credits to buy new and exciting player icons. In order to implement it, first of all, I would have a static class to manage saving and loading the amount of credits through PlayerPrefs. In addition, I would have a serializable class to store the player icon and the amount of credits required to unlock. Next, when showing all of the possible options in the `PlayerSpriteSelectionUI` class, it can easily compare the current earned credits and the cost for each option to whether it can be unlocked or not. Finally, I would implement another static class to manage the unlocked icons through serialization to correctly show whether the icon is already unlocked by comparing the sprite name.
2. The game can have a list of challenges with different special player icons as rewards for completing them. In order to implement it, I would first create a scriptable object with a list of obstacles, a reward icon, and boolean variables for whether the setup is for an endless level, if the setup is completed. To help avoid confusion when setting obstacles up, I would then add a custom editor to hide/show the reward icon field based on whether the level is endless. Next, another scriptable object is needed to store a list of the different obstacle setups, and a variable for the currently selected setup. After which, when loading the `GameScene`, the `Spawner` can get the setup from the scriptable object and set up accordingly. Afterwards, I would update the `Initialization` scene to have a list of all the challenges, showing as well whether the player has completed it or not. Finally, I would add a scriptable object to act as an event channel when the level is completed to update the completion variable and unlock the linked icon from the icon list on the 2nd item.
3. It would be nice to be able to pause the game midway, and resume when the player is ready. In order to do that, I would add another scriptable object event channel for signaling subscribers that the game is paused/resumed. When the game is paused, a pause menu will display, to let the player know that the game is paused. This is shown by a subscriber listening on the game-paused event channel. In addition, on game pauses, the different components would need to react accordingly, such as disabling the rigidbody on the player, disabling the rotation of everything. When the player presses a key to resume the game, a countdown of three seconds, using coroutines, would start to allow the player to have time to react since the play relies on precise movement. After which, everything resumes their movement.

## Possible improvements
* Some of the animation/movement, such as the movement of the score popup, can be more efficient by using tweening techniques
* The game now has some obstacle types. In order to make the game more fun to play with, significant improvement needs to be made on the balance of the obstacles. One can do that by manipulating different variables: player jump force, player gravity scale, rotate speed of obstacles, size of the obstacles, distance between obstacles, etc.

## Notes
* The naming case on the `[SerializedField] private` variables being `camelCase` without an underscore prefix is intended. In my opinion, the underscore prefix with `camelCase` naming convention should only apply for completely hidden variables, like the private instance fields. Since the field has the `[SerializedField]` attribute, it is not completely hidden.
* The naming case on some public instance fields is also camelCase due to the fact that Rider, the IDE that I used, still considers them as Unity serialized fields. Therefore, the naming case is not `PascalCase` but `camelCase` instead due to the reason above.

## Credits
* Art: [Kenny Assets](https://kenney.nl/assets/scribble-platformer)
* Sound effects & Music: [MixKit](https://mixkit.co/free-sound-effects/game/)
