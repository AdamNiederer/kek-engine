using System;
using System.Drawing;
using System.Collections.Generic;
using OpenTK;

namespace Game
{
	public class Rigidbody
	{
		Shape Parent;

		public Vector2 Position;			//	Meters						<i,j>	Location of the Center of Mass
		public Vector2 Velocity;			//	Meters per Second			<i,j>	Velocity of Object
		public Vector2 Acceleration;		//	Meters per Second Squared	<i,j>	Acceleration of Object
		public Vector2 Momentum;			// 	Kilograms Meters per Second	<i,j>	Momentum of Object
		public Vector2 Energy;				// 	Joules						<i,j>	Kinetic Energy of Object

		public float Restitution;			//	Coefficient of Restitution
		public float Friction;				//	Coefficient of Friction

		public float Mass;					//	Kilograms
		public float RotationalInertia;		//	Kilograms Meters

		public float AngularVelocity;		//	Radians per Second
		public float AngularAcceleration;	//	Radians per Second Squared
		public float Angle; 				//	Radians

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

