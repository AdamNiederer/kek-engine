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

		public Rectangle(Color Colour, bool Visible, List<Vector2> Points) : base(Colour, Visible)
		{
			this.Points = Points;
			Coll = new BoxCollider(this);
			Body = new Rigidbody (this);

		}
			
		public override void Render() //TODO TODO TODO TODO TODO
		{
			Console.WriteLine ("Rendering!");
			LastPrimitive = Primitive;

			GL.Begin (Primitive);

			GL.Color3 (Colour);

			foreach (Vector2 p in Points) {
				Console.WriteLine ("Rendering " + p.ToString () + "!");
				GL.Vertex2 (p);
			}

			GL.End ();

		} 
	}
}

