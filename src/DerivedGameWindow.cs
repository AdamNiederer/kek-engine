using System;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using OpenTK.Input;
using OpenTK;

namespace Game
{
	public class DerivedGameWindow : GameWindow
	{
		public DerivedGameWindow ()
		{

		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			Title = "Dank Game";
			GL.ClearColor (Color.CornflowerBlue);
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);

			Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1.0f, 64.0f);
			GL.MatrixMode(MatrixMode.Projection);
			GL.LoadMatrix(ref projection);
		}

		protected override void OnUpdateFrame(FrameEventArgs e)
		{
			base.OnUpdateFrame(e);

			if (OpenTK.Input.Keyboard.GetState()[Key.Escape])
				Exit();
		}

		protected override void OnRenderFrame(FrameEventArgs e)
		{
			base.OnRenderFrame(e);
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

			Matrix4 modelview = Matrix4.LookAt(Vector3.Zero, -1*Vector3.UnitZ, Vector3.UnitY);
			GL.MatrixMode(MatrixMode.Projection);
			GL.LoadMatrix(ref modelview);

			Rectangle r = new Rectangle (.5f, .2f, Vector2.Zero, Color.Red);
			Rectangle p = new Rectangle (.2f, .8f, new Vector2 (-1.0f, 1.0f), Color.PaleGreen);

			foreach (var i in Renderable.RenderQueue) {
				i.Render ();
			}

			r.Free();
			p.Free();

			SwapBuffers();
		}


	}
}
	