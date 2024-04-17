using Domain.Dtos;
using Domain.Models.Configuration;
using HtmlAgilityPack;
using Microsoft.Extensions.Options;
using Services.Interfaces;

namespace Services;

public class ActorsScrapperService(IOptions<ActorsSourceConfig> actorsSourceConfig, IActorsService actorsService) : IActorsScrapperService
{
    public async Task ScrapActors()
    {
        var web = new HtmlWeb();
        var doc = web.Load(actorsSourceConfig.Value.MoviesHtmlSource);

        var nodes = doc.DocumentNode.SelectNodes(actorsSourceConfig.Value.ActorHtmlContainerId);

        if (nodes is null) return;
        var actors = (from htmlNode in nodes
            let name = htmlNode.SelectSingleNode(actorsSourceConfig.Value.NameHtmlElementId).InnerText.Trim()
            let rank = htmlNode.SelectSingleNode(actorsSourceConfig.Value.RankHtmlElementId)
                .InnerText.Trim()
                .Split(" ")
                .First()
            let type = htmlNode.SelectSingleNode(actorsSourceConfig.Value.TypeHtmlElementId).InnerText.Trim()
            let movie = htmlNode.SelectSingleNode(actorsSourceConfig.Value.MovieHtmlElementId).InnerText.Trim()
            let source = actorsSourceConfig.Value.Name
            select new ActorDetailsDto()
            {
                Id = Guid.NewGuid(), 
                Name = name, 
                Rank = int.Parse(rank), 
                Type = type, 
                Movie = movie, 
                Source = source
            }).ToList();
        await actorsService.AddActorsAsync(actors);
    }
}