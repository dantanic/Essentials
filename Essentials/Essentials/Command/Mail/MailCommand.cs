using MiNET;
using MiNET.Plugins.Attributes;

namespace Essentials.Command.Mail
{
    public class MailCommand : Mail
    {
        private Essentials Plugin;

        public MailCommand(Essentials plugin)
        {
            Plugin = plugin;
        }

        [Command(Name = "mail")]
        public void Execute(Player sender, string args, string name, string title, string msg)
        {
            if (args == "send")
            {
                sender.SendMessage("Successfully sent mail.");
                foreach (var item in Plugin.plist)
                {
                    if (item.Username == name)
                    {
                        item.SendMessage($"New mail arrived \"{name}\"");
                        send(item, title, msg);
                    }
                }
            }
        }
        [Command(Name = "mail")]
        public void Execute(Player sender, string args, string title)
        {
            if (args == "see")
            {
                see(sender, title);
            }
            if (args == "remove")
            {
                sender.SendMessage("Successfully removed this mail.");
                remove(sender, title);
            }
        }
    }
}
