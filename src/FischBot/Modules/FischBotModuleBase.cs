using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using FischBot.Services;

namespace FischBot.Modules
{
    public class FischBotModuleBase<T> : ModuleBase where T : class, ICommandContext
    {
        private readonly IDiscordModuleService _module;

        public FischBotModuleBase(IDiscordModuleService moduleService) : base()
        {
            _module = moduleService;
        }

        protected override async Task<IUserMessage> ReplyAsync(string message = null, bool isTTS = false, Embed embed = null, RequestOptions options = null)
        {
            return await _module.ReplyAsync(Context, message, isTTS, embed, options);
        }
    }
}