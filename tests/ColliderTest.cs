using System;
using System.Drawing;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Game;

/*
	ColliderTest: A headless test to ensure collisions are working.
	Objects: Shape, Collider, Rectangle, Circle, BoxCollider, CircleCollider
	Methods: TestCollision() and derivatives
	Expected Result: The Circles c and d will intersect, while the rectangles will not.
	Anomalies: None Known.
*/

namespace Tests
{
	public class ColliderTest
	{
		public static void Test()
		{
			using (GameWindow gw = new GameWindow (800, 600, OpenTK.Graphics.GraphicsMode.Default, "Dank Game")) {
			
				Circle.GlobalResolution = 12;

				Game.Circle c = new Circle(Color.Yellow, true, new List<Vector2> { new Vector2(-5.0f, 0.0f) }, 8.0f);
				Game.Circle d = new Circle(Color.Yellow, true, new List<Vector2> { new Vector2(5.0f, 0.0f) }, 2.0f);

				Game.Rectangle r = new Game.Rectangle (new List<Vector2> {
					new Vector2 (2.0f, -2.0f),
					new Vector2 (4.0f, -2.0f),
					new Vector2 (4.0f, 2.0f),
					new Vector2 (2.0f, 2.0f),
				}, Color.Purple, true);

				Game.Rectangle s = new Game.Rectangle (new List<Vector2> {
					new Vector2 (-4.0f, -2.0f),
					new Vector2 (-2.0f, -2.0f),
					new Vector2 (-2.0f, 2.0f),
					new Vector2 (-4.0f, 2.0f),
				}, Color.Purple, true);
					
				foreach (Collider i in c.Coll.TestCollision()) {
					if (i.Parent is Circle) {
						Console.WriteLine("Intersection of c and d!");
					}
				}

				foreach (Collider i in r.Coll.TestCollision()) {
					if (i.Parent is Game.Rectangle) {
						Console.WriteLine("Intersection of r and s!");
					}
				}
			}
		}
	}
}