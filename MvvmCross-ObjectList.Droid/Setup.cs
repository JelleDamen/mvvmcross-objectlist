﻿using Cirrious.MvvmCross.Droid.Platform;
using Android.Content;
using Cirrious.MvvmCross.ViewModels;

namespace Dexyon.MvvmCrossObjectList.Droid {
	public class Setup : MvxAndroidSetup
	{
		public Setup(Context applicationContext) : base(applicationContext)
		{
		}

		protected override IMvxApplication CreateApp()
		{
			return new Core.App();
		}
	}
}
