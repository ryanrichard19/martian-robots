package main

type World struct {
	MaxX int
	MaxY int
}

func (w World) Contains(x, y int) bool {
	return x >= 0 && x <= w.MaxX &&
		y >= 0 && y <= w.MaxY
}