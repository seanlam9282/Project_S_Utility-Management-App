

namespace UtilityManagement.Utility;

public partial class Utility108 : ContentPage
{
    AppartmentCreator appGlobal = null;
    public Utility108()
    {
        InitializeComponent();
        Database.DBConnect dBConnect = new Database.DBConnect();
        List<AppartmentCreator> tempList = dBConnect.DataTenent();


        //finding the right object for the 
        int roomNo = 108;
        int index = 0;
        while (tempList[index].unitNum != roomNo && index < tempList.Count())
        {
            index++;
        }

        //check if the right object is found in the list
        if (tempList[index].unitNum != roomNo)
        {
            DisplayAlert("Ooops", "Data not found", "Cancel");
        }

        //populate field after data is found
        else
        {
            this.appGlobal = tempList[index];
            this.TenantName.Text = ($"{appGlobal.fName} {appGlobal.lName}");
            this.Rent.Text = ($"{appGlobal.rent:C2}");
            this.WaterLaundry.Text = ($"{appGlobal.waterLaundry:C2}");
            this.LastElectricity.Text = appGlobal.newPower.ToString();
        }
    }


    //method to calculate utility and generate message
    public void Calculation(object sender, EventArgs e)
    {

        if (this.NewElectricity.Text == null)
        {
            DisplayAlert("Blank Input!!", "Oops!! you have not provided the new reading for this month", "Cancel");
            return;
            //throw new BlankRequiredFieldException();
        }
        else
        {
            int input;
            if (int.TryParse(this.NewElectricity.Text, out input))
            {
                if (input >= this.appGlobal.newPower)
                {
                    int usage = input - this.appGlobal.newPower;
                    double cost = usage * 1.4;
                    this.ElectricityCost.Text = ($"{cost:C2}");
                    double ammountDue = appGlobal.rent + appGlobal.waterLaundry + cost;
                    this.TotalAmmount.Text = ($"{ammountDue:C2}");
                    string message = ($"Dear {appGlobal.fName} {appGlobal.lName} residing at Apparment {appGlobal.unitNum}! \nPlease check the below for this month rent details\n{"New Electricity Reading: ",-25}{input}-{appGlobal.newPower}\n{"Electricity Usage: ",-25}{usage}(kWh)\n{"Electricity Cost: ",-25}{cost:C2}\n{"Rent: ",-25}{appGlobal.rent:C2}\n{"Fixed Water and Laundry: ",-25}{appGlobal.waterLaundry:C2}\n{"Total Due: ",-25}{ammountDue:C2}");
                    this.SmS.Text = message;
                }
                else
                {
                    DisplayAlert("Invalid input!!", "Oops!! new reading can not be lower than previous month's reading", "Cancel");
                    this.NewElectricity.Text = null;
                    return;
                    //throw new InvalidInputException();
                }
            }
            else
            {
                DisplayAlert("Invalid input!!", "Oops!! you have not provided a valid number for reading", "Cancel");
                this.NewElectricity.Text = null;
                return;
                //throw new InvalidInputException();
            }
        }
    }
}