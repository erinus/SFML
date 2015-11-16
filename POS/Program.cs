using System;
using System.Collections.Generic;
using System.IO;

using SFML;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace com.erinus.SFML.POS
{
	class Program
	{
		static List<Sprite> icons;

		private static int row = 0;

		private static int col = 0;

		static void Main(string[] args)
		{
			Texture textureBack = new Texture(File.ReadAllBytes(@"assets/back.png"));

			textureBack.Smooth = true;

			Sprite spriteBack = new Sprite(textureBack, new IntRect(0, 0, 800, 500));

			Texture textureLock = new Texture(File.ReadAllBytes(@"assets/lock.png"));

			textureLock.Smooth = true;

			Sprite spriteLock = new Sprite(textureLock, new IntRect(0, 0, 80, 80));

			spriteLock.Position = new Vector2f(76, 68);

			icons = new List<Sprite>();

			for (int index = 0; index < 15; index++)
			{
				int col = index % 5;

				int row = (index - col) / 5;

				Texture textureIcon = new Texture(File.ReadAllBytes(String.Format(@"assets/buttons/{0:00}.png", index + 1)));

				textureIcon.Smooth = true;

				Sprite spriteIcon = new Sprite(textureIcon, new IntRect(0, 0, 72, 72));

				spriteIcon.Position = new Vector2f(80 + col * 72 + col * 70, 72 + row * 72 + row * 70);

				icons.Add(spriteIcon);
			}

			ContextSettings context = new ContextSettings();

			context.DepthBits = 32;

			RenderWindow window = new RenderWindow(new VideoMode(800, 500), String.Empty, Styles.Default, context);

			window.SetActive();

			window.SetVisible(true);

			window.SetKeyRepeatEnabled(true);

			window.SetMouseCursorVisible(true);

			window.SetVerticalSyncEnabled(false);

			window.Closed += new EventHandler(
				delegate(object sender, EventArgs e)
				{
					window.Close();

					window.Dispose();
				}
			);

			window.GainedFocus += new EventHandler(
				delegate(object sender, EventArgs e)
				{

				}
			);

			window.LostFocus += new EventHandler(
				delegate(object sender, EventArgs e)
				{

				}
			);

			window.KeyPressed += new EventHandler<KeyEventArgs>(
				delegate(object sender, KeyEventArgs e)
				{
					if (e.Code == Keyboard.Key.Escape)
					{
						/*
						sound.Stop();

						sound.Dispose();

						buffer.Dispose();
						*/

						window.Close();

						window.Dispose();
					}

					if (e.Code == Keyboard.Key.Right)
					{
						if (col < 4)
						{
							col += 1;
						}
					}

					if (e.Code == Keyboard.Key.Left)
					{
						if (col > 0)
						{
							col -= 1;
						}
					}

					if (e.Code == Keyboard.Key.Up)
					{
						if (row > 0)
						{
							row -= 1;
						}
					}

					if (e.Code == Keyboard.Key.Down)
					{
						if (row < 2)
						{
							row += 1;
						}
					}

					spriteLock.Position = new Vector2f(80 + col * 72 + col * 70 - 4, 72 + row * 72 + row * 70 - 4);
				}
			);

			window.KeyReleased += new EventHandler<KeyEventArgs>(
				delegate(object sender, KeyEventArgs e)
				{

				}
			);

			window.TouchBegan += new EventHandler<TouchEventArgs>(
				delegate(object sender, TouchEventArgs e)
				{

				}
			);

			window.TouchEnded += new EventHandler<TouchEventArgs>(
				delegate(object sender, TouchEventArgs e)
				{

				}
			);

			window.TouchMoved += new EventHandler<TouchEventArgs>(
				delegate(object sender, TouchEventArgs e)
				{

				}
			);

			window.JoystickConnected += new EventHandler<JoystickConnectEventArgs>(
				delegate(object sender, JoystickConnectEventArgs e)
				{

				}
			);

			window.JoystickDisconnected += new EventHandler<JoystickConnectEventArgs>(
				delegate(object sender, JoystickConnectEventArgs e)
				{

				}
			);

			window.JoystickButtonPressed += new EventHandler<JoystickButtonEventArgs>(
				delegate(object sender, JoystickButtonEventArgs e)
				{
					//File.AppendAllText(@"joystick.log", Convert.ToString(e.Button) + ":JoystickButtonPressed\n");

					// A		0
					// B		1
					// X		2
					// Y		3
					// BACK		6
					// START	7
				}
			);

			window.JoystickButtonReleased += new EventHandler<JoystickButtonEventArgs>(
				delegate(object sender, JoystickButtonEventArgs e)
				{
					//File.AppendAllText(@"joystick.log", Convert.ToString(e.Button) + ":JoystickButtonReleased\n");
				}
			);

			window.JoystickMoved += new EventHandler<JoystickMoveEventArgs>(
				delegate(object sender, JoystickMoveEventArgs e)
				{
					//File.AppendAllText(@"joystick.log", Convert.ToString(e.Axis) + ":" + Convert.ToString(e.JoystickId) + ":" + Convert.ToString(e.Position) + "\n");

					// RIGHT	PovX	+100
					// LEFT		PovX	-100
					if (e.Axis == Joystick.Axis.PovX)
					{
						if (e.Position.Equals(+100.0f))
						{
							// RIGHT
							if (col < 4)
							{
								col += 1;
							}
						}

						if (e.Position.Equals(-100.0f))
						{
							// LEFT
							if (col > 0)
							{
								col -= 1;
							}
						}
					}

					// UP		PovY	+100
					// DOWN		PovY	-100
					if (e.Axis == Joystick.Axis.PovY)
					{
						if (e.Position.Equals(+100.0f))
						{
							// UP
							if (row > 0)
							{
								row -= 1;
							}
						}

						if (e.Position.Equals(-100.0f))
						{
							// DOWN
							if (row < 2)
							{
								row += 1;
							}
						}
					}

					spriteLock.Position = new Vector2f(80 + col * 72 + col * 70 - 4, 72 + row * 72 + row * 70 - 4);
				}
			);

			while (window.IsOpen)
			{
				window.DispatchEvents();

				window.Clear();

				window.Draw(spriteBack);

				foreach (Sprite icon in icons)
				{
					window.Draw(icon);
				}

				window.Draw(spriteLock);

				window.Display();
			}
		}
	}
}
