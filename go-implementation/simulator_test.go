package main

import "testing"

func TestSuppliedSample(t *testing.T) {
	input := ProblemInput{
		MaxX: 5,
		MaxY: 3,
		Robots: []RobotInput{
			{X: 1, Y: 1, Orientation: East, Instructions: "RFRFRFRF"},
			{X: 3, Y: 2, Orientation: North, Instructions: "FRRFLLFFRRFLL"},
			{X: 0, Y: 3, Orientation: West, Instructions: "LLFFFLFLFL"},
		},
	}

	got := Simulate(input)

	want := []Robot{
		{X: 1, Y: 1, Orientation: East},
		{X: 3, Y: 3, Orientation: North, Lost: true},
		{X: 2, Y: 3, Orientation: South},
	}

	if len(got) != len(want) {
		t.Fatalf("got %d robots, want %d", len(got), len(want))
	}

	for i := range want {
		if got[i] != want[i] {
			t.Errorf(
				"robot %d: got %+v, want %+v",
				i+1,
				got[i],
				want[i],
			)
		}
	}
}

func TestScentPreventsNextRobotFromBeingLost(t *testing.T) {
	input := ProblemInput{
		MaxX: 1,
		MaxY: 1,
		Robots: []RobotInput{
			{X: 1, Y: 1, Orientation: North, Instructions: "F"},
			{X: 1, Y: 1, Orientation: North, Instructions: "F"},
		},
	}

	got := Simulate(input)

	if !got[0].Lost {
		t.Fatal("expected first robot to be lost")
	}

	if got[1].Lost {
		t.Fatal("expected second robot to be protected by scent")
	}
}
