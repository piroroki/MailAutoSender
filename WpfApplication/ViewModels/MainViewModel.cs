namespace SendMailApplication.ViewModels
{
    using SendMailApplication.Commands;
    using SendMailApplication.Models;

    public class MainViewModel
    {
        public MainViewModel()
        {
            this.OpenMessageDialogCommand = new SendMailDialogCommand();
            this.UserModel = new UserModel();
        }

        public SendMailDialogCommand OpenMessageDialogCommand { get; set; }

        public UserModel UserModel { get; set; }
    }
}
