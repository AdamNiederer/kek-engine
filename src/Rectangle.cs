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

		public Rectangle(Color Colour, bool Visible) : base(Colour, Visible)
		{
			Coll = new BoxCollider(this);
		}


			
		public override void Render() //TODO TODO TODO TODO TODO
		{
			LastPrimitive = PrimitiveType.Quads;

			GL.Color3(Colour);

			//GL.Vertex2 (Position.X, Position.Y);
			//GL.Vertex2 (Position.X + Width, Position.Y);
			//GL.Vertex2 (Position.X + Width, Position.Y - Height);
			//GL.Vertex2 (Position.X, Position.Y - Height);
		} 
	}
}

