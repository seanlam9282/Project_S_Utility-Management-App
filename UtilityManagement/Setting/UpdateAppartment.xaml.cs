using System.Globalization;
using UtilityManagement.Database;
namespace UtilityManagement.Setting;

public partial class UpdateAppartment : ContentPage
{
    public UpdateAppartment()
    {
        InitializeComponent();

        DBConnect dBConnect = new DBConnect();
        List<AppartmentCreator> tempList = dBConnect.DataTenent();
        int index = this.Picker.SelectedIndex;

        this.TenantName.Text = ($"{tempList[index].fName} {tempList[index].lName}");
        this.MoveInDate.Text = tempList[index].beganDate.ToString();
        this.PhoneNumber.Text = ($"{tempList[index].phone.Substring(0, 3)}.{tempList[index].phone.Substring(3, 3)}.{tempList[index].phone.Substring(6, 4)}");
        this.Deposit.Text = ($"{tempList[index].deposite:C2}");
    }

    public void Go(object sender, EventArgs e)
    {
        DBConnect dBConnect = new DBConnect();
        List<AppartmentCreator> tempList = dBConnect.DataTenent();
        int index = this.Picker.SelectedIndex;

        this.TenantName.Text = ($"{tempList[index].fName} {tempList[index].lName}");
        this.MoveInDate.Text = tempList[index].beganDate.ToString();
        this.PhoneNumber.Text = ($"{tempList[index].phone.Substring(0, 3)}.{tempList[index].phone.Substring(3, 3)}.{tempList[index].phone.Substring(6, 4)}");
        this.Deposit.Text = ($"{tempList[index].deposite:C2}");
    }

    public void Update(object sender, EventArgs e)
    {
        DBConnect dBConnect = new DBConnect();
        int unitNum = int.Parse(this.Picker.SelectedItem.ToString().Substring(11));
        string firstName = this.TenantName.Text.Split(" ")[0];
        string lastName = this.TenantName.Text.Split(" ")[1];
        DateOnly date = DateOnly.Parse(this.MoveInDate.Text);
        double deposit = double.Parse(this.Deposit.Text, NumberStyles.Currency);

        dBConnect.UpdateAppartment(unitNum, firstName, lastName, date, deposit);
        DisplayAlert("Confirmation", "Updated Successfully!", "OK");
    }
}