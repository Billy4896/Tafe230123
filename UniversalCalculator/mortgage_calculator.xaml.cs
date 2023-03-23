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
	public sealed partial class mortgage_calculator : Page
	{
		public mortgage_calculator()
		{
			this.InitializeComponent();
		}
		// variables
		double principalBorrow;
		int inputYears;
		int inputMonths;
		double yearlyInterestRate;


		double monthlyInterestRate;
		int monthsRequiredForPayment;
		double monthlyRepaymentAmount;

		

		
		private double Calc_Monthly_Interest_Rate(double yearlyInterestRate)
		{
			double convertInterestRate = yearlyInterestRate / 100;
			monthlyInterestRate = convertInterestRate / 12;
			return monthlyInterestRate;
		}

		private int Calc_Num_Of_Months_Required_For_Payment(int inputYears, int inputMonths)
		{

			monthsRequiredForPayment = inputYears * 12 + inputMonths;
			return monthsRequiredForPayment;
		}

		private double Calc_Monthly_Repayment(double principalBorrow)
		{
			// uses calculation from documentation M = P [ i(1 + i)^n ] / [ (1 + i)^n – 1] 
			monthlyRepaymentAmount = principalBorrow * (monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, monthsRequiredForPayment)) / (Math.Pow(1 + monthlyInterestRate, monthsRequiredForPayment) - 1);
			return monthlyRepaymentAmount;
		}

		private async void Calculate_Button_Click(object sender, RoutedEventArgs e)
		{
			// validation for principalBorrow, try catch block and setting focus back to principalBorrowTextBox
			try
			{
				principalBorrow = double.Parse(principalBorrowTextBox.Text);
			}
			catch (Exception exception)
			{
				var message = new MessageDialog("principal borrow must be a numeric value. " + exception.Message);
				await message.ShowAsync();
				principalBorrowTextBox.Focus(FocusState.Programmatic);
				principalBorrowTextBox.SelectAll();
				return;
			}

			// validation for years, , try catch block and setting focus back to yearsTextBox
			try
			{
				inputYears = int.Parse(yearsTextBox.Text);
			}
			catch (Exception exception)
			{
				var message = new MessageDialog("years must be a numeric value. " + exception.Message);
				await message.ShowAsync();
				yearsTextBox.Focus(FocusState.Programmatic);
				yearsTextBox.SelectAll();
				return;
			}

			// validation for months, , try catch block and setting focus back to monthsTextBox
			try
			{
				inputMonths = int.Parse(monthsTextBox.Text);
			}
			catch (Exception exception)
			{
				var message = new MessageDialog("months must be a numeric value. " + exception.Message);
				await message.ShowAsync();
				monthsTextBox.Focus(FocusState.Programmatic);
				monthsTextBox.SelectAll();
				return;
			}

			// validation for yearlyinterestrate, , try catch block and setting focus back to yearlyInterestRateTextBox
			try
			{
				yearlyInterestRate = double.Parse(yearlyInterestRateTextBox.Text);
			}
			catch (Exception exception)
			{
				var message = new MessageDialog("yearly interest must be a numeric value. " + exception.Message);
				await message.ShowAsync();
				yearlyInterestRateTextBox.Focus(FocusState.Programmatic);
				yearlyInterestRateTextBox.SelectAll();
				return;
			}

			monthlyInterestRate = Calc_Monthly_Interest_Rate(yearlyInterestRate);
			monthsRequiredForPayment = Calc_Num_Of_Months_Required_For_Payment(inputYears, inputMonths);
			monthlyRepaymentAmount = Calc_Monthly_Repayment(principalBorrow);

			monthlyInterestRateTextBox.Text = monthlyInterestRate.ToString("N4") + "%";
			monthlyRepaymentTextBox.Text = monthlyRepaymentAmount.ToString("C");
		}

		private async void Exit_Button_Click(object sender, RoutedEventArgs e)
		{
			// exits program to main menu
			this.Frame.Navigate(typeof(MainMenu));
		}
	}
}
