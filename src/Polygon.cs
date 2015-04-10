using System;
using System.Drawing;
using OpenTK;
using System.Collections.Generic;

namespace Game
{
	public class Polygon : Shape
	{
		List<Vector2> Points;
		public Polygon (Color Colour, bool Visible, List<Vector2> Points) : base (Colour, Visible)
		{
			Shape.AllShapes.Add (this);
		}

		public override void Render()
		{

		}
	}
}