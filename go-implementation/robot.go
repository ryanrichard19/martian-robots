package main

type Orientation rune

const (
	North Orientation = 'N'
	East  Orientation = 'E'
	South Orientation = 'S'
	West  Orientation = 'W'
)

type Robot struct {
	X           int
	Y           int
	Orientation Orientation
}

func (r *Robot) TurnLeft() {
	switch r.Orientation {
	case North:
		r.Orientation = West
	case West:
		r.Orientation = South
	case South:
		r.Orientation = East
	case East:
		r.Orientation = North
	}
}

func (r *Robot) TurnRight() {
	switch r.Orientation {
	case North:
		r.Orientation = East
	case East:
		r.Orientation = South
	case South:
		r.Orientation = West
	case West:
		r.Orientation = North
	}
}

func (r *Robot) MoveForward() {
	switch r.Orientation {
	case North:
		r.Y++
	case East:
		r.X++
	case South:
		r.Y--
	case West:
		r.X--
	}
}