using  TableCarAssignment.MVVM.Model;
using TableCarAssignment.MVVM.ViewModels;
namespace TableCarAssignment;

public partial class CarsPage : ContentPage
{
	public CarsPage()
	{
		InitializeComponent();
		BindingContext = new CarsPageViewModel();
	}
}