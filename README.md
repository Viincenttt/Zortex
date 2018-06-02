# Zortex
Zortex is a singleplayer virtual reality space-shooter game that was built in Unity. The player controls a miniature spaceship using the Oculus Touch or HTC Vive controllers. The goal of the game is to stay alive for as long as possible, while destroying as many alien spaceships as possible. The game is based on the Xortex game that is part of [The Lab](https://store.steampowered.com/app/450390/), created by Valve. 

![alt text](https://github.com/Viincenttt/Zortex/blob/master/Screenshots/Game%20impression%202.png "Game impression")

### Project features

#### Enemy spawning configuration
The enemy spawn area has extensive configuration options. This allows you to tweak the difficulty of the game. You can configure the enemy spawning area size, which enemy types to spawn and how fast enemies are spawned. 

![alt text](https://github.com/Viincenttt/Zortex/blob/master/Screenshots/Enemy%20spawnarea%20configuration.png "Enemy spawner configuration options")

*The configuration options of the enemy spawn area*

#### Player vision
The player ship automatically targets and fires at enemy ships when they enter the players visible area. The vision of the player ship can be configured from within Unity. While play-testing the game, I discovered that using a view angle for the player ship offers the best gameplay. The view angle functions like an aim-assist, enemy targets that are far away do not require very precise aiming. 

![alt text](https://github.com/Viincenttt/Zortex/blob/master/Screenshots/Player%20vision.png "The player view angle")

*The view of the player ship*

![alt text](https://github.com/Viincenttt/Zortex/blob/master/Screenshots/Player%20vision%20configuration.png "The player view angle configuration")

*The configuration of the player ship view*

### Technologies
The game is built in Unity and uses SteamVR and the VRTK library to add support for virtual reality. All 3D models in this game were created using Blender. The game code is written in C# using Visual Studio 2017. All assets in this game are self-made, except for the music and sound-effects. 

### Credits
#### Music
All music in this game was created by Kevin MacLeod. 

Furious Freak Kevin MacLeod (incompetech.com)
Licensed under Creative Commons: By Attribution 3.0 License
[http://creativecommons.org/licenses/by/3.0/](http://creativecommons.org/licenses/by/3.0/)

Ouroboros Kevin MacLeod (incompetech.com)
Licensed under Creative Commons: By Attribution 3.0 License
[http://creativecommons.org/licenses/by/3.0/](http://creativecommons.org/licenses/by/3.0/)

Shiny Tech Kevin MacLeod (incompetech.com)
Licensed under Creative Commons: By Attribution 3.0 License
[http://creativecommons.org/licenses/by/3.0/](http://creativecommons.org/licenses/by/3.0/)

#### Sounds
All sounds were downloaded from [freesound.org](https://freesound.org/). 
