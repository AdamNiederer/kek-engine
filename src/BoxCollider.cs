using System;
using OpenTK;
using System.Collections.Generic;

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

