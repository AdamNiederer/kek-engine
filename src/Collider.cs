using System;
using System.Collections.Generic;

namespace Game
{
	public abstract class Collider
	{
		public Shape Parent;

		public static List<Collider> AllColliders = new List<Collider> ();

		public Collider(Shape Parent)
		{
			this.Parent = Parent;
			AllColliders.Add (this);
		}

		public virtual Collider TestCollision()
		{
			foreach (Collider c in AllColliders) {
				if (c is BoxCollider)
					if (TestBox (c as BoxCollider))
						return c;
				if (c is CircleCollider)
					if (TestCircle (c as CircleCollider))
						return c;
				if (c is PolyCollider)
					if (TestPoly (c as PolyCollider))
						return c;
				else
					throw new ArgumentException ();
				}
			return null;
		}

		public virtual Collider TestCollision(Collider c)
		{
			if (c is BoxCollider)
				return TestBox (c as BoxCollider) ? c : null;
			if (c is CircleCollider)
				return TestCircle (c as CircleCollider) ? c : null;
			if (c is PolyCollider)
				return TestPoly (c as PolyCollider) ? c : null;
			else
				throw new ArgumentException ();
		}
			

		protected abstract bool TestBox (BoxCollider c);
		protected abstract bool TestCircle (CircleCollider c);
		protected abstract bool TestPoly (PolyCollider c);

		public abstract float Distance(Collider c);
		public abstract float DistanceSquared(Collider c);
	}
}