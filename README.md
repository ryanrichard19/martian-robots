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

The world starts at `(0, 0)` and the upper-right coordinate is supplied as input.

Robots are processed one at a time.

If a robot tries to move beyond the edge of the world, it becomes `LOST` and stops processing any further instructions.

When a robot is lost, it leaves a scent at the last valid grid position it occupied.

If another robot later reaches that same position and receives a forward instruction that would make it fall off the world, that instruction is ignored and the robot carries on with the rest of its instructions.

For each robot, the program needs to return its final position and orientation and indicate whether it was lost.

The challenge also mentions that new command types may be required in the future, so I wanted to leave a simple way of adding commands without making the rest of the solution more complicated.

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

## Solution Structure

I kept the architecture simple for the size of the problem.

The solution is split into:

- `MartianRobots.Core` — contains the domain behaviour, world state, commands, input model, and simulation logic;
- `MartianRobots.Cli` — handles console/file input and writes the result;
- `MartianRobots.Tests` — contains the unit and acceptance tests.

I did not use a full Clean Architecture approach because, for a problem of this size, it would have felt like using a bazooka to kill a fly. I wanted enough structure to keep responsibilities clear without adding unnecessary ceremony.

Instead, I focused on keeping the domain logic independent from the CLI and input/output concerns so that the core behaviour remains easy to test and change.

## Running the solution

### Prerequisites

- .NET 9 SDK

Confirm the SDK with:

```bash
dotnet --version
```

Build
From the repository root:

```bash
dotnet build
```

Run the tests

```bash
dotnet test
```

Run using an input file
```bash
dotnet run --project src/MartianRobots.Cli -- examples/testdata.txt
```

Using the supplied sample data, the expected output is:
```text
1 1 E
3 3 N LOST
2 3 S
```

## Design decisions

I kept the solution intentionally simple inline with my interpretation of KISS. 

### Robot

The `Robot` class owns the current position, orientation and lost state.

### World

The `World` class owns the grid bounds and the scents left by lost robots.

Scents belong to the world, not to a robot, because they must persist while robots are processed one after another.

### Commands

The assesment requirments notes that additional command types may be required later.

To support this without introducing unnecessary complexity, I implemented a small `ICommand` interface together with a `CommandFactory`. 

Current commands:

- LeftCommand
- RightCommand
- ForwardCommand

A new command would then need a new ICommand and a factory registration. The simulator does not change.

### ChallengeInputReader

`ChallengeInputReader` only turns the supplied text format into structured input.

Keeping that separate from simulation means domain behaviour can be tested without the console or a file.

### Simulator

`Simulator` coordinates execution.

It creates one `World` and processes each robot in order. The shared world is what makes earlier scents visible to later robots.

Once a robot is `LOST`, the simulator stops giving it instructions.

### CLI

The command-line project is thin. It only:

- reads input from a file
- passes that input to `ChallengeInputReader`
- runs the simulation
- writes the resulting positions

Domain logic stays in `MartianRobots.Core`


## Bonus: Go Implementation

I enjoyed the challenge enough that I ended up reimplementing it in Go as a small Sunday kata.

I kept the Go version deliberately simple and idiomatic rather than copying the .NET design.

See [`go-implementation`](./go-implementation).