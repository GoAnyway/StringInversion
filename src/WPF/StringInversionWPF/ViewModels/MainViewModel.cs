using System.Collections.ObjectModel;
using System.Windows.Input;
using DataManager.StringInversionRepositories;
using Microsoft.Extensions.Logging;
using Models;
using StringInversionWPF.Commands;

namespace StringInversionWPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private SomeBigModel _selectedModel = new SomeBigModel();

        public MainViewModel(IStringInversionRepository stringInversionRepository,
            ILogger<AddInformationCommand> logger)
        {
            AddInformationCommand = new AddInformationCommand(this, stringInversionRepository, logger);
            FillInformationCommand = new FillInformationCommand(this, stringInversionRepository);

            FillInformationCommand.Execute(null);
        }

        public ObservableCollection<SomeBigModel> Models { get; set; } = new ObservableCollection<SomeBigModel>();

        public SomeBigModel SelectedModel
        {
            get => _selectedModel;
            set
            {
                _selectedModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddInformationCommand { get; set; }
        public ICommand FillInformationCommand { get; set; }
    }
}