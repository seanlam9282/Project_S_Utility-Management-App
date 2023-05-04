using System;
using System.Globalization;
using UtilityManagement.Database;
using UtilityManagement.Utility;

namespace UtilityManagement.Setting;

public partial class UpdateUtility : ContentPage
{
	public UpdateUtility()
	{
		InitializeComponent();

        DBConnect dBConnect = new DBConnect();
        List<AppartmentCreator> tempList = dBConnect.DataTenent();

        this.Rent.Text = ($"{tempList[this.Picker.SelectedIndex].rent:C2}");
        this.WaterLaundry.Text = ($"{tempList[this.Picker.SelectedIndex].waterLaundry:C2}");
    }

    public void Go(object sender, EventArgs e)
    {
        DBConnect dBConnect = new DBConnect();
        List<AppartmentCreator> tempList = dBConnect.DataTenent();

        this.Rent.Text = ($"{tempList[this.Picker.SelectedIndex].rent:C2}");
        this.WaterLaundry.Text = ($"{tempList[this.Picker.SelectedIndex].waterLaundry:C2}");
    }

    public void Update(object sender, EventArgs e)
    {
        DBConnect dBConnect = new DBConnect();
        int unitNum = int.Parse(this.Picker.SelectedItem.ToString().Substring(11));
        double rent = double.Parse(this.Rent.Text, NumberStyles.Currency);
        double waterLaundry = double.Parse(this.WaterLaundry.Text, NumberStyles.Currency);

        dBConnect.UpdateUtility(unitNum, rent, waterLaundry);
        DisplayAlert("Confirmation", "Updated Successfully!", "OK");
    }
}