using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
/// <summary>
/// Can Ahmet Ceylan
/// canahmetceylan.com
/// canahmetceylan@outlook.com
/// </summary>
namespace KeyPad
{

    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        #region 'Public Properties'
        private string _result;
        public string Result
        {
            get { return _result; }
            private set { _result = value; this.OnPropertyChanged("Result"); }
        }

        #endregion
        #region 'Construcktor'

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        #endregion
        #region 'Events'
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            switch (button.CommandParameter.ToString())
            {
                case "ESC":
                   // this.DialogResult = false;
                    this.Close();
                    break;

                case "ENTER":
                    this.DialogResult = true;
                    break;
                case "BACK":
                    if (Result.Length > 0)
                    {
                        Result = Result.Remove(Result.Length - 1);
                    }
                    break;

                default:
                    Result += button.Content.ToString();
                    break;
            }

        }
        #endregion
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged; 
        private void OnPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }
}
