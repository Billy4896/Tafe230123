using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainMenu : Page
	{
		public MainMenu()
		{
			this.InitializeComponent();
		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void mathCalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			// Navigate to MainMenu.xaml
			this.Frame.Navigate(typeof(MainPage));
		}

		private void mortgageCalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			// Navigate to MainMenu.xaml
			this.Frame.Navigate(typeof(mortgage_calculator));
		}

		private void currencyCalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			// Navigate to MainMenu.xaml
			this.Frame.Navigate(typeof(CurrencyCalculator));
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			Windows.ApplicationModel.Core.CoreApplication.Exit();
		}
	}
}
