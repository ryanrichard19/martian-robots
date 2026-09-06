package main

type RobotInput struct {
	X            int
	Y            int
	Orientation  Orientation
	Instructions string
}

type ProblemInput struct {
	MaxX   int
	MaxY   int
	Robots []RobotInput
}

func Simulate(input ProblemInput) []Robot {
	world := NewWorld(input.MaxX, input.MaxY)
	results := make([]Robot, 0, len(input.Robots))

	for _, inputRobot := range input.Robots {
		robot := Robot{
			X:           inputRobot.X,
			Y:           inputRobot.Y,
			Orientation: inputRobot.Orientation,
		}

		for _, instruction := range inputRobot.Instructions {
			switch instruction {
			case 'L':
				robot.TurnLeft()
			case 'R':
				robot.TurnRight()
			case 'F':
				robot.MoveForward(world)
			}

			if robot.Lost {
				break
			}
		}

		results = append(results, robot)
	}

	return results
}
