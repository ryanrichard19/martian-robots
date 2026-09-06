package main

import (
	"fmt"
	"strconv"
	"strings"
)

func ParseInput(lines []string) (ProblemInput, error) {
	if len(lines) == 0 {
		return ProblemInput{}, fmt.Errorf("input is empty")
	}

	worldParts := strings.Fields(lines[0])
	if len(worldParts) != 2 {
		return ProblemInput{}, fmt.Errorf("invalid world coordinates")
	}

	maxX, err := strconv.Atoi(worldParts[0])
	if err != nil {
		return ProblemInput{}, err
	}

	maxY, err := strconv.Atoi(worldParts[1])
	if err != nil {
		return ProblemInput{}, err
	}

	var robots []RobotInput

	for i := 1; i < len(lines); i += 2 {
		if i+1 >= len(lines) {
			return ProblemInput{}, fmt.Errorf("missing instruction line")
		}

		positionParts := strings.Fields(lines[i])
		if len(positionParts) != 3 {
			return ProblemInput{}, fmt.Errorf("invalid robot position")
		}

		x, err := strconv.Atoi(positionParts[0])
		if err != nil {
			return ProblemInput{}, err
		}

		y, err := strconv.Atoi(positionParts[1])
		if err != nil {
			return ProblemInput{}, err
		}

		orientation, err := parseOrientation(positionParts[2])
		if err != nil {
			return ProblemInput{}, err
		}

		robots = append(robots, RobotInput{
			X:            x,
			Y:            y,
			Orientation:  orientation,
			Instructions: strings.TrimSpace(lines[i+1]),
		})
	}

	return ProblemInput{
		MaxX:   maxX,
		MaxY:   maxY,
		Robots: robots,
	}, nil
}

func parseOrientation(value string) (Orientation, error) {
	switch value {
	case "N":
		return North, nil
	case "E":
		return East, nil
	case "S":
		return South, nil
	case "W":
		return West, nil
	default:
		return 0, fmt.Errorf("invalid orientation: %s", value)
	}
}