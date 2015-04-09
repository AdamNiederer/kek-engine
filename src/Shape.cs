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
		protected abstract PrimitiveType Primitive { get; set; }

		protected static PrimitiveType LastPrimitive { get; set; }
		public static List<Shape> RenderQueue = new List<Shape>();

		public Collider Coll { get; set; }
		public Rigidbody Body { get; set; }
		public Transform Trans { get; set; }

		Shape (Color Colour, bool Visible)
		{
			this.Colour = Colour;
			this.Visible = Visible;
			RenderQueue.Add (this);
		}

		public abstract void Render ();

		public virtual void Free ()
		{
			RenderQueue.Remove(this);
		}

		public static void FreeAll ()
		{
			RenderQueue.Clear ();
		}
	}
}

