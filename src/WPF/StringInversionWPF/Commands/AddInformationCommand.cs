using System;
using System.Text.Json;
using System.Windows.Input;
using DataManager.StringInversionRepositories;
using Microsoft.Extensions.Logging;
using StringInversionWPF.Utils.Extensions;
using StringInversionWPF.ViewModels;

namespace StringInversionWPF.Commands
{
    public class AddInformationCommand : ICommand
    {
        private readonly ILogger<AddInformationCommand> _logger;
        private readonly MainViewModel _mainViewModel;
        private readonly IStringInversionRepository _stringInversionRepository;

        public AddInformationCommand(MainViewModel mainViewModel, IStringInversionRepository stringInversionRepository,
            ILogger<AddInformationCommand> logger)
        {
            _mainViewModel = mainViewModel;
            _stringInversionRepository = stringInversionRepository;
            _logger = logger;
        }

        public bool CanExecute(object parameter) => true;

        public async void Execute(object parameter)
        {
            _mainViewModel.SelectedModel.Information.Value = _mainViewModel.SelectedModel.Information.Value.Inverse();

            var info = await _stringInversionRepository.AddInfo(_mainViewModel.SelectedModel.Information);
            var infoJson = JsonSerializer.Serialize(info);
            _logger.LogInfo(infoJson);

            var newModel = await _stringInversionRepository.GetNewModel(info);

            _mainViewModel.Models.Remove(_mainViewModel.SelectedModel);
            _mainViewModel.Models.Add(newModel);
        }

#pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067
    }
}