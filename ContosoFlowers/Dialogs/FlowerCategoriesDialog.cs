using ContosoFlowers.Models;

namespace ContosoFlowers.Dialogs
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using BotAssets.Dialogs;
    using Microsoft.Bot.Builder.Dialogs;
    using Microsoft.Bot.Connector;
    using Properties;
    using Services;
    using Services.Models;

    [Serializable]
    public class FlowerCategoriesDialog : PagedCarouselDialog<string>
    {
        private readonly IRepository<FlowerCategory> repository;

        public FlowerCategoriesDialog(IRepository<FlowerCategory> repository)
        {
            this.repository = repository;
        }

        public override string Prompt => "Please select a vendor:";

        public override PagedCarouselCards GetCarouselCards(int pageNumber, int pageSize)
        {
            var pagedResult = this.repository.RetrievePage(pageNumber, pageSize);
            var cards = new List<HeroCard>();

            var vendors = Vendor.GetVendors();
            foreach (var v in vendors)
            {
                var images = new List<CardImage>();
                var image = new CardImage(v.Url, v.Name);
                images.Add(image);
                var buttons = new List<CardAction>();
                var action = new CardAction(ActionTypes.ImBack, Resources.FlowerCategoriesDialog_Select, value: v.Name);
                buttons.Add(action);

                cards.Add(new HeroCard()
                {
                    Text = v.Name,
                    Title = v.Title,
                    Subtitle = v.Subtitle,
                    Images = images,
                    Buttons = buttons
                });
            }

            return new PagedCarouselCards
            {
                Cards = cards,
                TotalCount = pagedResult.TotalCount
            };

            //var carouselCards = pagedResult.Items.Select(it => new HeroCard
            //{
            //    Title = it.Name,
            //    Images = new List<CardImage> { new CardImage(it.ImageUrl, it.Name) },
            //    Buttons = new List<CardAction> { new CardAction(ActionTypes.ImBack, Resources.FlowerCategoriesDialog_Select, value: it.Name) }
            //});

            //return new PagedCarouselCards
            //{
            //    Cards = carouselCards,
            //    TotalCount = pagedResult.TotalCount
            //};
        }

        public override async Task ProcessMessageReceived(IDialogContext context, string flowerCategoryName)
        {
            context.Done(flowerCategoryName);

            //var flowerCategory = this.repository.GetByName(flowerCategoryName);

            //if (flowerCategory != null)
            //{
            //    context.Done(flowerCategory.Name);
            //}
            //else
            //{
            //    await context.PostAsync(string.Format(CultureInfo.CurrentCulture, Resources.FlowerCategoriesDialog_InvalidOption, flowerCategoryName));
            //    await this.ShowProducts(context);
            //    context.Wait(this.MessageReceivedAsync);
            //}
        }
    }
}