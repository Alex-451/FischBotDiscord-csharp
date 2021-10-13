using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using FischBot.Helpers;
using FischBot.Services.DiscordModuleService;

namespace FischBot.Modules
{
    public class FunModule : FischBotModuleBase<SocketCommandContext>
    {
        private static readonly string[] _emojiPartyEmojis =
        {
            "😇", "😍", "🤑", "🤓", "🤖", "👽", "👾", "👻", "💯", "🤟",
            "👀", "🍿", "🍔", "📞", "📀", "📸", "💹", "💰", "✏", "📊",
            "🔓", "🔫", "📡", "🔭", "💉", "⚰", "☢", "⚜", "🎉", "🥳",
            "🎊", "🤩", "☄", "🎂", "🥮", "🍪", "⚡", "⚔", "☘", "☠",
            "🤭", "🤠", "🥺", "😈", "☝", "✊", "🦊", "🐠"
        };

        public FunModule(IDiscordModuleService moduleService) : base(moduleService)
        {
        }

        [Command("emojiparty")]
        [Summary("Throws an emoji party!")]
        public async Task ThrowEmojiParty()
        {
            var emojisToPartyWith = _emojiPartyEmojis.Distinct().Shuffle().Take(20);

            foreach (var emoji in emojisToPartyWith)
            {
                await Context.Message.AddReactionAsync(new Emoji(emoji));
            }
        }

        [Command("lamp")]
        [Summary("Announces that the lamp has spoken, thus ending arguments.")]
        public async Task TheLampHasSpoken()
        {
            await ReplyAsync("https://raw.githubusercontent.com/flyingfisch/FischBotDiscord-csharp/master/assets/the-lamp-has-spoken.png");
        }
    }
}