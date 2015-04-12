using System;
using System.Drawing;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Game;

namespace Tests
{
	public class ColliderTest
	{
		public static void Test()
		{
			using (GameWindow gw = new GameWindow (800, 600, OpenTK.Graphics.GraphicsMode.Default, "Dank Game")) {
			
				Game.Circle c = new Circle(Color.Yellow, true, new List<Vector2> { new Vector2(-5.0f, 0.0f) }, 8.0f);
				Game.Circle d = new Circle(Color.Yellow, true, new List<Vector2> { new Vector2(5.0f, 0.0f) }, 2.0f);

				if (c.Coll.TestCollision() != null) {
					Console.WriteLine("Intersection of r and s!");
				}
			}
		}
	}
}