using System;

namespace Models
{
    public class InformationModel : BaseModel
    {
        private string _value = string.Empty;

        public Guid Id { get; set; }

        public string Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }
    }
}