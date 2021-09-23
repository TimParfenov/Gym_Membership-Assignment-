using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace Assignment_2_T1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		//=============Variable============
		double membership;
		double duration;
		double access;
		double trainer;
		double diet;
		double online;
		double discountWeek;
		double discountMonth;
		double totalCost;
		double regular;
		double netCostWeek;
		double netCostMonth;
		double extraWeek;
		double extraMonth;
		double discountDD;
		double totalDiscountsMonth;
		//=============Variable============


		//=============Extras/24/7 access============
		private void radioButton_access_Yes_CheckedChanged(object sender, EventArgs e)
		{
			access = 1;
		}

		private void radioButton_access_No_CheckedChanged(object sender, EventArgs e)
		{
			access = 0;
		}
		//=============Extras/24/7 access============


		//=============Extras/Personal trainer============
		private void radioButton_trainer_Yes_CheckedChanged(object sender, EventArgs e)
		{
			trainer = 20;
		}

		private void radioButton_trainer_No_CheckedChanged(object sender, EventArgs e)
		{
			trainer = 0;
		}
		//=============Extras/Personal trainer============


		//=============Extras/Diet consultation============
		private void radioButton_diet_Yes_CheckedChanged(object sender, EventArgs e)
		{
			diet = 20;
		}

		private void radioButton_diet_No_CheckedChanged(object sender, EventArgs e)
		{
			diet = 0;
		}
		//=============Extras/Diet consultation============


		//=============Extras/Online access============
		private void radioButton_online_Yes_CheckedChanged(object sender, EventArgs e)
		{
			online = 2;
		}

		private void radioButton_online_No_CheckedChanged(object sender, EventArgs e)
		{
			online = 0;
		}
		//=============Extras/Online access============


		//=============Membership============
		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			membership = 10;
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			membership = 15;
		}

		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
			membership = 20;
		}
		//=============Membership============


		//=============Duration============
		private void radioButton6_CheckedChanged(object sender, EventArgs e)
		{
			duration = 3;
		}

		private void radioButton5_CheckedChanged(object sender, EventArgs e)
		{
			duration = 12;
		}

		private void radioButton4_CheckedChanged(object sender, EventArgs e)
		{
			duration = 24;
		}
		//=============Duration============


		//=============Direct debit============
		private void radioButton_directD_Yes_CheckedChanged(object sender, EventArgs e)
		{
			discountDD = 0.01;
		}

		private void radioButton_directD_No_CheckedChanged(object sender, EventArgs e)
		{
			discountDD = 0;
		}
		//=============Direct debit============


		//=============Calculator button============
		private void button1_Click(object sender, EventArgs e)
		{
			// =========Validation========
			if (String.IsNullOrEmpty(firstName.Text) ||
				String.IsNullOrEmpty(lastName.Text) ||
				String.IsNullOrEmpty(email.Text) ||
				String.IsNullOrEmpty(phoneNumber.Text) ||
				String.IsNullOrEmpty(address.Text) ||
				String.IsNullOrEmpty(city.Text) ||
				String.IsNullOrEmpty(region.Text) ||
				String.IsNullOrEmpty(postCode.Text))
			{
				MessageBox.Show("Please complete Customer Details Form");
			}
			else
			{
				if ((radioButton_access_Yes.Checked || radioButton_access_No.Checked) &&
				(radioButton_trainer_Yes.Checked || radioButton_trainer_No.Checked) &&
				(radioButton_diet_Yes.Checked || radioButton_diet_No.Checked) &&
				(radioButton_online_Yes.Checked || radioButton_online_No.Checked))
				{
					if (radioButton_basic.Checked || radioButton_regular.Checked || radioButton_premium.Checked)
					{
						if (radioButton_3_months.Checked || radioButton_12_months.Checked || radioButton_24_months.Checked)
						{
							if ((radioButton_directD_Yes.Checked || radioButton_directD_No.Checked) &&
								(radioButton_frequencyPay_Month.Checked || radioButton_frequencyPay_Week.Checked))
							{
								//============ Total Extras ====================
								textBox_extra.Text = "";
								extraWeek = (access + trainer + diet + online);
								extraMonth = (extraWeek * 52) / 12;
								textBox_extra.Text += "$ " + Math.Round((extraMonth * duration), 2);
								//============ Total Extras ====================


								//============ Total Discount ====================
								textBox_discount.Text = "";
								if (duration == 12)
								{
									discountWeek = 2;
									discountMonth = discountWeek * 52 / 12;
								}
								else if (duration == 24)
								{
									discountWeek = 5;
									discountMonth = discountWeek * 52 / 12;
								}
								else if (duration == 3)
								{
									discountWeek = 0;
									discountMonth = discountWeek;
								}

								double discountDDWeek = discountDD * membership;
								double discountDDMonth = discountDDWeek * 52 / 12;
								totalDiscountsMonth = discountMonth + discountDDMonth;
								textBox_discount.Text += "$ " + Math.Round((totalDiscountsMonth * duration), 2);

								//============ Total Discount ====================


								//============ Net Cost ====================
								textBox_netCost.Text = "";
								netCostWeek = membership;
								netCostMonth = netCostWeek * 52 / 12;
								textBox_netCost.Text += "$ " + Math.Round((netCostMonth * duration), 2);
								//============ Net Cost ====================


								//============ Regular Payment ====================
								textBox_regularPayment.Text = "";
								if (radioButton_frequencyPay_Week.Checked)
								{
									regular = netCostWeek + extraWeek - discountWeek;
								}
								else if (radioButton_frequencyPay_Month.Checked)
								{
									regular = (netCostMonth + extraMonth - discountMonth);
								}
								textBox_regularPayment.Text += "$ " + Math.Round(regular, 2);
								//============ Regular Payment ====================


								//============ Total Cost ====================
								textBox_totalCost.Text = "";
								totalCost = (netCostMonth - totalDiscountsMonth + extraMonth);
								textBox_totalCost.Text += "$ " + Math.Round((totalCost * duration), 2);
								//============ Total Cost ====================
							}
							else
							{

								MessageBox.Show("Please select Payment Option");
							}
						}
						else
						{

							MessageBox.Show("Please select Duration");
						}
					}
					else
					{

						MessageBox.Show("Please select Membership Type");
					}
				}
				else
				{

					MessageBox.Show("Please select Extras");
				}
			}

		}
		//=============Calculator button============


		// =========Validation email format only ========
		private void email_TextChanged(object sender, EventArgs e)
		{
			string pattern1 = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-pa-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
			if ((Regex.IsMatch(email.Text, pattern1)) || (String.IsNullOrEmpty(email.Text)))
			{
				errorProvider1.Clear();
			}
			else
			{
				errorProvider1.SetError(this.email, "Please provide valid Email address");
				return;
			}
		}
		// =========Validation email format only ========


		// =========Validation numbers only ========
		private void phoneNumber_TextChanged(object sender, EventArgs e)
		{
			string pattern2 = "^([0-9]{10})";
			if ((Regex.IsMatch(phoneNumber.Text, pattern2)) || (String.IsNullOrEmpty(phoneNumber.Text)))
			{
				errorProvider1.Clear();
			}
			else
			{
				errorProvider1.SetError(this.phoneNumber, "Please provide valid Phone Number");
				return;
			}

		}

		private void postCode_TextChanged_1(object sender, EventArgs e)
		{

			string pattern3 = "^([0-9]{4})";
			if ((Regex.IsMatch(postCode.Text, pattern3)) || (String.IsNullOrEmpty(postCode.Text)))
			{
				errorProvider1.Clear();
			}
			else
			{
				errorProvider1.SetError(this.postCode, "Please provide valid Zip");
				return;
			}
		}
		// =========Validation numbers only ========


		// =========Export data to text file button ========
		private void submit_Click(object sender, EventArgs e)
		{
			// =========Validation========
			if (String.IsNullOrEmpty(firstName.Text) ||
				String.IsNullOrEmpty(lastName.Text) ||
				String.IsNullOrEmpty(email.Text) ||
				String.IsNullOrEmpty(phoneNumber.Text) ||
				String.IsNullOrEmpty(address.Text) ||
				String.IsNullOrEmpty(city.Text) ||
				String.IsNullOrEmpty(region.Text) ||
				String.IsNullOrEmpty(postCode.Text))
			{
				MessageBox.Show("Please complete Customer Details Form");
			}
			else
			{
				if ((radioButton_access_Yes.Checked || radioButton_access_No.Checked) &&
				(radioButton_trainer_Yes.Checked || radioButton_trainer_No.Checked) &&
				(radioButton_diet_Yes.Checked || radioButton_diet_No.Checked) &&
				(radioButton_online_Yes.Checked || radioButton_online_No.Checked))
				{
					if (radioButton_basic.Checked || radioButton_regular.Checked || radioButton_premium.Checked)
					{
						if (radioButton_3_months.Checked || radioButton_12_months.Checked || radioButton_24_months.Checked)
						{
							if ((radioButton_directD_Yes.Checked || radioButton_directD_No.Checked) &&
								(radioButton_frequencyPay_Month.Checked || radioButton_frequencyPay_Week.Checked))
							{
								//===============Exporting data to txt file===============
								if (String.IsNullOrEmpty(textBox_totalCost.Text))
								{
									MessageBox.Show("Please click Calculate Button");
								}
								else
								{
									StreamWriter w = new StreamWriter("../../../Membership_form.txt"); //- this row to rewrite exported data.
									//StreamWriter w = File.AppendText("../../../Membership_form.txt"); // - this row to add to existing exported data.
									w.Write("================MEMBERSHIP FORM=================" + "\r\n" + "\r\n");
									w.Write("================Customer Details================" + "\r\n");
									w.Write("First Name: " + "        " + firstName.Text + "\r\n");
									w.Write("Last Name: " + "         " + lastName.Text + "\r\n");
									w.Write("Email: " + "             " + email.Text + "\r\n");
									w.Write("Phone Number: " + "      " + phoneNumber.Text + "\r\n");
									w.Write("Address: " + "           " + address.Text + "\r\n");
									w.Write("City: " + "              " + city.Text + "\r\n");
									w.Write("Region: " + "            " + region.SelectedItem + "\r\n");
									w.Write("Post code: " + "         " + postCode.Text + "\r\n");
									w.Write("====================Extras=======================" + "\r\n");
									if (radioButton_access_Yes.Checked)
									{
										w.Write("24/7 Access ($1 per week): " + "                   " + "Yes" + "\r\n");
									}
									else
									{
										w.Write("24/7 Access ($1 per week): " + "                   " + "No" + "\r\n");
									}
									if (radioButton_trainer_Yes.Checked)
									{
										w.Write("Personal trainer ($20 per week): " + "             " + "Yes" + "\r\n");
									}
									else
									{
										w.Write("Personal trainer ($20 per week): " + "             " + "No" + "\r\n");
									}
									if (radioButton_diet_Yes.Checked)
									{
										w.Write("Diet consultation ($20 per week): " + "            " + "Yes" + "\r\n");
									}
									else
									{
										w.Write("Diet consultation ($20 per week): " + "            " + "No" + "\r\n");
									}
									if (radioButton_online_Yes.Checked)
									{
										w.Write("Access to online fitness video ($2 per week): " + "Yes" + "\r\n");
									}
									else
									{
										w.Write("Access to online fitness video ($2 per week): " + "No" + "\r\n");
									}
									w.Write("=================Membership details==============" + "\r\n");
									if (radioButton_basic.Checked)
									{
										w.Write("Type of membeship: " + "         " + "Basic ($10 per week)" + "\r\n");
									}
									else if (radioButton_regular.Checked)
									{
										w.Write("Type of membeship: " + "         " + "Regular ($15 per week)" + "\r\n");
									}
									else if (radioButton_premium.Checked)
									{
										w.Write("Type of membeship: " + "         " + "Premium($20 per week)" + "\r\n");
									}
									if (radioButton_3_months.Checked)
									{
										w.Write("Duration: " + "                  " + "3 months" + "\r\n");
									}
									else if (radioButton_12_months.Checked)
									{
										w.Write("Duration: " + "                  " + "12 months *" + "\r\n");
									}
									else if (radioButton_24_months.Checked)
									{
										w.Write("Duration: " + "                  " + "24 months **" + "\r\n");
									}
									w.Write("================Payment options==================" + "\r\n");
									if (radioButton_directD_Yes.Checked)
									{
										w.Write("Direct debit: " + "                           " + "Yes" + "\r\n");
									}
									else
									{
										w.Write("Direct debit: " + "                           " + "No" + "\r\n");
									}
									if (radioButton_frequencyPay_Week.Checked)
									{
										w.Write("Frequency of payment: " + "                   " + "Weekly" + "\r\n");
									}
									else
									{
										w.Write("Frequency of payment: " + "                   " + "Monthly" + "\r\n");
									}
									w.Write("==================Total cost=====================" + "\r\n");
									w.Write("Membership Cost Total: " + "                   " + textBox_totalCost.Text + "\r\n");
									w.Write("Extra Charge: " + "                            " + textBox_extra.Text + "\r\n");
									w.Write("Total Discount: " + "                          " + textBox_discount.Text + "\r\n");
									w.Write("Net Membership Cost: " + "                     " + textBox_netCost.Text + "\r\n");
									w.Write("Regular Payment Amount: " + "                  " + textBox_regularPayment.Text + "\r\n" + "\r\n");
									w.Close();
									MessageBox.Show("Data Exported to Membership_form.txt");
								}
							}
							else
							{
								MessageBox.Show("Please select Payment Option");
							}
						}
						else
						{
							MessageBox.Show("Please select Duration");
						}
					}
					else
					{
						MessageBox.Show("Please select Membership Type");
					}
				}
				else
				{
					MessageBox.Show("Please select Extras");
				}
			}
		}
		// =========Export data to text file button ========


		// ========Clear all data from the form==========
		private void clearAll_Click(object sender, EventArgs e)
		{
			// =======Clear all data from text boxes=======
			firstName.Text = "";
			lastName.Text = "";
			email.Text = "";
			phoneNumber.Text = "";
			address.Text = "";
			city.Text = "";
			region.SelectedIndex = -1;
			postCode.Text = "";
			textBox_totalCost.Text = "";
			textBox_extra.Text = "";
			textBox_discount.Text = "";
			textBox_netCost.Text = "";
			textBox_regularPayment.Text = "";

			var cntls = GetAll(this, typeof(RadioButton)); // select all radiobuttons in the form and clear all
			foreach (Control cntrl in cntls)
			{
				RadioButton _rb = (RadioButton)cntrl;
				if (_rb.Checked)
				{
					_rb.Checked = false;
				}
			}
		}
		public IEnumerable<Control> GetAll(Control control, Type type)
		{
			var controls = control.Controls.Cast<Control>();
			return controls.SelectMany(ctrls => GetAll(ctrls, type)).Concat(controls).Where(c => c.GetType() == type);
		} 
		// ========Clear all data from the form==========

	}
}
