using System;
using System.Collections.Generic;
using System.Linq;

namespace TournamentRankingSystem
{
    public class Team
    {
        public string Name { get; set; }
        public int Points { get; set; }
    }

    public class Match
    {
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public int Team1Score { get; set; }
        public int Team2Score { get; set; }

        public Match(Team t1, Team t2)
        {
            Team1 = t1;
            Team2 = t2;
        }

        public Match Clone()
        {
            return new Match(Team1, Team2)
            {
                Team1Score = this.Team1Score,
                Team2Score = this.Team2Score
            };
        }
    }

    public class Tournament
    {
        private SortedList<(int, string), Team> _rankings = new();
        private LinkedList<Match> _schedule = new();
        private Stack<Match> _undoStack = new();

        private void UpdateRankings()
        {
            _rankings.Clear();

            var teams = _schedule
                .SelectMany(m => new[] { m.Team1, m.Team2 })
                .Distinct();

            foreach (var team in teams)
            {
                var key = (-team.Points, team.Name);
                _rankings[key] = team;
            }
        }

        public void ScheduleMatch(Match match)
        {
            _schedule.AddLast(match);
            UpdateRankings();
            Console.WriteLine("Match Scheduled");
        }

        public void RecordMatchResult(Match match, int team1Score, int team2Score)
        {
            _undoStack.Push(match.Clone());

            match.Team1Score = team1Score;
            match.Team2Score = team2Score;

            if (team1Score > team2Score)
                match.Team1.Points += 3;
            else if (team2Score > team1Score)
                match.Team2.Points += 3;
            else
            {
                match.Team1.Points += 1;
                match.Team2.Points += 1;
            }

            UpdateRankings();
        }

        public void UndoLastMatch()
        {
            if (_undoStack.Count == 0) return;

            var last = _undoStack.Pop();

            if (last.Team1Score > last.Team2Score)
                last.Team1.Points -= 3;
            else if (last.Team2Score > last.Team1Score)
                last.Team2.Points -= 3;
            else
            {
                last.Team1.Points -= 1;
                last.Team2.Points -= 1;
            }

            UpdateRankings();
        }

        public List<Team> GetRankings()
        {
            return _rankings.Values.ToList();
        }

        public int GetTeamRanking(Team team)
        {
            int index = _rankings.Values.IndexOf(team);
            return index + 1;
        }
    }

    public class Program
    {
        public static void Main()
        {
            Tournament tournament = new Tournament();

            Team teamA = new Team { Name = "Team Alpha", Points = 0 };
            Team teamB = new Team { Name = "Team Beta", Points = 0 };

            Match match = new Match(teamA, teamB);

            tournament.ScheduleMatch(match);

            tournament.RecordMatchResult(match, 3, 1);

            var rankings = tournament.GetRankings();

            Console.WriteLine(rankings[0].Name);

            tournament.UndoLastMatch();

            Console.WriteLine(teamA.Points);
        }
    }
}
