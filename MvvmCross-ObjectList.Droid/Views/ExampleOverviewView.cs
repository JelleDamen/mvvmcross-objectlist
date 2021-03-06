﻿using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.Binding.Droid.Views;
using MvvmCrossObjectList.Droid.UILib;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;

namespace Dexyon.MvvmCrossObjectList.Droid {
	[Activity ( Label = "ExampleOverviewView.Droid", MainLauncher = true )]
	public class ExampleOverviewView : MvxActivity {

		ObjectListAdapter adapter;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			adapter = new ObjectListAdapter (this.BaseContext, (IMvxAndroidBindingContext)this.BindingContext);

			//One layout to rule them all
			adapter.Setup (new System.Collections.Generic.List<TemplateSelector> ()
				{ 
					new TemplateSelector((c)=>c.IsReadOnly,Resource.Layout.ListItem_ReadOnly),
					//new TemplateSelector((c)=>c.ValueType == typeof(bool),Resource.Layout.ListItem_Bool),
					new TemplateSelector((c)=>c.ValueType == typeof(DateTime),Resource.Layout.ListItem_DatePicker),
					new TemplateSelector((c)=>true,Resource.Layout.ListItem_TextEdit)
				}
			);

			// Set our view from the "main" layout resource
			SetContentView ( Resource.Layout.Main );

			var list = FindViewById<MvxListView> (Resource.Id.PersonList);
			list.Adapter = adapter;
		}
		 
		protected override void OnViewModelSet()
		{

		}
	}
}


