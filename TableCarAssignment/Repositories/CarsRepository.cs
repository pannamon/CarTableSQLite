using System;
using SQLite;
using TableCarAssignment.MVVM.Model;

namespace TableCarAssignment.Repositories;

public class CarsRepository
{  
  SQLiteConnection connection;
    public string StatusMessage;
    public CarsRepository()
    {
        connection = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
        connection.CreateTable<Cars>();
    }

     public List<Cars> GetAll()
     {
        try 
        { 
            return connection.Table<Cars>().ToList();
        }
        catch (Exception ex)
        {
            while (ex.InnerException != null) ex = ex.InnerException;
            StatusMessage = $"Error: {ex.Message}";
        }
        return null;
     }
    
      public Cars Get(int id)
    {
        try
        {
            return connection.Table<Cars>().FirstOrDefault(x => x.ID == id);
        }
        catch (Exception ex)
        {
            while (ex.InnerException != null) ex = ex.InnerException;
            StatusMessage = $"Error: {ex.Message}";
        }
        return null;
    }
    public void AddorUpdate(Cars cars)
    {
        int result = 0;
        try
        {
            if (cars.ID != 0)
            {
                result = connection.Update(cars);
                StatusMessage = $"{result} row(s) update"; 
            }
            else
            {
                result = connection.Insert(cars);
                StatusMessage = $"{result} rows(s) added";
            }
        }
        catch (Exception ex)
        {
            while (ex.InnerException != null) ex = ex.InnerException;
            StatusMessage = $"Error: {ex.Message}";
        }

    }

    public void Delete (int id)
    {
        try
        {
            var cars = Get(id);
            connection.Delete(cars);
        }
        catch (Exception ex)
        {
            while (ex.InnerException != null) ex = ex.InnerException;
            StatusMessage = $"Error: {ex.Message}";
        }
    }



}

