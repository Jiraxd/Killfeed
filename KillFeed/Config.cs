using System;
using Rocket.API;

namespace KillFeed
{
	public class Config : IRocketPluginConfiguration, IDefaultable
	{
		public void LoadDefaults()
		{
		}

		public ushort Size = 25;
	}
}
