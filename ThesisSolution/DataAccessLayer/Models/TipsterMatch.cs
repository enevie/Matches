using System;
using DataAccessLayer.Models.Contract;

namespace DataAccessLayer.Models
{
    public class TipsterMatch : IDocument
    {
        public string Id { get; set; }
        public string FirstTeamtName { get; set; }
        public string SecondTeamName { get; set; }
        public double FirstTeamCoefficient { get; set; }
        public double SecondTeamCoefficient { get; set; }
        public double EqualResultCoefficient { get; set; }
        public int? FirstTeamGoals { get; set; }
        public int? SecondTeamGoals { get; set; }
        public DateTime DateOfMatch { get; set; }
    }
}
