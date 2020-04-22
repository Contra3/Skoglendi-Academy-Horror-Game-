# Skóglendi Academy
### Group Members: Ronny Recinos, Shin Imai, Jon-Michael Hoang

### Proposal Slides:  https://docs.google.com/presentation/d/1SmN3iOfw3ttwXD3PxEoMLJnwal2yaloUnAN2FGzVYqM/edit?usp=sharing
### Design Document: https://docs.google.com/document/d/1fbWiBs8RotV0kX6Cf__c_lfFQZAgx8Pks9wU9-NNrd0/edit?usp=sharing
### Bug Tracker: GitHub Issues


# Demo Instructions
### Left Mouse Button - Click and drag various objects around the level. Compatiable items are: Sacks, Candle, Bowl, Vase
### Creature AI will chase you if you get too close
### Small portion of the level constructed reflects what the final project overall level will be like

# Design and Rationale of implemented components

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

### Shaders and Improvements from alpha release
The three shaders that were implemented were:
* Outline Shader (Shin) - This shader is used to make bright outlines that are not affected by the dark lighting of the world. Subsequently, the objects that use this shaders are mainly items that can be found around the world, such as keys and scrolls.
* Cut-through shader (Ronny) - This shader creates an image of transparent stripes that help to immerse the player in a world of magic and wizardry. The objects that use this shader are the boxes in the furnace room.
* XXX shader (Jon Michael)

We implemented several of the suggestions from our testers. 
* Darker world - Following from a suggestion from one of our testers to make cramped spaces darker, we made the overall lighting of the world darker. In order to keep the game playable, we placed new point lights across the map in the form of torches. This helps to construct a better atmosphere suited for horror games, and aids in the surprise factor of when the monster starts chasing the player.
* Puzzle 1 fix - In the alpha release, one of our testers had discovered that the key to the first door could be obtained without stacking up the boxes in the room. In order to enforce the players to engage with the boxes, the key was placed at a higher position so that players cannot obtain the key just by jumping from the ground.
* Creature NPC - In an attempt to make the creature scarier, we added clearer music and improved the AI to chase the player more often. The intention of improving the AI was to prevent the players from leisurely exploring the world.
* Text hints - We implemented text UI to help guide the player to objectives. We also implemented text that shows whether a door can be interacted with or not. If a locked door can be unlocked, the text will read "Door is locked, maybe it can be unlocked by a key".
* Reduction in walk speed - A big complaint from both of our testers was the walkspeed of the character, which they felt was way too high. We decreased the walkspeed so that players do not constantly run into walls and objects.
* Puzzle 2 box fix - The boxes in puzzle 2 were hard to stand on, partially because of the colliders, but mostly because of the high walkspeed of the character. By reducing the walkspeed, players now have a more reasonable challenge to get to the goal platform.
* Colliders - Since the large box colliders that we had before broke the immersion of the game, we made the colliders tighter fit so that there are no big spaces between the edge of the collider and the edge of the game object. 

More modifications:
* Larger map - The map has more rooms and we have also added the final seance room where players will attempt to reach.
* Stamina bar - Underneath the health bar, we have added a stamina bar to limit the time that a player can sprint at a time.
* Scrolls - We have implemented scrolls that augment the player’s abilities, or unlock spells. This includes the Stamina scroll, which Increases max stamina by 100. The other scroll added was the Jump Scroll, which Unlocks the super jump spell. This allows players to aim and jump to locations that would be otherwise hard to reach.
* New puzzles - We improved puzzle 2 by adding another key and door, and created a new puzzle 3, which involves using the jump spell.
* Story telling - we created an opening start screen which briefly describes the story, a controls screen, and a journal screen which gives hints to guide players to objectives.
* save capabilities - An autosave feature was implemented by ronny which saves when players complete a puzzle. With this improvement, players can respawn at their last completed puzzle upon death.


