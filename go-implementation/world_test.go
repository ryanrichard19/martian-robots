package main

import "testing"

func TestWorldContains(t *testing.T) {
	world := World{
		MaxX: 5,
		MaxY: 3,
	}

	tests := []struct {
		name string
		x    int
		y    int
		want bool
	}{
		{"inside world", 2, 2, true},
		{"lower left corner", 0, 0, true},
		{"upper right corner", 5, 3, true},
		{"left of world", -1, 1, false},
		{"right of world", 6, 1, false},
		{"below world", 1, -1, false},
		{"above world", 1, 4, false},
	}

	for _, tt := range tests {
		t.Run(tt.name, func(t *testing.T) {
			got := world.Contains(tt.x, tt.y)

			if got != tt.want {
				t.Fatalf("got %v, want %v", got, tt.want)
			}
		})
	}
}