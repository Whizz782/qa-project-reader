# qa-project-reader
Example code to read QuiltAssistant project files

This command line tool reads QuiltAssistant project files (.qa2 extension) and writes them to JSON (.json) to make the contents readable

## General information

The main component of a QuiltAssistant project is a tree of shapes representing the design. The shape at the root of the tree is the full drawing area, the levels below are subdivisions of the parent shape.

Each shape refers to a list of edges that make up the shape. Each edge in the list has an index; if a negative index is specified, the direction of the edge should be reversed.

Shapes have an optional name. Shapes without a name derive their name from the shape, with an added letter for each of the children. E.g. if the parent is named 'parent', and the 3 children are unnamed, their assigned names are `parent.A`, `parent.B` and `parent.C`.

All sizes are stored in millimeters. The X direction increases from left to right, the Y direction from top to bottom.

Angles are stored in degrees (between 0 and 360).

## Data structures

The main project contains the following sections:
* Header - contains a version number for the file and the application that created it. Example: `210` = v2.10
* MainSettings - contains user settings for the use of grid, snap and mirroring
* Palette - contains colors for the user defined palette (if any)
* ImageSettings - contains image settings for the project: size in pixels and millimeters, referenced image and offset
* VertexList - contains a list of points (vertices) used in the project, the first point in the array has index #0. 
* EdgeList - contains a list of edges. Each edges runs between 2 points (referenced by index in the VertexList). Curved edges additionally contain a `StartControlPoint` and `EndControlPoint`, specified as an x-y offset (vector) from the `StartVertex` and `EndVertex`.
* ShapeList - contains a list of shapes. Each shape belongs to the same tree and has a `ParentIndex` (-1 for the root of the tree) and a list of `Children`. Shapes without children are the leaves of the tree and therefore the actual shapes drawn and printed by the software.