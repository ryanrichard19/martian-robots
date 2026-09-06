package main

import "testing"

func TestTurnLeft(t *testing.T) {
	tests := []struct {
		name  string
		start Orientation
		want  Orientation
	}{
		{"north to west", North, West},
		{"west to south", West, South},
		{"south to east", South, East},
		{"east to north", East, North},
	}

	for _, tt := range tests {
		t.Run(tt.name, func(t *testing.T) {
			robot := Robot{Orientation: tt.start}

			robot.TurnLeft()

			if robot.Orientation != tt.want {
				t.Fatalf("got %c, want %c", robot.Orientation, tt.want)
			}
		})
	}
}

func TestTurnRight(t *testing.T) {
	tests := []struct {
		name  string
		start Orientation
		want  Orientation
	}{
		{"north to east", North, East},
		{"east to south", East, South},
		{"south to west", South, West},
		{"west to north", West, North},
	}

	for _, tt := range tests {
		t.Run(tt.name, func(t *testing.T) {
			robot := Robot{Orientation: tt.start}

			robot.TurnRight()

			if robot.Orientation != tt.want {
				t.Fatalf("got %c, want %c", robot.Orientation, tt.want)
			}
		})
	}
}

func TestMoveForward(t *testing.T) {
	tests := []struct {
		name        string
		orientation Orientation
		wantX       int
		wantY       int
	}{
		{"north increases y", North, 1, 2},
		{"east increases x", East, 2, 1},
		{"south decreases y", South, 1, 0},
		{"west decreases x", West, 0, 1},
	}

	for _, tt := range tests {
		t.Run(tt.name, func(t *testing.T) {
			robot := Robot{
				X:           1,
				Y:           1,
				Orientation: tt.orientation,
			}

			robot.MoveForward()

			if robot.X != tt.wantX || robot.Y != tt.wantY {
				t.Fatalf(
					"got (%d,%d), want (%d,%d)",
					robot.X,
					robot.Y,
					tt.wantX,
					tt.wantY,
				)
			}
		})
	}
}