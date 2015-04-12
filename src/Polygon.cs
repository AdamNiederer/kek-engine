using System;
using System.Drawing;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Game
{
	public class Polygon : Shape
	{
		protected static PrimitiveType Primitive = PrimitiveType.Polygon;

		public Polygon (Color Colour, bool Visible, List<Vector2> Points) : base (Colour, Visible)
		{
			this.Points = Points;

			Shape.AllShapes.Add (this);
			Coll = new PolyCollider (this);
			Body = new Rigidbody (this);
		}

		public override void Render()
		{
			GL.Begin (Primitive);
			GL.Color3 (Colour);
			foreach (Vector2 p in Points) {
				GL.Vertex2 (p);
			}
			GL.End ();
		}
	}
}