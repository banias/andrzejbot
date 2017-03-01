﻿using AndrzejPBot.LinkSource;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Threading.Tasks;

namespace AndrzejPBot.Dialogs
{

    //https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/cfa29b4c-5e0b-45e0-a889-bac29c2a9610?subscription-key=b88159df4a464d65866c9920f007cf29&q=siema&verbose=true

    [LuisModel("cfa29b4c-5e0b-45e0-a889-bac29c2a9610", "b88159df4a464d65866c9920f007cf29")]
    [Serializable]
    public class AndrzejLuisDialog: LuisDialog<object>
    {
        private static Random _random = new Random();

        [LuisIntent("")]
        public async Task GetRandomLink(IDialogContext context, LuisResult result)
        {
            var linkSource = new BoredPandaLinkSource();
            await context.PostAsync(linkSource.GetRandomLink());
            context.Wait(MessageReceived);
        }

        [LuisIntent("Greeting")]
        public async Task GetGreeting(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("co znowu...");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Comeback")]
        public async Task GetComeback(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("chyba ty!");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Turtle")]
        public async Task GetTurtleResponse(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("https://www.youtube.com/watch?v=H4uVqM_HFiY");
            context.Wait(MessageReceived);
        }

    }
}