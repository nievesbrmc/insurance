using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{    
    /// <summary>
    /// Interaction logic for SalesWindows.xaml
    /// </summary>
    public partial class SalesWindows : Window
    {
        bool IsClient { get; set; } = false;
        bool IsCash { get; set; } = false;
        public SalesWindows()
        {
            if (IsClient  || !IsCash)
            {
                EnabledisableGeneralInformation(false);
                EnabledisableAddressInfo(false);
                EnabledisableMobileData(false);
            }

            if (IsClient || IsCash)
            {
                //precargar información
            }

            InitializeComponent();
        }

        private void EnabledisableMobileData(bool isEnable)
        {
            enableDisableControl(Branch, isEnable);
            enableDisableControl(Model, isEnable);
            enableDisableControl(Color, isEnable);
            enableDisableControl(Ammount, isEnable);
            enableDisableControl(Screen, isEnable);
            enableDisableControl(Year, isEnable);
            enableDisableControl(Ram, isEnable);
            enableDisableControl(Storage, isEnable);
            enableDisableControl(Cpu, isEnable);
        }

        private void EnabledisableGeneralInformation(bool isEnable)
        {
            enableDisableControl(FullName, isEnable);
            enableDisableControl(LastName, isEnable);
            enableDisableControl(SecondLastName, isEnable);
        }

        private void EnabledisableAddressInfo(bool isEnable)
        {
            enableDisableControl(ZipCode, isEnable);
            enableDisableControl(State, isEnable);
            enableDisableControl(Street, isEnable);
            enableDisableControl(NumExt, isEnable);
            enableDisableControl(NumInt, isEnable);
            enableDisableControl(Neighborhood, isEnable);
            enableDisableControl(City, isEnable);
            enableDisableControl(Municipio, isEnable);
        }

        private void enableDisableControl(TextBox textBox, bool isEnable)
        {
            textBox.IsEnabled = isEnable;
        }

        private void enableDisableControl(ComboBox textBox, bool isEnable)
        {
            textBox.IsEnabled = isEnable;
        }

        private void hideShowGrid(Grid  hide, Visibility visible)
        {
            hide.Visibility = visible;
        }

        private void hideShowLabelError(Label control, Visibility visibility, string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                control.Content = message;
            }

            control.Visibility = visibility;
        }

        private void btnGeneralInformation_Click(object sender, RoutedEventArgs e)
        {
            if (IsClient)
            {
                //no valida nada
            }
            else
            {
                //valida los campos
                DateTime? dateOfBorn = Helpers.GetDate(DateOfBorn.Text);
                if (!dateOfBorn.HasValue | !Helpers.yearsOldValidate(dateOfBorn))
                {
                    hideShowLabelError(lblGeneralInformationErrors, Visibility.Visible, "El cliente no puede realizar la compra del seguro por que es menor de edad.");
                }
                hideShowGrid(GeneralInformation, Visibility.Hidden);
            }
        }

        private void btnContactInformation_Click(object sender, RoutedEventArgs e)
        {
            hideShowGrid(GeneralInformation, Visibility.Hidden);
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            hideShowGrid(AddressInformation, Visibility.Hidden);
            hideShowGrid(GeneralInformation, Visibility.Visible);
        }

        private void btnReturn1_Click(object sender, RoutedEventArgs e)
        {
            hideShowGrid(ProductInformation, Visibility.Hidden);
            hideShowGrid(AddressInformation, Visibility.Visible);
        }

        private void btnSendData_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
