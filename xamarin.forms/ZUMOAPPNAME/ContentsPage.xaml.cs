using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace MediinApp
{
	public partial class ContentsPage : ContentPage
	{

        LogManager manager;
        ObservableCollection<Log> Olog = new ObservableCollection<Log>();
        List<Log> Llog = new List<Log>();
        
        public ContentsPage (List<Log> GridLogs,string User,string Password)
		{
			InitializeComponent ();
            
            manager = LogManager.DefaultManager;
            Llog = GridLogs
                .Where(p => p.names == User && p.passwords == Password)
                .OrderBy(p => p.date).ToList();
            Username.Text = User;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            int Sarm = 0, Ssit = 0, Syoga = 0, Spraise = 0;
            foreach (var item in Llog)
            {
                Sarm += item.arm;
                Ssit += item.sit;
                Syoga += item.yoga;
                Spraise += item.praise;
                Olog.Add(item);
            }            
            arm.Text = Sarm.ToString();
            sit.Text = Ssit.ToString();
            yoga.Text = Syoga.ToString();
            praise.Text = Spraise.ToString();
            // Set syncItems to true in order to synchronize the data on startup when running in offline mode
            //WholeList.ItemsSource = Lwhole;
            //Workerlist.ItemsSource = Lworker;
            WholeList.ItemsSource = Olog;
            //await RefreshItems(true, syncItems: true);
        }

        

        public async void Reset(object sender, EventArgs e)
        {
            var list = (ListView)sender;
            Exception error = null;
            try
            {
                await RefreshItems();               
            }
            catch (Exception ex)
            {
                error = ex;
            }
            finally
            {
                list.EndRefresh();
            }

            //Llog = new List<Log>(await manager.GetTodoItemsAsync());
            //Application.Current.MainPage = new ContentsPage(Llog, Username, Password);
        }

        private async Task RefreshItems()
        {
            Llog = new List<Log>(await manager.GetTodoItemsAsync());
            WholeList.ItemsSource = new ObservableCollection<Log>(Llog.OrderBy(i => i.date));
            //WholeList.ItemsSource = await manager.GetTodoItemsAsync();
            //Llog = new List<Log>(await manager.GetTodoItemsAsync());
            int Sarm = 0, Ssit = 0, Syoga = 0, Spraise = 0;
            foreach (var item in Llog)
            {
                Sarm += item.arm;
                Ssit += item.sit;
                Syoga += item.yoga;
                Spraise += item.praise;
            }
            arm.Text = Sarm.ToString();
            sit.Text = Ssit.ToString();
            yoga.Text = Syoga.ToString();
            praise.Text = Spraise.ToString();
        }

        private class ActivityIndicatorScope : IDisposable
        {
            private bool showIndicator;
            private ActivityIndicator indicator;
            private Task indicatorDelay;

            public ActivityIndicatorScope(ActivityIndicator indicator, bool showIndicator)
            {
                this.indicator = indicator;
                this.showIndicator = showIndicator;

                if (showIndicator)
                {
                    indicatorDelay = Task.Delay(2000);
                    SetIndicatorActivity(true);
                }
                else
                {
                    indicatorDelay = Task.FromResult(0);
                }
            }

            private void SetIndicatorActivity(bool isActive)
            {
                this.indicator.IsVisible = isActive;
                this.indicator.IsRunning = isActive;
            }

            public void Dispose()
            {
                if (showIndicator)
                {
                    indicatorDelay.ContinueWith(t => SetIndicatorActivity(false), TaskScheduler.FromCurrentSynchronizationContext());
                }
            }
        }

    }
}