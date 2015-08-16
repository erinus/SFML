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

		static void Main(string[] args)
		{
			Texture textureBack = new Texture(File.ReadAllBytes(@"assets/back.png"));

			textureBack.Smooth = true;

			Sprite spriteBack = new Sprite(textureBack, new IntRect(0, 0, 800, 500));

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

			window.SetMouseCursorVisible(true);

			window.SetVerticalSyncEnabled(false);

			window.Closed += new EventHandler(
				delegate(object sender, EventArgs e)
				{
					
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
					}
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

			while (window.IsOpen)
			{
				window.DispatchEvents();

				window.Clear();

				window.Draw(spriteBack);

				foreach (Sprite icon in icons)
				{
					window.Draw(icon);
				}

				window.Display();
			}
		}
	}
}
