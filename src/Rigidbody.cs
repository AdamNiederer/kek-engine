using System;
using System.Timers;
using System.Collections.Generic;
using OpenTK;

namespace Game
{
	public class Rigidbody
	{
		Shape Parent;

		Vector2 Position;			//	Meters						<i,j>	Location of the Center of Mass
		Vector2 Velocity;			//	Meters per Second			<i,j>	Velocity of Object
		Vector2 Acceleration;		//	Meters per Second Squared	<i,j>	Acceleration of Object
		Vector2 Momentum;			// 	Kilograms Meters per Second	<i,j>	Momentum of Object
		Vector2 Energy;				// 	Joules						<i,j>	Kinetic Energy of Object

		float Restitution;			//	Coefficient of Restitution
		float Friction;				//	Coefficient of Friction

		float Mass;					//	Kilograms
		float RotationalInertia;	//	Kilograms Meters

		float AngularVelocity;		//	Radians per Second
		float AngularAcceleration;	//	Radians per Second Squared
		float Angle; 				//	Radians

		public Rigidbody(Shape s)
		{
			this.Parent = s;
			this.Position = Center (Parent.Points);
			this.Restitution = 1;
			this.Friction = 0;
			this.Mass = 1;
			this.RotationalInertia = 1;
		}

		public Rigidbody(Shape s, Vector2 Center)
		{
			this.Parent = s;
			this.Position = Center;
			this.Restitution = 1;
			this.Friction = 0;
			this.Mass = 1;
			this.RotationalInertia = 1;
		}

		static Vector2 Center(List<Vector2> Points)
		{
			Vector2 Result = new Vector2 (0, 0);
			foreach (Vector2 p in Points) {
				Result += p;
			}
			return Result / Points.Count;
		}

		public virtual void AddForce (Vector2 Force, Vector2 Offset)
		{
			Acceleration += Force / Mass;
			AngularAcceleration += -1 * Force.X * Offset.Y - Force.Y * Offset.X;
		}

		public virtual void AddForce (Vector2 Force)
		{
			Acceleration += Force / Mass;
		}

		public virtual void Update(float Time)
		{
			Velocity += Acceleration * Time;
			AngularVelocity += AngularAcceleration * Time;
			Angle += AngularVelocity;
			Position += Velocity;

			Acceleration *= (1 - Friction) / Mass;

			for(int i = 0; i < Parent.Points.Count; i++) {
				Parent.Points[i] += Velocity;
				//Parent.Points[i] += new Vector2 ((float)(Position.X + (Parent.Points[i].X - Position.X) * Math.Cos (Angle) - (Parent.Points[i].Y - Position.Y) * Math.Sin (Angle)), (float)(Position.Y + (Parent.Points[i].X - Position.X) * Math.Sin (Angle) + (Parent.Points[i].Y - Position.Y) * Math.Cos (Angle)));
			}
		}
	}
}

