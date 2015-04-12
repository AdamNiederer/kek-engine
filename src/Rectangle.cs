using System;
using System.Drawing;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Game
{
	public class Rectangle : Shape
	{
		public Dictionary<Vector2, Color> PointColors = new Dictionary<Vector2, Color> ();
		static PrimitiveType Primitive = PrimitiveType.Quads;

		public Rectangle (Vector2 Origin, Vector2 Dimensions) : base (Color.White, true)
		{
			this.Points = new List<Vector2> {
				new Vector2 (Origin),
				new Vector2 (Origin.X + Dimensions.X, Origin.Y),
				new Vector2 (Origin + Dimensions),
				new Vector2 (Origin.X, Origin.Y + Dimensions.Y)
			};

			Coll = new BoxCollider (this);
			Body = new Rigidbody (this);
		}

		public Rectangle (Vector2 Origin, Vector2 Dimensions, Color Colour, bool Visible) : base (Colour, Visible)
		{
			this.Points = new List<Vector2> {
				new Vector2 (Origin),
				new Vector2 (Origin.X + Dimensions.X, Origin.Y),
				new Vector2 (Origin + Dimensions),
				new Vector2 (Origin.X, Origin.Y + Dimensions.Y)
			};

			Coll = new BoxCollider (this);
			Body = new Rigidbody (this);
		}

		public Rectangle (List<Vector2> Points) : base (Color.White, true)
		{
			this.Points = Points;
			Coll = new BoxCollider (this);
			Body = new Rigidbody (this);
		}

		public Rectangle (List<Vector2> Points, Color Colour, bool Visible) : base (Colour, Visible)
		{
			this.Points = Points;
			Coll = new BoxCollider(this);
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

