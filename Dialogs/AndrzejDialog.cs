using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using AndrzejPBot.LinkSource;

namespace AndrzejPBot.Dialogs
{
    [Serializable]
    public class AndrzejDialog : IDialog
    {
        private static Random _random = new Random();

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageActivity);
        }

        private async Task MessageActivity(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            if(activity.Text.Contains("hej"))
            {
                await context.PostAsync("co znowu...");
            }
            else
            {
                var linkSource = new BoredPandaLinkSource();
                await context.PostAsync(linkSource.GetRandomLink());
            }

            context.Wait(MessageActivity);
        }
    }
}