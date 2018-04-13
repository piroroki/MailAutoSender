namespace SendMailApplication.Commands
{
    using System;
    using System.Windows;
    using System.Windows.Input;
    using System.Net.Mail;

    public class SendMailDialogCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        static private long call_count;            
        static private System.Timers.Timer timer;

        static private System.Net.Mail.MailMessage mailMessage { get; set; }
        //public System.Net.Mail.MailMessage MailMessage

        static public System.Net.Mail.SmtpClient smtp { get; set; }
        //public System.Net.Mail.SmtpClient Smtp { get { return this.smtp} set { this.smtp = value; } }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var second = 60;
            //var timer = Timer.te
            timer = new System.Timers.Timer();

            timer.Interval = 1000.0 * second;                // Intervalの設定単位はミリ秒
            timer.Elapsed += Timer1_Elapsed;       // タイマイベント処理(時間経過後の処理)を登録
            timer.Enabled = true;

            //idとパスワード
            string id = "mickey.yamamoto3@gmail.com";
            string pass = "*****"; //いつものをいれる
            string fromEMail = "mickey.yamamoto3@gmail.com";
            string toEMail = "mickey.yamamoto3@gmail.com";

            //本文とタイトル 一行目をタイトルにする
            string body, subject;
            string[] subject1;
            body = parameter as string;
            subject1 = body.Split('\r');
            subject = subject1[0];

            //GMail Initialize
            smtp = new System.Net.Mail.SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;

            //GMail認証
            smtp.Credentials = new System.Net.NetworkCredential(id, pass);
            //SSL
            smtp.EnableSsl = true;
            mailMessage = new System.Net.Mail.MailMessage(fromEMail, toEMail, subject, body);


            var mailTitle = parameter as string;
            var message = mailTitle + "送信完了！";
            MessageBox.Show(message);
        }
        private static void Timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if(call_count > 10) {
                timer.Enabled = false; // Enableプロパティをfalseにすると次からタイマイベントは発生ない
            }
            // タイマイベントの処理
            Console.WriteLine(string.Format("Called Timer1_Elapsed. Count={0}", ++call_count));

            //メール送信
            smtp.Send(mailMessage);

        }
    }

}
