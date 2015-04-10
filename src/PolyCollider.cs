using System;
using System.Collections.Generic;
using OpenTK;

namespace Game
{
	public class PolyCollider : Collider
	{
		List<Vector2> Points;

		public PolyCollider (Object Parent, List<Vector2> Points) : base(Parent)
		{
			this.Points = Points;
		}

		protected override bool TestBox (BoxCollider c)
		{
			return false;
		}

		protected override bool TestCircle (CircleCollider c)
		{
			return false;
		}

		protected override bool TestTriangle (TriangleCollider c)
		{
			return false;
		}
			
		public Vector2 ProjectCollider(Vector2 Axis, List<Vector2> Points) 
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

			for (int i = 1; i < Points.Count; i++) {
				Vector2 Point2 = Points [i];
				Vector2 Point1 = Points [i - 1];
				Normals.Add ((Point2 - Point1).PerpendicularLeft.Normalized());
			}
				
			for (int i = 1; i < c.Points.Count; i++) {
				Vector2 Point2 = Points [i];
				Vector2 Point1 = Points [i - 1];
				CNormals.Add ((Point2 - Point1).PerpendicularLeft.Normalized());
			}

			foreach (Vector2 n in Normals) {
				Projections.Add (ProjectCollider (n, Points));
			}

			foreach (Vector2 n in CNormals) {
				CProjections.Add (ProjectCollider (n, Points));
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

