using System;
using Apartamente.Data;
using System.IO;
namespace Apartamente;

public partial class App : Application
{
    static ObiectiveDatabase database;
    public static ObiectiveDatabase Database 
	{
		get 
		{
			if (database == null) 
			{ 
				database = new ObiectiveDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Obiective.db3")); 
			}
			return database;
		} 
	}
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
