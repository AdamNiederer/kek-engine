using System;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

 /*
  * 
  * Unnamed rendering/physics engine. Copyright Adam Niederer 2015.
  * Licensed under the LGPL v3. This project uses OpenTK for a large portion of its code. Find it at http://opentk.com
  * OpenTK is licensed under the MIT License. You may find it at http://www.opentk.com/project/license
  * 
  * This project is currently a shell. Intended specification includes both accurate physical calculations for bodies and OpenGL-based real-time rendering
  * 
  */

namespace Game
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			using (DerivedGameWindow gameWindow = new DerivedGameWindow ()) {
				gameWindow.Run (60.0);
			}
		}
	}
}
