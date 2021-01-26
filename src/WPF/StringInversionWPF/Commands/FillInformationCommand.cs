using System;
using System.Windows.Input;
using DataManager.StringInversionRepositories;
using StringInversionWPF.ViewModels;

namespace StringInversionWPF.Commands
{
    public class FillInformationCommand : ICommand
    {
        private readonly MainViewModel _mainViewModel;
        private readonly IStringInversionRepository _stringInversionRepository;

        public FillInformationCommand(MainViewModel mainViewModel, IStringInversionRepository stringInversionRepository)
        {
            _mainViewModel = mainViewModel;
            _stringInversionRepository = stringInversionRepository;
        }

        public bool CanExecute(object parameter) => true;

        public async void Execute(object parameter)
        {
            var models = await _stringInversionRepository.GetEntitiesAsModels();

            _mainViewModel.Models.Clear();

            foreach (var model in models)
            {
                _mainViewModel.Models.Add(model);
            }
        }

#pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067
    }
}