using System;
using System.Drawing;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Game
{
	public class Circle : Shape
	{		
		public static int GlobalResolution;
		protected static PrimitiveType Primitive = PrimitiveType.Polygon;

		protected float Radius;
		protected int Resolution;

		public Circle (Color Colour, bool Visible, List<Vector2> Points, float Radius) : base (Colour, Visible)
		{
			if (Points.Count > 1)
				throw new ArgumentException ();

			Shape.AllShapes.Add (this);
			this.Radius = Radius;
			Points = SetPoints (Points[0], Radius, GlobalResolution);
			Coll = new CircleCollider (this, Radius);
			Body = new Rigidbody (this, Points[0]);

		}

		public Circle (Color Colour, bool Visible, List<Vector2> Points, float Radius, int Resolution) : base (Colour, Visible)
		{
			if (Points.Count > 1)
				throw new ArgumentException ();

			Shape.AllShapes.Add (this);
			this.Radius = Radius;
			Points = SetPoints (Points[0], Radius, Resolution);
			Coll = new CircleCollider (this, Radius);
			Body = new Rigidbody (this, Points[0]);
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

		List<Vector2> SetPoints(Vector2 Origin, float Radius, int Resolution)
		{
			List<Vector2> Points = new List<Vector2>();
			float PointAngleDelta = (float)(2 * Math.PI) / (float)Resolution;
			for (int i = 0; i < Resolution; i++) {
				Points.Add (Origin + new Vector2 (Radius * (float)Math.Cos (PointAngleDelta * i), ((float)2 * Radius) * (float)Math.Sin (PointAngleDelta * i)));
			}

			if (Points.Count < 3)
				throw new ArgumentException ("This circle has no renderable points. Your resolution is less than three.");
			return Points;
		}
	}
}

