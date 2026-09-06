package main

import (
	"fmt"
	"os"
	"strings"
)

func main() {
	if len(os.Args) > 2 {
		fmt.Fprintln(os.Stderr, "Usage: go run . [input-file]")
		os.Exit(1)
	}

	var text string
	var err error

	if len(os.Args) == 2 {
		data, readErr := os.ReadFile(os.Args[1])
		if readErr != nil {
			fmt.Fprintln(os.Stderr, readErr)
			os.Exit(1)
		}

		text = string(data)
	} else {
		data, readErr := os.ReadFile("/dev/stdin")
		if readErr != nil {
			fmt.Fprintln(os.Stderr, readErr)
			os.Exit(1)
		}

		text = string(data)
	}

	lines := strings.Split(strings.TrimSpace(text), "\n")

	input, err := ParseInput(lines)
	if err != nil {
		fmt.Fprintln(os.Stderr, err)
		os.Exit(1)
	}

	robots := Simulate(input)

	for _, robot := range robots {
		if robot.Lost {
			fmt.Printf("%d %d %c LOST\n", robot.X, robot.Y, robot.Orientation)
			continue
		}

		fmt.Printf("%d %d %c\n", robot.X, robot.Y, robot.Orientation)
	}
}