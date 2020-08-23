using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.Generic;

namespace MediinApp
{
	public partial class StartPage : ContentPage
	{
        LogManager manager;
        List<Log> Llog = new List<Log>();
        public StartPage ()
		{
			InitializeComponent ();
            manager = LogManager.DefaultManager;
        }

        async void Login(object sender, EventArgs e)
        {

            //if (entusername.Text == "홍길동" && entpassword.Text == "0000")

                ind.IsRunning = true;
                ind.IsVisible = true;
                ind.IsEnabled = true;
                Llog = new List<Log>(await manager.GetTodoItemsAsync());


                await Navigation.PushModalAsync(new ContentsPage(Llog, entusername.Text, entpassword.Text));

        }
    }
}