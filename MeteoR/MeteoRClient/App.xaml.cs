namespace MeteoRClient
{
    using System.Windows;

    using MeteoRClient.MainWindow;

    using MeteoRInterfaceModel;

    using Ninject;
    using Ninject.Extensions.Factory;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            using (var kernel = new StandardKernel())
            {
                kernel.Bind<IGetResultsCommand>().To<GetResultsCommand>();
                kernel.Bind<IMainViewModel>().To<MainViewModel>();
                kernel.Bind<IMeteorServiceClient>().To<MeteorServiceClient>();
                kernel.Bind<MainView>().ToSelf();
                kernel.Bind<ICommandFactory>().ToFactory();
                kernel.Bind<IDateTimeToUnixConverter>().To<DateTimeToUnixConverter>();

                var mainView = kernel.Get<MainView>();
                var mainViewModel = kernel.Get<IMainViewModel>();
                mainView.DataContext = mainViewModel;
                mainView.Show();
            }
        }

    }
}
