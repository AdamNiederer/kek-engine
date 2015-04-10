using System;
using OpenTK;

namespace Game
{
	public class Transform
	{
		public Vector2 Position { get; set; }
		public Vector2 Scale { get; set; }
		public float Angle { get; set; } //Stored internally in radians

		public Transform (Vector2 Position, Vector2 Scale, float Angle)
		{
			this.Position = Position;
			this.Scale = Scale;
			this.Angle = Angle;
		}

		public float AngleDegrees ()
		{
			return Angle * (180f / (float)Math.PI);
		}
	}
}