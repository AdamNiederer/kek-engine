using System;
using System.Collections.Generic;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Game
{
	public abstract class Shape
	{
		protected Color Colour { get; set; }
		protected bool Visible { get; set; }

		protected static PrimitiveType LastPrimitive { get; set; }
		public static List<Shape> AllShapes = new List<Shape>();

		public Collider Coll { get; set; }
		public Rigidbody Body { get; set; }
		public Transform Trans { get; set; }

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

