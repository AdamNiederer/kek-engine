using System;
using OpenTK;
using System.Collections.Generic;
namespace Game
{
	public class CircleCollider : Collider
	{
		public float Radius;

		public CircleCollider (Shape Parent, float Radius) : base(Parent)
		{
			if (!(Parent is Circle))
				throw new ArgumentException ("Why are you giving a non-circle a CircleCollider?");
				
			this.Radius = Radius;
		}

		protected override bool TestBox (BoxCollider c)
		{
			List<Vector2> Normals = new List<Vector2> ();
			Vector2 Projection;
			Vector2 CProjection;

			Normals.Add ((c.Parent.Points [1] - c.Parent.Points [0]).PerpendicularLeft.Normalized());
			Normals.Add ((c.Parent.Points [2] - c.Parent.Points [1]).PerpendicularLeft.Normalized());

			for (int i = 0; i < Normals.Count; i++) {
				CProjection = Collider.ProjectCollider (Normals [i], c.Parent.Points);
				Projection = new Vector2 (Vector2.Dot (Parent.Body.Position, Normals [i]), Vector2.Dot (Parent.Body.Position, Normals [i]) + Radius);
				if (CProjection.Y < Projection.X || CProjection.X > Projection.Y)
					return false;
			}
			return true;
		}

		protected override bool TestCircle (CircleCollider c)
		{
			if (this == c)
				return false;

			Vector2 l = c.Parent.Body.Position - Parent.Body.Position;
			if (l.Length <= Math.Abs (Radius) + Math.Abs (c.Radius)) {
				return true;
			}

			return false;
		}

		protected override bool TestPoly (PolyCollider c)
		{
			List<Vector2> Normals = new List<Vector2> ();
			Vector2 Projection;
			Vector2 CProjection;

			for (int i = 1; i < c.Parent.Points.Count; i++) {
				Vector2 Point2 = c.Parent.Points [i];
				Vector2 Point1 = c.Parent.Points [i - 1];
				Normals.Add ((Point2 - Point1).PerpendicularLeft.Normalized());
			}

			for (int i = 0; i < Normals.Count; i++) {
				CProjection = Collider.ProjectCollider (Normals [i], c.Parent.Points);
				Projection = new Vector2 (Vector2.Dot (Parent.Body.Position, Normals [i]), Vector2.Dot (Parent.Body.Position, Normals [i]) + Radius);
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
	}
}

