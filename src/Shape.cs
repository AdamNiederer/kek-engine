using System;
using System.Drawing;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Game
{
	public abstract class Shape
	{
		public Collider Coll;
		public Rigidbody Body;
		public List<Vector2> Points;
		public bool Visible;

		public Color Colour;

		protected static PrimitiveType LastPrimitive;
		public static List<Shape> AllShapes = new List<Shape>();


		protected Shape (Color Colour, bool Visible)
		{
			this.Colour = Colour;
			this.Visible = Visible;
			AllShapes.Add (this);
		}

		public abstract void Render ();

		public virtual void Free ()
		{
			AllShapes.Remove (this);
		}

		public static void FreeAll ()
		{
			AllShapes.Clear ();
		}
	}
}

