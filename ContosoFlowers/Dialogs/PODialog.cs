using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ContosoFlowers.BotAssets.Dialogs;
using ContosoFlowers.Properties;
using ContosoFlowers.Services;
using ContosoFlowers.Services.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace ContosoFlowers.Dialogs
{
    [Serializable]
    public class PODialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            //await context.PostAsync("Prompt goes here...");

            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var searchContent = await result;

            //await context.PostAsync($"Do you have the PR or vendor number?");

            PromptDialog.Confirm(
                context,
                AfterNumberSelected,
                "Do you have the PR or vendor number?",
                "Didn't get that!",
                promptStyle: PromptStyle.None);

            context.Wait(MessageReceivedAsync);

        }

        private async Task AfterNumberSelected(IDialogContext context, IAwaitable<bool> awaitable)
        {
            var confirm = await awaitable;
            if (confirm)
            {
                //this.count = 1;
                await context.PostAsync("Reset count.");
            }
            else
            {
                await context.PostAsync("Did not reset count.");
            }
            context.Wait(MessageReceivedAsync);
        }
    }
}