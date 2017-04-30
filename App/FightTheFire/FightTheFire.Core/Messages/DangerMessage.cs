using System;
using MvvmCross.Plugins.Messenger;
using Domain;

namespace FightTheFire.Core.Messages
{
	public class DangerMessage : MvxMessage
	{
		public DangerMessage(object sender, FireDangerResponse dangerReport) : base(sender)
		{
			DangerReport = dangerReport;
		}

		public FireDangerResponse DangerReport { get; private set; }
	}
}