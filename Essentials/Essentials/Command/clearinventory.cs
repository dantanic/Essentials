using MiNET;
using MiNET.Plugins.Attributes;
using MiOP;

namespace Essentials.Command
{
    public class ClearInventory
    {
        private Essentials Plugin;

        public ClearInventory(Essentials plugin)
        {
            Plugin = plugin;
        }

        [Command(Name = "clearinventory")]
        public void Execute(Player sender)
        {
            sender.SendMessage("당신의 인벤토리의 아이템들을 모두 삭제했습니다.");
            sender.Inventory.Clear();
        }

        [Command(Name = "clearinventory")]
        public void Execute(Player sender, string username)
        {
            var player = Plugin.GetPlayer(username);
            if (player == null)
            {
                sender.SendMessage("플레이어를 찾을 수 없습니다.");
                return;
            }
            sender.SendMessage($"{username}님의 인벤토리의 아이템들을 모두 삭제했습니다.");
            player.SendMessage($"관리자 {sender.Username}님이 당신의 인벤토리의 아이템들을 모두 삭제했습니다.");
            player.Inventory.Clear();
        }


        #region short command
        [Command]
        public void ci(Player sender)
        {
            Execute(sender);
        }

        [Command]
        public void ci(Player sender, string username)
        {
            Execute(sender, username);
        }
        #endregion
    }
}