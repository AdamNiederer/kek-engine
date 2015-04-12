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
		static List<Vector2> DebugVectors = new List<Vector2>();

		public BoxCollider (Shape Parent) : base(Parent)
		{

		}

		protected override bool TestBox (BoxCollider c)
		{
			if (this == c)
				return false;

			List<Vector2> Normals = new List<Vector2> ();
			Vector2 Projection;
			Vector2 CProjection;

			Normals.Add ((Parent.Points [1] - Parent.Points [0]).PerpendicularLeft.Normalized());
			Normals.Add ((Parent.Points [2] - Parent.Points [1]).PerpendicularLeft.Normalized());

			Normals.Add ((c.Parent.Points [1] - c.Parent.Points [0]).PerpendicularLeft.Normalized());
			Normals.Add ((c.Parent.Points [2] - c.Parent.Points [1]).PerpendicularLeft.Normalized());

			for (int i = 0; i < Normals.Count; i++) {
				CProjection = Collider.ProjectCollider (Normals [i], c.Parent.Points);
				Projection = Collider.ProjectCollider (Normals [i], Parent.Points);
				if (CProjection.Y < Projection.X || CProjection.X > Projection.Y)
					return false;
			} 
			return true;
		}

		protected override bool TestCircle (CircleCollider c)
		{
			List<Vector2> Normals = new List<Vector2> ();
			Vector2 Projection;
			Vector2 CProjection;

			Normals.Add ((Parent.Points [1] - Parent.Points [0]).PerpendicularLeft.Normalized());
			Normals.Add ((Parent.Points [2] - Parent.Points [1]).PerpendicularLeft.Normalized());

			for (int i = 0; i < Normals.Count; i++) {
				Projection = Collider.ProjectCollider (Normals [i], Parent.Points);
				CProjection = new Vector2 (Vector2.Dot(c.Parent.Body.Position, Normals[i]) - c.Radius, Vector2.Dot(c.Parent.Body.Position, Normals[i]) + c.Radius);
				if (CProjection.Y < Projection.X || CProjection.X > Projection.Y)
					return false;
			}
			return true;
		}

		protected override bool TestPoly (PolyCollider c)
		{
			List<Vector2> Normals = new List<Vector2> ();
			Vector2 Projection;
			Vector2 CProjection;

			Normals.Add ((Parent.Points [1] - Parent.Points [0]).PerpendicularLeft.Normalized());
			Normals.Add ((Parent.Points [2] - Parent.Points [1]).PerpendicularLeft.Normalized());

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
	}
}

