﻿using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Dexyon.MvvmCrossObjectList.Core.ViewModels;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using System.Collections.Generic;

namespace Dexyon.MvvmCrossObjectList.Touch {
	public partial class ExampleOverviewView : MvxViewController {
		public ExampleOverviewView () : base ( "ExampleOverviewView", null ) {
		}

		public new ExampleOverviewViewModel ViewModel {
			get { return (ExampleOverviewViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}

		public override void DidReceiveMemoryWarning () {
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad () {
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
			/*var source = new MvxStandardTableViewSource(
				TableView,
				UITableViewCellStyle.Subtitle,
				new NSString("ExampleOverviewView"),
				"TitleText Description;DetailText Value",
				UITableViewCellAccessory.DisclosureIndicator);

			this.AddBindings(
				new Dictionary<object, string>()
				{
					{ source, "ItemsSource ExampleViewModel" }
				});

			TableView.Source = source;
			TableView.ReloadData();*/

			var source = new 
				MvxSimpleTableViewSource(
					TableView, 
					ExampleOverviewTableCell.Key, 
					ExampleOverviewTableCell.Key);
			TableView.Source = source;

			this.CreateBinding(source)
				.To<ExampleOverviewViewModel>(vm => vm.ExampleViewModel)
				.Apply();

			// Perform our MVVM Binding
			var set = this.CreateBindingSet<ExampleOverviewView, ExampleOverviewViewModel> ();

			set.Bind ( source )
				.To ( vm => vm.ExampleViewModel );

			set.Apply ();
			TableView.ReloadData ();
		}
	}
}

