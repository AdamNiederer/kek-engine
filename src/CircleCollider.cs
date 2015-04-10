using System;

namespace Game
{
	public class CircleCollider : Collider
	{
		public CircleCollider (Object Parent) : base(Parent)
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

		protected override bool TestTriangle (TriangleCollider c)
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

