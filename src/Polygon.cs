using System;
using System.Drawing;
using System.Collections.Generic;
using OpenTK;

namespace Game
{
	public class Polygon : Shape
	{
		public Polygon (Color Colour, bool Visible, List<Vector2> Points) : base (Colour, Visible)
		{
			Shape.AllShapes.Add (this);
		}

		public override void Render()
		{

		}
	}
}