using System;
using System.Drawing;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Game;

namespace Tests
{
	public class CircleTest
	{
		public static void Test()
		{
			using (GameWindow gw = new GameWindow (800, 600, OpenTK.Graphics.GraphicsMode.Default, "Dank Game")) {
				Console.WriteLine("Hello!");

				Circle.GlobalResolution = 48;

				Game.Circle c = new Circle(Color.Yellow, true, new List<Vector2> { new Vector2(-5.0f, 0.0f) }, 1.0f);
				Game.Circle d = new Circle(Color.Yellow, true, new List<Vector2> { new Vector2(5.0f, 0.0f) }, 2.0f);

				gw.Load += (sender, e) => {
					gw.VSync = VSyncMode.Off;
				};

				gw.Resize += (sender, e) => {
					GL.Viewport (0, 0, gw.Width, gw.Height);
				};

				gw.UpdateFrame += (sender, e) => {
					foreach (Shape sh in Shape.AllShapes) {
						sh.Body.Update (0.01666666f);
						sh.Body.AddForce (new Vector2 (sh.Body.Position.X * -0.0001f, 0));
					}

					if (c.Coll.TestCollision () != null) {
						c.Colour = Color.Red;
						d.Colour = Color.Red;
					} else {
						c.Colour = Color.Yellow;
						d.Colour = Color.Yellow;
					}
				};

				gw.RenderFrame += (sender, e) => {
					GL.Clear (ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);


				//	Matrix4 modelview = Matrix4.LookAt(Vector3.UnitZ, Vector3.Zero, Vector3.UnitY);
					Matrix4 modelview = Matrix4.CreateOrthographic(20, 40*((float)gw.Height/(float)gw.Width), 1, 0);
					GL.MatrixMode(MatrixMode.Projection);
					GL.LoadMatrix(ref modelview);
					//GL.Ortho(-10, 10, -10, 10, 1, 0);

					GL.ClearColor(Color.CornflowerBlue);

					foreach (Shape sh in Shape.AllShapes) {
						if (sh.Visible) {
							sh.Render ();
						}
					}

					CircleCollider.RenderDebugVectors();
					gw.SwapBuffers();
				};

				gw.Run (60.0);
			}
		}
	}
}

