using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.GenericValidation;

namespace WpfApp1.Entity
{
    public class NotClientCoppel:ObservableObject 
    {
        public NotClientCoppel()
        {
            
        }
        [Required(ErrorMessage ="El campo nombre es obligatorio")]
        private string _Name;
        [Required(ErrorMessage = "El campo apellido paterno es obligatorio")]
        private string _LastName;
        [Required(ErrorMessage = "El campo apellido materno es obligatorio")]
        private string _SecondLastName;

        public string Name 
        { 
            get => _Name; 
            set 
            {
                ValidateProperty(value, "Name");
                OnPropertyChanged(ref _Name, value);
            } 
        }
        public string LastName
        {
            get => _LastName;
            set
            {
                ValidateProperty(value, "LastName");
                OnPropertyChanged(ref _LastName, value);
            }
        }
        public string SecondLastName
        {
            get => _SecondLastName;
            set
            {
                ValidateProperty(value, "SecondLastName");
                OnPropertyChanged(ref _SecondLastName, value);
            }
        }

        private void ValidateProperty<T>(T value, string name)
        {
            Validator.ValidateProperty(value, new ValidationContext(this, null, null)
            {
                MemberName = name
            });
        }
    }
}