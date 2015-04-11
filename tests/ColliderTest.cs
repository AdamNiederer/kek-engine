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
				Game.Rectangle r = new Game.Rectangle (new List<Vector2> {
					new Vector2 (4.0f, -1.0f),
					new Vector2 (4.0f, 1.0f),
					new Vector2 (5.0f, 1.0f),
					new Vector2 (5.0f, -1.0f),
				}, Color.Purple, true);

				Game.Rectangle s = new Game.Rectangle (new List<Vector2> {
					new Vector2 (-4.0f, -1.0f),
					new Vector2 (-4.0f, 1.0f),
					new Vector2 (-5.0f, 1.0f),
					new Vector2 (-5.0f, -1.0f),
				}, Color.LawnGreen, true);

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

					if (r.Coll.TestCollision () != null) {
						r.Colour = Color.Yellow;
						s.Colour = Color.CornflowerBlue;
					}
				};

				gw.RenderFrame += (sender, e) => {
					GL.Clear (ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

					Matrix4 modelview = Matrix4.LookAt(Vector3.UnitZ, -1*Vector3.UnitZ, Vector3.UnitY);
					GL.MatrixMode(MatrixMode.Projection);
					GL.LoadMatrix(ref modelview);
					GL.Ortho(-5, 5, -5, 5, -1, 1);

					foreach (Shape sh in Shape.AllShapes) {
						if (sh.Visible) {
							sh.Render ();
						}
					}

					gw.SwapBuffers ();
				};

				gw.Run (60.0);
			}
		}
	}
}