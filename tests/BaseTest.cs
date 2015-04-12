using System;
using System.Drawing;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Game;
/*
  * 
  * Unnamed rendering/physics engine. Copyright Adam Niederer 2015.
  * Licensed under the LGPL v3. This project uses OpenTK for a large portion of its code. Find it at http://opentk.com
  * OpenTK is licensed under the MIT License. You may find it at http://www.opentk.com/project/license
  * 
  * This project is currently a shell. Intended specification includes both accurate physical calculations for bodies and OpenGL-based real-time rendering
  * 
  */

/*
	BaseTest: A simple check when everything else fails
	Objects: Shape, RigidBody, Collider, Rectangle
	Methods: Render(); Update(); 
	Expected Result: The polygon accelerates to the right.
	Anomalies: The Rectangle is technically a polygon, and the BoxCollider will not work in this case.
*/

namespace Tests
{
	public class BaseTest
	{
		static void Main()
		{
			CircleTest.Test ();
		}

		public static void Test()
		{
			using (GameWindow gw = new GameWindow (800, 600, OpenTK.Graphics.GraphicsMode.Default, "Dank Game")) {
				Game.Rectangle r = new Game.Rectangle (new List<Vector2> {
					new Vector2 (0.0f, 0.0f),
					new Vector2 (0.0f, 1.0f),
					new Vector2 (0.9f, 0.9f),
					new Vector2 (1.0f, 0.0f),
				}, Color.Purple, true);

				gw.Load += (sender, e) => {
					gw.VSync = VSyncMode.On;

				};

				gw.Resize += (sender, e) => {
					GL.Viewport (0, 0, gw.Width, gw.Height);
				};

				gw.UpdateFrame += (sender, e) => {
					r.Body.AddForce(new Vector2(0.01f, 0));
					r.Body.Update(1f/60f);
				};

				gw.RenderFrame += (sender, e) => {
					GL.Clear (ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
				
					Matrix4 modelview = Matrix4.LookAt(Vector3.UnitZ, -1*Vector3.UnitZ, Vector3.UnitY);
					GL.MatrixMode(MatrixMode.Projection);
					GL.LoadMatrix(ref modelview);
					GL.Ortho(-5, 5, -5, 5, -1, 1);

					foreach (Shape s in Shape.AllShapes) {
						if (s.Visible) {
							s.Render ();
						}
					}

					gw.SwapBuffers ();
				};
					
				gw.Run (60.0);
			}
		}
	}
}