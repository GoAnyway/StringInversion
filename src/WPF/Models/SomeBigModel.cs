using System;

namespace Models
{
    public class SomeBigModel : BaseModel
    {
        private InformationModel _information = new InformationModel();

        public InformationModel Information
        {
            get => _information;
            set
            {
                _information = value;
                OnPropertyChanged();
            }
        }

        public LogModel Log { get; set; }

        public override string ToString() => $"Info: {Information?.Value}{Environment.NewLine}" +
                                             $"Log: {Log?.Time}, {Log?.Info}";
    }
}