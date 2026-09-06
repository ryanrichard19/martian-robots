package main

type Point struct {
	X int
	Y int
}

type World struct {
	MaxX   int
	MaxY   int
	scents map[Point]struct{}
}

func NewWorld(maxX, maxY int) *World {
	return &World{
		MaxX:   maxX,
		MaxY:   maxY,
		scents: make(map[Point]struct{}),
	}
}

func (w *World) Contains(x, y int) bool {
	return x >= 0 && x <= w.MaxX &&
		y >= 0 && y <= w.MaxY
}

func (w *World) LeaveScent(x, y int) {
	w.scents[Point{X: x, Y: y}] = struct{}{}
}

func (w *World) HasScent(x, y int) bool {
	_, exists := w.scents[Point{X: x, Y: y}]
	return exists
}
