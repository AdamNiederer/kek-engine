using System;
using OpenTK;

namespace Game
{
	public class Transform
	{
		public Vector2 Position { get; set; }
		public Vector2 Scale { get; set; }
		float Angle { get; set; } //Stored internally in radians

		public float AngleDegrees()
		{
			return Angle * (180 / Math.PI);
		}
	}
}