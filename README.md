# TurnBasedCombat
A unity gamejam where I try to make a turn based battle system. Inspired by an older assignment i once had

# The Lore
Back in the first year, I had this subject called Expirience Design and for the final group assignment in that course, my group chose to make a RPG sort of game.
I had been put on programming duty, particularly figuring out collision detection and also implementing the combat system. This was a time where I practically no expirience with OOP, never seen C# before and had only glanced at Unity in the past. Needless to say, it wasn't easy. I managed to figure out a few things about Unity, how it's graphics engine worked, how to render animations, and some basic scripting stuff. I acheived everything however through just blindly following youtube videos and not understanding what was happening myself. The "Combat System" I made was unacceptable in my honest opinion, but I honestly had no idea what to do, and the deadline was approaching so I gave up.

# The Goal
The original "Combat System" simply loaded up the characters, generated some foes, rendered their respective health values and then gave the player a "button" they could press over and over to randomly harm an enemy. Hardly an interactive expirience, and it didn't really visually convey what was happening. The goal of the Jam is to go back to the idea of a turn based combat system, and actually implement the staple features.

- Should let the player select a move
- Should let the player select a target
- hould let the player use active items
- Should show the player what their stats are clearly

# Personal rule
Something I wasn't very statisfied with in my original gander at the problem was that I was reliant on a tutorial to guide me through every single step of the process. Both for the sake of the Jam's merit, and also for my own fullfillment, I decided that I wasn't allowed to look up resources for implementing RPG elements whatsoever. I would look up Unity/C# spesific documentation of methods, but anything I implemented was out of my own thought rather than through a guide.

# The result
## How does it work?
So all of the battle system's logic is handled by a single Battle.cs script. It keeps track of values, shows/hides UI elements and keeps track of who's turn it is. Stored inside of it, it has fields for all the UI elements in the game, as well as arrays that represent the characters in the scene.

In the Start() method the script sets up generates a random number of enemies for the party to fight, as well as create the actual party members. Then later in the Update() method, the game loop happens.

In the Update() there is a switch() which checks the current game state. The state is defined by an enum with the values PlayerTurn, EnemyTurn and End. It's PlayerTurn by default and depending on what the game state is, different methods are called.

#### Player turn
During the PlayerTurn state the game enters another switch() that checks the gamestate of the player's turn. This is defined by another enum with values for whatever actions the player is making during the turn (Selecting what action they want to make, making an attack, selecting a target, etc). A field called characterTurn is updated whenever a character finishes their turn, and when all characters have made their actions, the game state is changed to EnemyTurn, assuming there are still enemies.
##### Enemy turn
The enemy turn is a lot simpler as I frankly could not think of how to do an AI very well. The enemy simply chooses whichever partymemeber has the least health and all attack that target. Rince and repeat. Once they're done, the game state goes back to PlayerTurn assuming there still are players.
#### End
This game state is reached when either all the enemies are killed or all the players are. There is however no real implementation for what happens then beyond writing to the console that the game has ended. The focus was more on the implementing the game logic.
### Creatures
A character is defined by the Creature class. A Creature stores various values such as health, and mana, as well as a pair of lists that act as the character's inventory and abilities. It was intended to serve as a generic parent class for other subclasses (Like maybe Monster and Fighter) that were to be added later on, but for the purpose of this jam, i focused on keeping it small.

### Items
Items come in two forms. Weapons and Consumables. The Item class acts as a parent for all its subclasses and stores data such as the item's name, its stats and any kind of special effect it might have. Weapons store further values such as a damage field and a buff field, which augments the damage dealt by the weapon. Consumables have a field of the amount of uses they have.

Examples of Weapons are the Longsword class, and an example of a Consumable is the HealthPotion class.

### Skills
Skills also come in two main forms. Abilities and Attacks. Attacks target enemies while abilities target party members. And example of an attack is the WeaponAttack class, which uses whatever weapon the character has equipped. If there is no weapon, the character will be using their bare hands. An example of an ability is the BulkUp class, whose effect raises the character's strenght by two, meaning they'll hit harder with their weapon attacks.

