# Skóglendi Academy
### Group Members: Ronny Recinos, Shin Imai, Jon-Michael Hoang

### Proposal Slides:  https://docs.google.com/presentation/d/1SmN3iOfw3ttwXD3PxEoMLJnwal2yaloUnAN2FGzVYqM/edit?usp=sharing
### Design Document: https://docs.google.com/document/d/1fbWiBs8RotV0kX6Cf__c_lfFQZAgx8Pks9wU9-NNrd0/edit?usp=sharing
### Bug Tracker: GitHub Issues


# Demo Instructions
### Left Mouse Button - Click and drag various objects around the level. Compatiable items are: Sacks, Candle, Bowl, Vase
### Creature AI will chase you if you get too close
### Small portion of the level constructed reflects what the final project overall level will be like

#Design and Rationale of implemented components

### Physics

Implemented various physics based objects in the game. Realtime physics is a big part for this game since most if not all puzzles of the game will be physics based. One current implementation is the introduction of player interactable boxes. These are used for the first easy to do puzzle that the player will solve when starting the game to familiarize themselves that physics will be a huge part of the game. They can pick up and stack the boxes to reach a key to open the path to the next puzzle (not yet implemented) that deals with the AI. 

Also, there are doors that can be pushed open by the player which further add to the theme of being majority physics based. A fire particle system was also implemented to provide proper fire-physics in addition to improving the overall atmosphere of the game.

### AI

* Pathing (Shin Imai)
* Chasing  (Jon-Michael Hoang)
* FSM (Ronny Recinos) 

The AI has several algorithms that run based on events. The AI can navigate through the level using a NavMesh provided by Unity, which uses the A* traversal algorithm. Outside of the A* algorithm, it also patrols throughout a designated area for the purpose of this demo and will later be expanded throughout the development of the game. This AI is a major component of the game since the player has to avoid the AI at all costs. If the player gets too close to the AI, it will chase them (implemented) and attack until they’re dead (not yet implemented) or they successfully hide themselves by using a scroll (not yet implemented).

### Animations (Mecanim) 

* Several animations were implemented:
* Player idle animation (Shin Imai)
* Player cast animation (Jon-Michael Hoang)
* Light flickering (Ronny Recinos)
* Creature walk animation
* Creature run animation

These animations tie to the game very well to provide an engaging atmosphere to the player. It would be immersion breaking if they see the creature just sliding around the map towards them. 

### Lights

Since the game is a horror type game. The overall lighting will be dim and dark to provide an immersive, scary experience for the player. There is a thick black fog so the player cannot see clearly the area that they’re in and that is by design. As a result, the player wields an orb that acts as a source of light to better guide themselves throughout the world, albeit the light’s limited range. The location of the creature is denoted by a dim red light within the player's field of view -- provided that the creature is in said view in the first place. This light is a visual cue to allow the player to make quick, important decisions or face being caught and killed.

### Sounds

As the player walks and runs about the world, sounds of footsteps are produced in addition to a jumping sound provided that the player does jump. Throughout the academy, torches not only light the area, but also emit a crackling sound based on relative distance from the torch(es) itself.

The lack of sounds other than the player’s movement and the crackling of fire adds to the ominous feeling of not knowing what is ahead as there is a lack of audio cues.

### Textures

Boxes have separate textures on them. They resemble steel blocks that the player can pick up with their levitation spell (spell effect isn’t implemented but the pick up mechanic is).


