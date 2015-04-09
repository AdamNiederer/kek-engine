using System;

namespace Game
{
	public class TriangleCollider : Collider
	{
		public TriangleCollider (Object Parent) : base(Parent)
		{

		}

		protected override bool TestBox (Collider c)
		{
			return false;
		}
		protected override bool TestCircle (Collider c)
		{
			return false;
		}
		protected override bool TestTriangle (Collider c)
		{
			return false;
		}
		protected override bool TestPoly (Collider c)
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

