using MiNET;
using MiNET.Plugins.Attributes;
using MiNET.Items;
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
            if (!PermissionManager.Manager.CheckCurrentUserPermission(sender)) return;
            var player = Plugin.GetPlayer(username);
            if (player == null)
            {
                sender.SendMessage("플레이어를 찾을 수 없습니다.");
                return;
            }
            player.Inventory.Clear();
            sender.SendMessage($"{username}님의 인벤토리의 아이템들을 모두 삭제했습니다.");
            player.SendMessage($"관리자 {sender.Username}님이 당신의 인벤토리의 아이템들을 모두 삭제했습니다.");
        }

        [Command(Name = "clearinventory")]
        public void Execute(Player sender, int slot)
        {
            var pi = sender.Inventory;
            for (int i = 0; i > pi.Slots.Count; i++)
            {
                if (i == slot) pi.Slots[i] = new ItemAir();
                break;
            }
            sender.SendMessage($"당신의 인벤토리 {slot} 슬롯의 아이템(들)을 모두 삭제했습니다.");
        }

        [Command(Name = "clearinventory")]
        public void Execute(Player sender, string username, int slot)
        {
            if (!PermissionManager.Manager.CheckCurrentUserPermission(sender)) return;
            var pi = sender.Inventory;
            var player = Plugin.GetPlayer(username);
            if (player == null)
            {
                sender.SendMessage("플레이어를 찾을 수 없습니다.");
                return;
            }
            for (int i = 0; i > pi.Slots.Count; i++)
            {
                if (i == slot) pi.Slots[i] = new ItemAir();
                break;
            }
            sender.SendMessage($"{username}님의 인벤토리 {slot} 슬롯의 아이템(들)을 모두 삭제했습니다.");
            player.SendMessage($"관리자 {sender.Username}님이 당신의 인벤토리 {slot} 슬롯의 아이템(들)을 모두 삭제했습니다.");
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

        [Command]
        public void ci(Player sender, int slot)
        {
            Execute(sender, slot);
        }

        [Command]
        public void ci(Player sender, string username, int slot)
        {
            Execute(sender, username, slot);
        }
        #endregion
    }
}