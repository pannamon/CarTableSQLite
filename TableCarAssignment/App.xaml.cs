using TableCarAssignment.Repositories;
namespace TableCarAssignment;

public partial class App : Application
{
	public static CarsRepository _carsRepo {get ; set ;}
	public App(CarsRepository carsRepo)
	{
		InitializeComponent();
        
		_carsRepo = carsRepo;

		//MainPage = new AppShell();
		MainPage = new CarsPage();
		
	}
}
