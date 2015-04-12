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

		protected override bool TestPoly (PolyCollider c)
		{
			if (this == c)
				return false;

			List<Vector2> Normals = new List<Vector2> ();
			Vector2 Projection;
			Vector2 CProjection;

			for (int i = 1; i < Parent.Points.Count; i++) {
				Vector2 Point2 = Parent.Points [i];
				Vector2 Point1 = Parent.Points [i - 1];
				Normals.Add ((Point2 - Point1).PerpendicularLeft.Normalized());
			}
			for (int i = 1; i < c.Parent.Points.Count; i++) {
				Vector2 Point2 = c.Parent.Points [i];
				Vector2 Point1 = c.Parent.Points [i - 1];
				Normals.Add ((Point2 - Point1).PerpendicularLeft.Normalized());
			}

			for (int i = 0; i < Normals.Count; i++) {
				CProjection = Collider.ProjectCollider (Normals [i], c.Parent.Points);
				Projection = Collider.ProjectCollider (Normals [i], Parent.Points);
				if (CProjection.Y < Projection.X || CProjection.X > Projection.Y)
					return false;
			} 
			return true;
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

