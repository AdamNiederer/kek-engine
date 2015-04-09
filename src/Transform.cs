using System;
using OpenTK;

namespace Game
{
	public class Transform
	{
		public Vector2 Position { get; set; }
		public Vector2 Scale { get; set; }
		public float Angle { get; set; } //Stored internally in radians

		public float AngleDegrees()
		{
			return Angle * (180f / (float)Math.PI);
		}
	}
}