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
	Lost        bool
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

func (r *Robot) MoveForward(world *World) {
	nextX, nextY := r.X, r.Y

	switch r.Orientation {
	case North:
		nextY++
	case East:
		nextX++
	case South:
		nextY--
	case West:
		nextX--
	}

	if !world.Contains(nextX, nextY) {
		if world.HasScent(r.X, r.Y) {
			return
		}

		world.LeaveScent(r.X, r.Y)
		r.Lost = true
		return
	}

	r.X = nextX
	r.Y = nextY
}
