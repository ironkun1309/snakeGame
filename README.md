# snakeGame
Snake Game

## 12/10/2021 - 12/12/2021: 
  This is where I will be tracking my progress and writing my thoughts on the game.
  
  To give a bit of background about myself. I'm a Junior who recently switched majors from Biology to Computer Science and am currently at the Georgia Institute of Technology. Furthermore, I've taken CS1301 (beginner course in Python) and CS1331 (beginner course in Java/OOP).
  
  To further my learning, I'll be making a few changes to the game and try my best to implement my small ideas. The crucial aspect of my education is starting as small as possible and going from there.
  - Lower Saturation of the Snake to make the visual more pleasing to the player.
  - Fixed Timestep of 0.06 instead of 0.04 for an easier learning curve.
  - Snake prefab (body) of Scale 0.75 instead of 0.90. The reason for this is that I wanted to distinguish the larger Head to the body so that the entire shape resembles more of an actual snake and makes it clear where the Head of the snake is at all times, which is what the Player will control.
  - Lastly at the start of the game, the Player will start with just the head instead of having an initial size of 8.
  - For the code, I've added commentary as to why each line of code is needed.

  My Version
  
![snake2](https://user-images.githubusercontent.com/88602267/145722132-aa3e98d0-f274-4b7f-ba50-0a7706f6170d.gif)

### Edge Cases and future implementation
- The two prominent edge cases that I've found are going in the opposite direction you're going, which will result in a "game over" and the food pellets spawning on the snake's body. These will be the two problems that the video did not cover, which I'll try to solve.
- One implementation that I would like to make is to add arrow keys as a secondary option.

## 12/13/2021 - Fixing edge cases and implementing arrow controls:
  - I've gone ahead and implemented the arrow keys.![image](https://user-images.githubusercontent.com/88602267/145889302-0ec32886-9b72-40c5-ad42-ad6174c65054.png)
- One question that I came across was why Zigurous didn't implement an else statement at the end. In java, I learned that we always want the last resort option if all of our "if" and "else if" conditions fail. While this is generally the case, placing an else statement wouldn't make sense because we need a condition after pressing D or the right arrow.
- When fixing the edge case of going in the opposite direction, it was a great reminder that "or" statements take priority. ![image](https://user-images.githubusercontent.com/88602267/145894789-89a02163-b808-408e-bc25-9c93fe6c5b2f.png)
- The code below has a problem where C# will check the conditions based on where "||" is splitting the condition. In this case, the "&&" statement will pair with arrow keys disabling the ability to go the opposite direction on arrow keys, but won't apply to WASD keys. ![image](https://user-images.githubusercontent.com/88602267/145896156-818d9c36-c6b9-4a20-89e8-71d9f9098a5e.png)
- Another option that would make the code cleaner is adding parenthesis at the correct locations. ![image](https://user-images.githubusercontent.com/88602267/145896039-c96e2d3e-3595-4cd3-9ebc-2313b1b1d843.png)

