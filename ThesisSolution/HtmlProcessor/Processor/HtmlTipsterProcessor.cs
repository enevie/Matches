using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using HtmlAgilityPack;
using NLog;

namespace HtmlHelpers.Processor
{
    public class HtmlTipsterProcessor : IHtmlProcessor
    {
        private readonly IDocumentRepository<TipsterMatch> _tipsterRepository;
        private readonly ILogger _logger;
        private const string pattern = "-(\\d+)\">";

        public HtmlTipsterProcessor(IDocumentRepository<TipsterMatch> tipsterRepository, ILogger logger)
        {
            _tipsterRepository = tipsterRepository;
            _logger = logger;
        }

        public void ProcessNodeCollection(HtmlNodeCollection rawData)
        {
            var filtredData = rawData.Where(x => x.ChildNodes.Any(z => z.Name.Equals("td")));

            foreach (var data in filtredData)
            {
                var rawModel = data.ChildNodes.Where(z => z.Name.Equals("td")).ToList();
                var tipsterMatchModel = new TipsterMatch();

                try
                {
                    var firstTeamName = rawModel[1].ChildNodes[1].InnerHtml.Split('-')[0].Trim();
                    var secondTeamName = rawModel[1].ChildNodes[1].InnerHtml.Split('-')[1].Trim();

                    tipsterMatchModel.FirstTeamtName = firstTeamName;
                    tipsterMatchModel.SecondTeamName = secondTeamName;

                    if (secondTeamName.Contains("bold"))
                    {
                        tipsterMatchModel.SecondTeamName = Regex.Match(secondTeamName, @"(?<=>)([^>]+)(?=<)").Value;
                    }
                    if (firstTeamName.Contains("bold"))
                    {
                        tipsterMatchModel.FirstTeamtName = Regex.Match(firstTeamName, @"(?<=>)([^>]+)(?=<)").Value;
                    }

                    tipsterMatchModel.Id = Regex.Match(rawModel[1].InnerHtml, @pattern).Groups[1].Value;
                    tipsterMatchModel.FirstTeamCoefficient = double.Parse(rawModel[3].InnerHtml);
                    tipsterMatchModel.SecondTeamCoefficient = double.Parse(rawModel[5].InnerHtml);
                    tipsterMatchModel.EqualResultCoefficient = double.Parse(rawModel[4].InnerHtml);
                    tipsterMatchModel.DateOfMatch = DateTime.Today;
                    try
                    {
                        tipsterMatchModel.FirstTeamGoals = int.Parse(rawModel[2].InnerHtml.Split('-')[0].Trim());
                        tipsterMatchModel.SecondTeamGoals = int.Parse(rawModel[2].InnerHtml.Split('-')[1].Trim());
                    }
                    catch (Exception e) { }
                   
                }
                catch (Exception e)
                {
                    _logger.Log(LogLevel.Error, e.ToString);
                    continue;
                }

                _tipsterRepository.Upsert(tipsterMatchModel);
            }
        }
    }
}
