using System;
using System.Timers;
using OpenTK;

namespace Game
{
	public class Rigidbody
	{
		Shape Parent;

		Vector2 Velocity { get; set; }
		Vector2 Acceleration { get; set; }

		float Mass { get; set; }				//	Mass of the object
		float Restitution { get; set; }			//	Coefficient of Restitution
		float Friction { get; set; }			//	Coefficient of Friction
		float Torque { get; set; } 				//	As in Physics, a positive torque is counter-clockwise.
		float RotationalInertia { get; set; }	//	
		float AngularVelocity { get; set; }		//	
		float AngularAcceleration { get; set; }	//	

		public Rigidbody(Shape s)
		{
			this.Parent = s;
		}

		public virtual void AddForce (Vector2 Force, Vector2 CenterOffset)
		{
			Acceleration += Force / Mass;
			Torque += -1 * Force.X * CenterOffset.Y;
			Torque += -1 * Force.Y * CenterOffset.X;
		}

		public virtual void AddForce (Vector2 Force)
		{
			Acceleration += Force / Mass;
		}

		public virtual void Update(float Time)
		{
			Velocity += Acceleration * Time;
			AngularVelocity += AngularAcceleration * Time;

			Parent.Trans.Angle += AngularVelocity;
			Parent.Trans.Position += Velocity;


		}
	}
}

