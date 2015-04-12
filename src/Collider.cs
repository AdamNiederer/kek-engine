using System;
using System.Collections.Generic;
using OpenTK;

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

		public virtual List<Collider> TestCollision()
		{
			List<Collider> Collisions = new List<Collider> ();
			foreach (Collider c in AllColliders) {
				if (c is BoxCollider) {
					if (TestBox (c as BoxCollider))
						Collisions.Add (c);
				} else 
				if (c is CircleCollider) {
					if (TestCircle (c as CircleCollider))
						Collisions.Add (c);
				} else
				if (c is PolyCollider) {
					if (TestPoly (c as PolyCollider))
						Collisions.Add (c);
				} else
					throw new ArgumentException ();
			}
			return Collisions.Count > 0 ? Collisions : null;
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

		public static Vector2 ProjectCollider(Vector2 Axis, List<Vector2> Points) 
		{
			float min = float.PositiveInfinity;
			float max = float.NegativeInfinity;
			for (int i = 0; i < Points.Count; i++) {
				float dot = Vector2.Dot(Axis, Points[i]);
				if (dot < min)
					min = dot;
				if(dot > max)
					max = dot;
			}
			return new Vector2 (min, max);
		}
			

		protected abstract bool TestBox (BoxCollider c);
		protected abstract bool TestCircle (CircleCollider c);
		protected abstract bool TestPoly (PolyCollider c);

		public abstract float Distance(Collider c);
		public abstract float DistanceSquared(Collider c);
	}
}