namespace MeteoRClient.MainWindow
{
    public interface ICommandFactory
    {
        IGetResultsCommand CreateCommand(IMainViewModel viewModel);
    }
}