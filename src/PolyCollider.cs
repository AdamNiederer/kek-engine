using System;
using System.Drawing;
using System.Collections.Generic;
using OpenTK;

namespace Game
{
	public class PolyCollider : Collider
	{
		public PolyCollider (Shape Parent) : base(Parent)
		{

		}

		protected override bool TestBox (BoxCollider c)
		{
			return false;
		}

		protected override bool TestCircle (CircleCollider c)
		{
			return false;
		}
			
		public static Vector2 ProjectCollider(Vector2 Axis, List<Vector2> Points) 
		{
			float min = float.NegativeInfinity;
			float max = float.PositiveInfinity;
			for (int i = 0; i < Points.Count; i++) {
				float dot = Vector2.Dot(Axis, Points[i]);
				if (dot < min)
					min = dot;
				if(dot > max)
					max = dot;
			}
			return new Vector2 (min, max);
		}

		protected override bool TestPoly (PolyCollider c)
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
				Projections.Add (ProjectCollider (n, Parent.Points));
			}

			foreach (Vector2 n in CNormals) {
				CProjections.Add (ProjectCollider (n, Parent.Points));
			}

			foreach (Vector2 p in Projections) {
				foreach(Vector2 cp in CProjections) {
					if(cp.Y > p.X || cp.X > p.Y)
						return true;
				}
			}

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

		public void Update()
		{

		}
	}
}

