using System;
using SQLite;

namespace TableCarAssignment.MVVM.Model;

public class Cars
{
    [PrimaryKey , AutoIncrement]
    public int ID { get ; set ;}

    [Column("Carid")]
    public string CarID {get;set;}

    [Column("CarModel"), Indexed , NotNull]
    public string Model { get ; set ;}

   [Column("CarColor"),Indexed , NotNull]
    public string Color { get ; set ;}
    
}
