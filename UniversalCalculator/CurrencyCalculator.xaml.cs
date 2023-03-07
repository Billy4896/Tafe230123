using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
	public sealed partial class CurrencyCalculator : Page
	{
		public CurrencyCalculator()
		{
			this.InitializeComponent();
		}

		// Declare Constant Conversion Rates
		const double USD_TO_EUR = 0.85189982;
		const double USD_TO_GBP = 0.72872436;
		const double USD_TO_INR = 74.257327;
		const double EUR_TO_USD = 1.1739732;
		const double EUR_TO_GBP = 0.8556672;
		const double EUR_TO_INR = 87.00755;
		const double GBP_TO_USD = 1.371907;
		const double GBP_TO_EUR = 1.1686692;
		const double GBP_TO_INR = 101.68635;
		const double INR_TO_USD = 0.011492628;
		const double INR_TO_EUR = 0.013492774;
		const double INR_TO_GBP = 0.0098339397;

		// Declare Variables
		double inputAmount = 0.0;
		double calculation = 0.0;
		string outputMessage = "";
		string customToString = "";

		private async void convertButton_Click(object sender, RoutedEventArgs e)
		{
			double convertedAmount;

			// If statement testing the combo box selections
			if (fromCurrencyComboBox.SelectedIndex == -1 || toCurrencyComboBox.SelectedIndex == -1)
			{
				// Initializes a new instance of the MessageDialog class to display the message dialog.
				var message = new MessageDialog("Please select valid currency options");
				await message.ShowAsync();
				amountTextBox.Focus(FocusState.Programmatic);
				amountTextBox.SelectAll();
				return;
			}
			else if (fromCurrencyComboBox.SelectedIndex == 0 && toCurrencyComboBox.SelectedIndex == 0)
			{
				// Initializes a new instance of the MessageDialog class to display the message dialog.
				var message = new MessageDialog("Please select valid currency options");
				await message.ShowAsync();
				amountTextBox.Focus(FocusState.Programmatic);
				amountTextBox.SelectAll();
				return;
			}
			else if (fromCurrencyComboBox.SelectedIndex == 1 && toCurrencyComboBox.SelectedIndex == 1)
			{
				// Initializes a new instance of the MessageDialog class to display the message dialog.
				var message = new MessageDialog("Please select valid currency options");
				await message.ShowAsync();
				amountTextBox.Focus(FocusState.Programmatic);
				amountTextBox.SelectAll();
				return;
			}
			else if (fromCurrencyComboBox.SelectedIndex == 2 && toCurrencyComboBox.SelectedIndex == 2)
			{
				// Initializes a new instance of the MessageDialog class to display the message dialog.
				var message = new MessageDialog("Please select valid currency options");
				await message.ShowAsync();
				amountTextBox.Focus(FocusState.Programmatic);
				amountTextBox.SelectAll();
				return;
			}
			else if (fromCurrencyComboBox.SelectedIndex == 3 && toCurrencyComboBox.SelectedIndex == 3)
			{
				// Initializes a new instance of the MessageDialog class to display the message dialog.
				var message = new MessageDialog("Please select valid currency options");
				await message.ShowAsync();
				amountTextBox.Focus(FocusState.Programmatic);
				amountTextBox.SelectAll();
				return;
			}

			// If statement testing if the amountTextBox.Text if empty, if so an error is displayed.
			if (amountTextBox.Text == "")
			{
				// Initializes a new instance of the MessageDialog class to display the message dialog.
				var message = new MessageDialog("The amount $ text box cannot be left empty");
				await message.ShowAsync();
				amountTextBox.Focus(FocusState.Programmatic);
				amountTextBox.SelectAll();
				return;
			}

			// Try & Catch Block - Input validation
			try
			{
				inputAmount = double.Parse(amountTextBox.Text);
			}
			catch (Exception exception)
			{
				// Initializes a new instance of the MessageDialog class to display the message dialog.
				var message = new MessageDialog("The amount must be a numeric value. " + exception.Message);
				await message.ShowAsync();
				// Set focus to the vehiclePriceTextBox.
				amountTextBox.Focus(FocusState.Programmatic);
				// Selects the vehiclePriceTextBox to improve usability.
				amountTextBox.SelectAll();
				return;
			}

			convertedAmount = conversionCalculation(inputAmount);
			conversionAmountTextBlock.Text = convertedAmount.ToString(customToString) + outputMessage;
		}

		private double conversionCalculation(double inputAmount)
		{
			// USD Conversions
			if (fromCurrencyComboBox.SelectedIndex == 0 && toCurrencyComboBox.SelectedIndex == 1)
			{
				calculation = inputAmount * USD_TO_EUR;
				amountFromTextBlock.Text = inputAmount.ToString("C") + " US Dollars =";
				fromToRatioTextBlock.Text = "1 USD = 0.85189982 Euros";
				toFromRatioTextBlock.Text = "1 EURO = 1.1739732 USD";
				outputMessage = " Euros";
				customToString = "C8";
			}
			else if (fromCurrencyComboBox.SelectedIndex == 0 && toCurrencyComboBox.SelectedIndex == 2)
			{
				calculation = inputAmount * USD_TO_GBP;
				amountFromTextBlock.Text = inputAmount.ToString("C") + " US Dollars =";
				fromToRatioTextBlock.Text = "1 USD = 0.72872436 British Pounds";
				toFromRatioTextBlock.Text = "1 British Pound = 1.371907 USD";
				outputMessage = " British Pounds";
				customToString = "C8";
			}
			else if (fromCurrencyComboBox.SelectedIndex == 0 && toCurrencyComboBox.SelectedIndex == 3)
			{
				calculation = inputAmount * USD_TO_INR;
				amountFromTextBlock.Text = inputAmount.ToString("C") + " US Dollars =";
				fromToRatioTextBlock.Text = "1 USD = 74.257327 Indian Rupee";
				toFromRatioTextBlock.Text = "1 Indian Rupee = 0.011492628 USD";
				outputMessage = " Indian Rupee";
				customToString = "C6";
			}
			// EURO Conversions
			else if  (fromCurrencyComboBox.SelectedIndex == 1 && toCurrencyComboBox.SelectedIndex == 0)
			{
				calculation = inputAmount * EUR_TO_USD;
				amountFromTextBlock.Text = inputAmount.ToString("C") + " EURO =";
				fromToRatioTextBlock.Text = "1 EURO = 1.1739732 USD";
				toFromRatioTextBlock.Text = "1 USD = 0.85189982 EURO";
				outputMessage = " US Dollars";
				customToString = "C7";
			}
			else if (fromCurrencyComboBox.SelectedIndex == 1 && toCurrencyComboBox.SelectedIndex == 2)
			{
				calculation = inputAmount * EUR_TO_GBP;
				amountFromTextBlock.Text = inputAmount.ToString("C") + " EURO =";
				fromToRatioTextBlock.Text = "1 EURO = 0.8556672 British Pound";
				toFromRatioTextBlock.Text = "1 British Pound = 1.1686692 EURO";
				outputMessage = " British Pounds";
				customToString = "C7";
			}
			else if (fromCurrencyComboBox.SelectedIndex == 1 && toCurrencyComboBox.SelectedIndex == 3)
			{
				calculation = inputAmount * EUR_TO_INR;
				amountFromTextBlock.Text = inputAmount.ToString("C") + " EURO =";
				fromToRatioTextBlock.Text = "1 EURO = 87.00755 Indian Rupee";
				toFromRatioTextBlock.Text = "1 Indian Rupee = 0.013492774 EURO";
				outputMessage = " Indian Rupees";
				customToString = "C5";
			}
			// GBP Conversions
			else if (fromCurrencyComboBox.SelectedIndex == 2 && toCurrencyComboBox.SelectedIndex == 0)
			{
				calculation = inputAmount * GBP_TO_USD;
				amountFromTextBlock.Text = inputAmount.ToString("C") + " British Pounds =";
				fromToRatioTextBlock.Text = "1 British Pound = 1.371907 USD";
				toFromRatioTextBlock.Text = "1 USD = 0.72872436 British Pound";
				outputMessage = " US Dollars";
				customToString = "C6";
			}
			else if (fromCurrencyComboBox.SelectedIndex == 2 && toCurrencyComboBox.SelectedIndex == 1)
			{
				calculation = inputAmount * GBP_TO_EUR;
				amountFromTextBlock.Text = inputAmount.ToString("C") + " British Pounds =";
				fromToRatioTextBlock.Text = "1 British Pound = 1.1686692 Euro";
				toFromRatioTextBlock.Text = "1 Euro = 0.8556672 British Pounds";
				outputMessage = " Euros";
				customToString = "C7";
			}
			else if (fromCurrencyComboBox.SelectedIndex == 2 && toCurrencyComboBox.SelectedIndex == 3)
			{
				calculation = inputAmount * GBP_TO_INR;
				amountFromTextBlock.Text = inputAmount.ToString("C") + " British Pounds =";
				fromToRatioTextBlock.Text = "1 British Pound = 101.68635 Indian Rupee";
				toFromRatioTextBlock.Text = "1 Indian Rupee = 0.0098339397 British Pound";
				outputMessage = " Indian Rupees";
				customToString = "C5";
			}
			// INR Conversions
			else if (fromCurrencyComboBox.SelectedIndex == 3 && toCurrencyComboBox.SelectedIndex == 0)
			{
				calculation = inputAmount * INR_TO_USD;
				amountFromTextBlock.Text = inputAmount.ToString("C") + " Indian Rupees =";
				fromToRatioTextBlock.Text = "1 Indian Rupee = 0.011492628 USD";
				toFromRatioTextBlock.Text = "1 USD = 74.257327 Indian Rupee ";
				outputMessage = " US Dollars";
				customToString = "C9";
			}
			else if (fromCurrencyComboBox.SelectedIndex == 3 && toCurrencyComboBox.SelectedIndex == 1)
			{
				calculation = inputAmount * INR_TO_EUR;
				amountFromTextBlock.Text = inputAmount.ToString("C") + " Indian Rupees =";
				fromToRatioTextBlock.Text = "1 Indian Rupee = 0.013492774 Euro";
				toFromRatioTextBlock.Text = "1 Euro = 87.00755 Indian Rupee";
				outputMessage = " Euros";
				customToString = "C9";
			}
			else if (fromCurrencyComboBox.SelectedIndex == 3 && toCurrencyComboBox.SelectedIndex == 2)
			{
				calculation = inputAmount * INR_TO_GBP;
				amountFromTextBlock.Text = inputAmount.ToString("C") + " Indian Rupees =";
				fromToRatioTextBlock.Text = "1 Indian Rupee = 0.0098339397 British Pound";
				toFromRatioTextBlock.Text = "1 British Pound = 101.68635 Indian Rupee";
				outputMessage = " British Pounds";
				customToString = "C10";
			}

			return calculation;
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			// Navigate to MainMenu.xaml
			this.Frame.Navigate(typeof(MainMenu));
		}
	}
}
