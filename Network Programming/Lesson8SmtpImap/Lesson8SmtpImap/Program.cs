using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using System.Net;
using System.Net.Mail;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

#region SMTP GMAIL


//using var client = new SmtpClient("smtp.google.com", 587);

//client.EnableSsl = true;
//client.UseDefaultCredentials = false;

//client.Credentials = new NetworkCredential(userName: "yourMail",
//                                            password: "yourAppPassword");

//var message = new MailMessage()
//{
//    Body = "Salam Elshan",
//    Subject = "Just for fun",
//    IsBodyHtml = false,
//    From = new MailAddress("yourMail", "Babat Insan"),
//};

//message.To.Add("namiq_rasullu@itstep.org");

//client.Send(message);

//Console.WriteLine("sent");
#endregion


#region SMTP MAIL.RU

//using var client = new SmtpClient("smtp.mail.ru", 587);

//client.EnableSsl = true;

//client.Credentials = new NetworkCredential(userName: "yourMail",
//                                            password: "yourAppPassword");

//var message = new MailMessage()
//{
//    Body = "<h1 style='color:red'>Salam!!!</h1>",
//    Subject = "Just for fun",
//    IsBodyHtml = true,
//    From = new MailAddress("yourMail", "Babat Insan"),
//};

//message.CC.Add("toMail");
//message.To.Add("toMail");

//client.Send(message);

//Console.WriteLine("sent");

#endregion
void foo(string message = "salam", int val = 2)
{

}

#region IMAP

using var imap = new ImapClient();

imap.Connect("imap.gmail.com", 993);
imap.Authenticate(userName: "yourMail", password: "yourAppPassword");



////var inbox = imap.GetFolder("Inbox");
var folder = imap.Inbox;
//var sent = imap.GetFolder(SpecialFolder.Sent);
folder.Open(FolderAccess.ReadOnly);

var ids = folder.Search(SearchQuery.All);

foreach (var id in ids)
{
    Console.WriteLine($"{id}: {folder.GetMessage(id).Subject}");
}

//sent.Open(FolderAccess.ReadWrite);
//UniqueId id = new(49);
//sent.SetFlags(id, MessageFlags.Deleted, true);
//sent.Expunge();


#endregion

