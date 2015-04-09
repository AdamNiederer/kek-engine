using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Game
{
	public class Rectangle : Shape
	{
		static PrimitiveType Primitive = PrimitiveType.Quads;

		public Rectangle()
		{
			Coll = new BoxCollider();
		}

			
	/*	public override void Render() //TODO TODO TODO TODO TODO
		{
			if (this.Primitive != LastPrimitive) {
				Render();
			} else {
				Render();
			}

			base.Render();
			LastPrimitive = PrimitiveType.Quads;

			GL.Color3(Colour);

			GL.Vertex2 (Position.X, Position.Y);
			GL.Vertex2 (Position.X + Width, Position.Y);
			GL.Vertex2 (Position.X + Width, Position.Y - Height);
			GL.Vertex2 (Position.X, Position.Y - Height);
		} */
	}
}

