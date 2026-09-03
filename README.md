## Approach

My approach to this challenge reflects how I normally approach engineering work.

Before writing code, I first make sure I understand the problem, the requirements and the expected outcome. Once I have the full picture, I work through the solution at a high level before implementation.

For this challenge, that meant:

- reading through the requirements and identifying the key acceptance criteria
- working through the supplied example manually by hand to confirm my understanding
- sketching the main parts of the solution and their responsibilities
- identifying the use cases and edge cases that the solution needed to support
- defining the tests I would use to verify the acceptance criteria
- then implementing incrementally against the tests

Over the years I found this works best for me and past team memebrs that I have mentored. By no means am I claiming this a silver bullet but it is works best for me.

## My Understanding of the Challenge

The challenge is to simulate robots moving around a bounded rectangular grid representing the surface of Mars.

The supported instructions are:

- `L` : the robot turns left 90 degrees and stays on the current.
- `R` : the robot turns right 90 degrees andv remains on the current grid point.
- `F` : the robot moves forward one grid point in the direction of the current orientation and maintains the same orientation.

The world has a lower-left coordinate of `(0, 0)` and an upper-right coordinate supplied as input.

Robots are processed one at a time. If a robot attempts to move beyond the boundary of the world, it is considered `LOST` and stops processing further instructions.

When a robot is lost, it leaves a scent at the last valid grid position it occupied. If a later robot is at that same position and receives a forward instruction that would also cause it to fall off the world, that instruction is ignored and the robot continues processing the rest of its instructions.

For each robot, the program must return its final position and orientation, and indicate whether it was lost.

The challenge also calls out that additional command types may be required in future, so the implementation should allow commands to be extended without adding unnecessary complexity.

## Acceptance criteria

From the requirements, I identified the following acceptance criteria as the most important to verify:

- rotation changes orientation but not position
- forward movement depends on the current orientation
- valid movement remains within the world boundary
- moving beyond the boundary results in the robot becoming lost
- a lost robot leaves a scent at its last valid position
- scents affect robots processed later
- only the dangerous forward instruction is ignored when a scent is present
- robots continue processing subsequent instructions after an ignored scented move
- the supplied sample input produces the supplied sample output

## Initial Design

From the acceptance criteria above, I identified four main responsibilities:

- `Robot` : position, orientation and lost state
- `World` : grid boundaries and scents left by lost robots
- `Command` : an instruction that can be executed against a robot
- `Simulator` : processes robots and their instructions sequentially

Input parsing and output formatting should be kept separate from the core domain logic so that the acceptance criteria can be tested without going through the console application.