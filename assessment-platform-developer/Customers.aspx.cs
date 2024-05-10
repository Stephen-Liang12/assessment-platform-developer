﻿using assessment_platform_developer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using assessment_platform_developer.Services;
using Container = SimpleInjector.Container;

namespace assessment_platform_developer
{
	public partial class Customers : Page
	{
        private const string AddNewCustomer = "Add new customer";
        private static List<Customer> customers = new List<Customer>();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				var testContainer = (Container)HttpContext.Current.Application["DIContainer"];
				var customerService = testContainer.GetInstance<ICustomerService>();

				var allCustomers = customerService.GetAllCustomers();
				ViewState["Customers"] = allCustomers;
                PopulateCustomerListBox();
                PopulateCustomerDropDownLists();
            }
			else
			{
				customers = (List<Customer>)ViewState["Customers"];
			}
		}

		private void PopulateCustomerDropDownLists()
        {

            var countryList = Enum.GetValues(typeof(Countries))
                .Cast<Countries>()
                .Select(c => new ListItem
                {
                    Text = c.ToString(),
                    Value = ((int)c).ToString()
                })
                .ToArray();

            CountryDropDownList.Items.AddRange(countryList);
            CountryDropDownList.SelectedValue = ((int)Countries.Canada).ToString();

            PopulateStateDropDownList<CanadianProvinces>();
        }

        private void PopulateStateDropDownList<T>() where T : Enum
        {
            StateDropDownList.Items.Clear();
            var provinceList = Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(p => new ListItem
                {
                    Text = p.ToString(),
                    Value = (Convert.ToInt32(p)).ToString()
                })
                .ToArray();

            StateDropDownList.Items.Add(new ListItem(""));
            StateDropDownList.Items.AddRange(provinceList);
        }

        protected void PopulateCustomerListBox()
		{
			CustomersDDL.Items.Clear();
            CustomersDDL.Items.Add(new ListItem(AddNewCustomer, "0"));
            var storedCustomers = customers.Select(c => new ListItem(c.Name, c.ID.ToString())).ToArray();
			if (storedCustomers.Length != 0)
			{
				CustomersDDL.Items.AddRange(storedCustomers);
			}

            CustomersDDL.SelectedIndex = 0;
            AddButton.Visible = true;
            UpdateButton.Visible = false;
            DeleteButton.Visible = false;
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            var customer = new Customer
            {
                Name = CustomerName.Text,
                Address = CustomerAddress.Text,
                City = CustomerCity.Text,
                State = StateDropDownList.SelectedItem.Text,
                Zip = CustomerZip.Text,
                Country = CountryDropDownList.SelectedItem.Text,
                Email = CustomerEmail.Text,
                Phone = CustomerPhone.Text,
                Notes = CustomerNotes.Text,
                ContactName = ContactName.Text,
                ContactPhone = CustomerPhone.Text,
                ContactEmail = CustomerEmail.Text
            };

            var testContainer = (Container)HttpContext.Current.Application["DIContainer"];
            var customerService = testContainer.GetInstance<ICustomerService>();
            customerService.AddCustomer(customer);
            customers.Add(customer);

            CustomersDDL.Items.Add(new ListItem(customer.Name, customer.ID.ToString()));

            ResetForm();
        }

        private void ResetForm()
        {
            CustomerName.Text = string.Empty;
            CustomerAddress.Text = string.Empty;
            CustomerEmail.Text = string.Empty;
            CustomerPhone.Text = string.Empty;
            CustomerCity.Text = string.Empty;
            StateDropDownList.SelectedIndex = 0;
            CustomerZip.Text = string.Empty;
            CountryDropDownList.SelectedIndex = 0;
            CustomerNotes.Text = string.Empty;
            ContactName.Text = string.Empty;
            ContactPhone.Text = string.Empty;
            ContactEmail.Text = string.Empty;
        }

        protected void CustomersDDL_SelectedIndexChanged(object sender, EventArgs e)
		{
			var selectedItem = CustomersDDL.SelectedItem;
			if (selectedItem != null) {
				if (selectedItem.Value == "0")
				{
					ResetForm();
					AddButton.Visible = true;
					UpdateButton.Visible = false;
					DeleteButton.Visible = false;
				}
				else
				{
                    var container = (Container)HttpContext.Current.Application["DIContainer"];
                    var customerService = container.GetInstance<ICustomerService>();
					var selectedCustomer = customerService.GetCustomer(int.Parse(selectedItem.Value));
                    CustomerName.Text = selectedCustomer.Name;
                    CustomerAddress.Text = selectedCustomer.Address;
                    CustomerEmail.Text = selectedCustomer.Email;
                    CustomerPhone.Text = selectedCustomer.Phone;
                    CustomerCity.Text = selectedCustomer.City;
                    CountryDropDownList.SelectedIndex = CountryDropDownList.Items.IndexOf(CountryDropDownList.Items.FindByText(selectedCustomer.Country));
                    CountryDropDownList_SelectedIndexChanged(this, null); 
                    StateDropDownList.SelectedIndex = StateDropDownList.Items.IndexOf(StateDropDownList.Items.FindByText(selectedCustomer.State));
                    CustomerZip.Text = selectedCustomer.Zip;
                    CustomerNotes.Text = selectedCustomer.Notes;
                    ContactName.Text = selectedCustomer.ContactName;
                    ContactPhone.Text = selectedCustomer.ContactPhone;
                    ContactEmail.Text = selectedCustomer.ContactEmail;

                    AddButton.Visible = false;
                    UpdateButton.Visible = true;
                    DeleteButton.Visible = true;
                }
            }
		}

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            var selectedItem = CustomersDDL.SelectedItem;
			if (selectedItem != null)
			{
				var customer = new Customer
				{
					ID = int.Parse(selectedItem.Value),
                    Name = CustomerName.Text,
					Address = CustomerAddress.Text,
					City = CustomerCity.Text,
					State = StateDropDownList.SelectedValue,
					Zip = CustomerZip.Text,
					Country = CountryDropDownList.SelectedValue,
					Email = CustomerEmail.Text,
					Phone = CustomerPhone.Text,
					Notes = CustomerNotes.Text,
					ContactName = ContactName.Text,
					ContactPhone = CustomerPhone.Text,
					ContactEmail = CustomerEmail.Text
				};

				var testContainer = (Container)HttpContext.Current.Application["DIContainer"];
				var customerService = testContainer.GetInstance<ICustomerService>();
				customerService.UpdateCustomer(customer);
				customers.Remove(customers.First(c => c.ID == customer.ID));
				customers.Add(customer);

				CustomerName.Text = string.Empty;
				CustomerAddress.Text = string.Empty;
				CustomerEmail.Text = string.Empty;
				CustomerPhone.Text = string.Empty;
				CustomerCity.Text = string.Empty;
				StateDropDownList.SelectedIndex = 0;
				CustomerZip.Text = string.Empty;
				CountryDropDownList.SelectedIndex = 0;
				CustomerNotes.Text = string.Empty;
				ContactName.Text = string.Empty;
				ContactPhone.Text = string.Empty;
				ContactEmail.Text = string.Empty;
				CustomersDDL.SelectedIndex = 0;
			}
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            var selectedItem = CustomersDDL.SelectedItem;
			if (selectedItem != null)
			{
				var testContainer = (Container)HttpContext.Current.Application["DIContainer"];
				var customerService = testContainer.GetInstance<ICustomerService>();
                int id = int.Parse(selectedItem.Value);
                customerService.DeleteCustomer(id);
                customers.Remove(customers.First(c => c.ID == id));
				PopulateCustomerListBox();

				ResetForm();
				CustomersDDL.SelectedIndex = 0;
			}
        }

		protected void CountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (CountryDropDownList.SelectedValue == ((int)Countries.Canada).ToString())
			{
                PopulateStateDropDownList<CanadianProvinces>();
            }
            else if (CountryDropDownList.SelectedValue == ((int)Countries.UnitedStates).ToString())
            {
                PopulateStateDropDownList<USStates>();
            }
            else
            {
                StateDropDownList.Items.Clear();
            }
        }
    }
}