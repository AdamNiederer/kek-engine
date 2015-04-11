using System;
using System.Drawing;
using System.Collections.Generic;
using OpenTK;

//DEBUG
using OpenTK.Graphics.OpenGL;

namespace Game
{
	public class BoxCollider : Collider
	{
		List<Vector2> Points = new List<Vector2>();

		public BoxCollider (Shape Parent) : base(Parent)
		{

		}

		protected override bool TestBox (BoxCollider c)
		{

			List<Vector2> Normals = new List<Vector2> (); //List of unit vectors normal to the sides
			List<Vector2> CNormals = new List<Vector2> (); //List of unit vectors normal to the sides
			List<Vector2> Projections = new List<Vector2> ();
			List<Vector2> CProjections = new List<Vector2> ();

			for (int i = 1; i < Parent.Points.Count; i++) {
				Vector2 Point2 = Parent.Points [i];
				Vector2 Point1 = Parent.Points [i - 1];
				Normals.Add ((Point2 - Point1).PerpendicularLeft.Normalized());
			}

			for (int i = 1; i < c.Parent.Points.Count; i++) {
				Vector2 Point2 = Parent.Points [i];
				Vector2 Point1 = Parent.Points [i - 1];
				CNormals.Add ((Point2 - Point1).PerpendicularLeft.Normalized());
			}

			foreach (Vector2 n in Normals) {
				GL.Begin (PrimitiveType.Lines); GL.Color3 (Color.Orange); GL.Vertex2 (0, 0); GL.Vertex2 (n); GL.End ();
				Projections.Add (PolyCollider.ProjectCollider (n, Parent.Points));
			}

			foreach (Vector2 n in CNormals) {
				GL.Begin (PrimitiveType.Lines); GL.Color3 (Color.White); GL.Vertex2 (0, 0); GL.Vertex2 (n); GL.End ();
				CProjections.Add (PolyCollider.ProjectCollider (n, Parent.Points));
			}

			foreach (Vector2 p in Projections) {
				foreach(Vector2 cp in CProjections) {
					if(cp.Y > p.X || cp.X > p.Y)
						return true;
				}
			}

			return false;
		}

		protected override bool TestCircle (CircleCollider c)
		{
			return false;
		}

		protected override bool TestPoly (PolyCollider c)
		{
			return false;
		}

		public override float Distance(Collider c)
		{
			return 0.0f;
		}

		public override float DistanceSquared(Collider c)
		{
			return 0.0f;
		}
	}
}

