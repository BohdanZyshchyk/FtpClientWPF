using MailKit;
using MailKit.Net.Imap;
using MimeKit;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

namespace WpfMailClient.Model
{
    public class MailHelper
    {
        private ImapClient client { get; set; }
        string[] CommonSentFolderNames = { "Sent Items", "Sent Mail", "Sent Messages", /* maybe add some translated names */ };
        public MailHelper()
        {
            client = new ImapClient();
            client.Connect("imap.gmail.com", 993, true);
            client.Authenticate(AuthData.mAddress, AuthData.mPass);
            client.Inbox.Open(MailKit.FolderAccess.ReadOnly);
            InboxMessages = new ObservableCollection<MimeMessage>();
            OutboxMessages = new ObservableCollection<MimeMessage>();
            foreach (var item in client.Inbox.Take(20))
                InboxMessages.Add(item);

            GetSentFolder(client, CancellationToken.None).
           

        }
        IMailFolder GetSentFolder(ImapClient client, CancellationToken cancellationToken)
        {
            var personal = client.GetFolder(client.PersonalNamespaces[0]);

            return personal.GetSubfolders(false, cancellationToken).FirstOrDefault(x => CommonSentFolderNames.Contains(x.Name));
        }

        public ObservableCollection<MimeMessage> InboxMessages { get; set; }
        public ObservableCollection<MimeMessage> OutboxMessages { get; set; }

    }
}
