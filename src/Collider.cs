using System;
using System.Collections.Generic;

namespace Game
{
	public abstract class Collider
	{
		Object Parent { get; set; }

		public static List<Collider> AllColliders { get; set; }

		public Collider(Object Parent)
		{
			this.Parent = Parent;
			AllColliders.Add (this);
		}

		public virtual Collider TestCollision()
		{
			foreach (Collider c in AllColliders) {
				if (c is BoxCollider)
					return TestBox (c) ? c : null;
				if (c is CircleCollider)
					return TestCircle (c) ? c : null;
				if (c is TriangleCollider)
					return TestTriangle (c) ? c : null;
				if (c is PolyCollider)
					return TestPoly (c) ? c : null;
				else
					throw new NotImplementedException ();
				}
			return null;
		}

		protected abstract bool TestBox (Collider c);
		protected abstract bool TestCircle (Collider c);
		protected abstract bool TestTriangle (Collider c);
		protected abstract bool TestPoly (Collider c);

		public abstract float Distance(Collider c);
		public abstract float DistanceSquared(Collider c);
	}
}