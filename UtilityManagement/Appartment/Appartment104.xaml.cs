using UtilityManagement.Database;
namespace UtilityManagement.Appartment;

public partial class Appartment104 : ContentPage
{
    AppartmentCreator appGlobal = null;
    public Appartment104()
    {
        InitializeComponent();
        Database.DBConnect dBConnect = new Database.DBConnect();
        List<AppartmentCreator> tempList = dBConnect.DataTenent();

        int roomNo = 104;
        int index = 0;

        while (tempList[index].unitNum != roomNo && index < tempList.Count())
        {
            index++;
        }
        if (tempList[index].unitNum != roomNo)
        {
            DisplayAlert("Ooops", "Data not found", "Cancel");
        }
        else
        {
            this.appGlobal = tempList[index];
            this.TenantName.Text = ($"{appGlobal.fName} {appGlobal.lName}");
            this.MoveInDate.Text = appGlobal.beganDate.ToString();
            this.PhoneNumber.Text = ($"{appGlobal.phone.Substring(0, 3)}.{appGlobal.phone.Substring(3, 3)}.{appGlobal.phone.Substring(6, 4)}");
            this.Deposit.Text = ($"{appGlobal.deposite:C2}");
        }
    }
}