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

			this.Radius = Radius;
			this.Points = new List<Vector2> ();
			Shape.AllShapes.Add (this);
			Coll = new CircleCollider (this, Radius);
			Body = new Rigidbody (this, Points[0]);

			SetPoints (Points[0], Radius, GlobalResolution);
		}

		public Circle (Color Colour, bool Visible, List<Vector2> Points, float Radius, int Resolution) : base (Colour, Visible)
		{
			this.Points = Points;

			this.Points = Points;
			Shape.AllShapes.Add (this);
			Coll = new CircleCollider (this, Radius);
			Body = new Rigidbody (this);

			SetPoints (Points[0], Radius, Resolution);
		}

		public override void Render()
		{
			LastPrimitive = Primitive;

			GL.Begin (Primitive);

			GL.Color3 (Colour);

			foreach (Vector2 p in Points) {
				GL.Vertex2 (p);
			}

			GL.End ();
		}

		void SetPoints(Vector2 Origin, float Radius, int Resolution)
		{
			float PointAngleDelta = (float)(2 * Math.PI) / (float)Resolution;
			for (int i = 0; i < Resolution; i++) {
				this.Points.Add (Origin + new Vector2 (Radius * (float)Math.Cos (PointAngleDelta * i), ((float)2 * Radius) * (float)Math.Sin (PointAngleDelta * i)));
			}
		}
	}
}

