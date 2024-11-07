using System;
using System.Windows.Input;
using PropertyChanged;
using TableCarAssignment.MVVM.Model;


namespace TableCarAssignment.MVVM.ViewModels;

[AddINotifyPropertyChangedInterface]
public class CarsPageViewModel
{
   
   public List<Cars> Cars {get; set;}
   public Cars CurrentCars {get; set;}
   public ICommand AddorUpdateCommand {get; set;}
   public ICommand DeleteCommand {get; set;}

   public CarsPageViewModel()
     {
        this.Refresh();
        AddorUpdateCommand = new Command(async () =>
        {
            App._carsRepo.AddorUpdate(CurrentCars);
            Console.WriteLine(App._carsRepo.StatusMessage);
            this.Refresh();
        });

        DeleteCommand = new Command(async () => {
            App._carsRepo.Delete(CurrentCars.ID);
            this.Refresh();
        });
    }
    private void Refresh()
    {
        CurrentCars = new Cars();

        this.Cars = App._carsRepo.GetAll();
    } 
      
   }

