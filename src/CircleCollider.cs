using System;
using OpenTK;
using System.Collections.Generic;
namespace Game
{
	public class CircleCollider : Collider
	{
		float Radius;

		public CircleCollider (Shape Parent) : base(Parent)
		{

		}

		protected override bool TestBox (BoxCollider c)
		{
			List<Vector2> CNormals = new List<Vector2> ();
			List<Vector2> Projections = new List<Vector2> ();
			List<Vector2> CProjections = new List<Vector2> ();

			CNormals.Add (c.Parent.Points [1] - c.Parent.Points [0]);
			CNormals.Add (c.Parent.Points [2] - c.Parent.Points [1]);

			CNormals.ForEach (n => n = (n.PerpendicularLeft.Normalized ()));

			foreach (Vector2 n in CNormals) {
				Vector2 Point = Parent.Points [0] + Radius * n;
				float pDot = (Vector2.Dot (Point, n));
				float nDot = (-1 * Vector2.Dot (Point, n));
				Projections.Add (new Vector2 (nDot < pDot ? nDot : pDot, nDot < pDot ? pDot : nDot));
			}

			foreach (Vector2 n in CNormals) {
				Vector2 PendingProjection = new Vector2 (float.PositiveInfinity, float.NegativeInfinity);
				foreach (Vector2 p in c.Parent.Points) {
					float dot = Vector2.Dot (p, n);
					PendingProjection = new Vector2 (dot < PendingProjection.X ? dot : PendingProjection.X, dot > PendingProjection.Y ? dot : PendingProjection.Y);
				}
				CProjections.Add (PendingProjection);
			}

			foreach (Vector2 p in Projections) {
				foreach (Vector2 cp in CProjections) {
					if (cp.Y > p.X || cp.X > p.Y)
						return true;
				}
			}

			return false;
		}

		protected override bool TestCircle (CircleCollider c)
		{
			if (c.Parent.Points.Count > 1)
				throw new ArgumentException (); //Debug.

			Vector2 l = c.Parent.Points[0] - Parent.Points[0];
			if (l.Length > Math.Abs (Radius) + Math.Abs (c.Radius)) {
				return true;
			}
			return false;
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
				Vector2 Point = Parent.Points [0] + Radius * n;
				float pDot = (Vector2.Dot (Point, n));
				float nDot = (-1 * Vector2.Dot (Point, n));
				Projections.Add (new Vector2(nDot < pDot ? nDot : pDot, nDot < pDot ? pDot : nDot));
			}

			foreach (Vector2 n in CNormals) {
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

