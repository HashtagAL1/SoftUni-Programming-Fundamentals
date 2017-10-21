using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            var teamMembers = new Dictionary<string, List<string>>();//team, list of members
            var teamCreators = new Dictionary<string, string>();
            List<Team> teams = new List<Team>();
            int n = int.Parse(Console.ReadLine());

            //creation of teams
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split('-');
                
                string creatorName = input[0];
                string teamName = input[1];
                if (GetIndexOfTeam(teams,teamName) != -1)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (IsCaptain(teams,creatorName))
                {
                    Console.WriteLine($"{creatorName} cannot create another team!");
                }
                else
                {
                    Team team = new Team(creatorName, teamName);
                    teams.Add(team);
                    teamMembers[team.TeamName] = new List<string>();
                    teamCreators[teamName] = creatorName;
                    Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
                }
            }

            //join members input and processing
            string joinInput = Console.ReadLine();
            while (!(joinInput.Equals("end of assignment")))
            {
                string[] info = joinInput.Split(new char[] { '-', '>'},StringSplitOptions.RemoveEmptyEntries);
                
                string member = info[0];                
                string team = info[1];

                if (GetIndexOfTeam(teams,team) == -1)
                 {
                    Console.WriteLine($"Team {team} does not exist!");
                }
                else if (IsCaptain(teams,member))
                {
                    Console.WriteLine($"Member {member} cannot join team {team}!");
                }
                else if (ContainsPlayer(teamMembers,member))
                {
                    Console.WriteLine($"Member {member} cannot join team {team}!");
                }
                else
                {
                    teamMembers[team].Add(member);
                }

                joinInput = Console.ReadLine();
            }

            List <string> disbandedTeams = GetDisbandedTeams(teamMembers);
            Dictionary<string, List<string>>  validTeams= GetValidTeams(teamMembers);


            foreach (var team in validTeams.Keys)
            {
                Console.WriteLine(team);
                Console.WriteLine($"- {teamCreators[team]}");
                foreach (var member in validTeams[team])
                {
                    Console.WriteLine($"-- {member}");
                }
            }
            Console.WriteLine("Teams to disband:");
            for (int i = 0; i < disbandedTeams.Count; i++)
            {
                Console.WriteLine($"{disbandedTeams[i]}");
            }
        }       
        
        public static Dictionary<string, List<string>> GetValidTeams(Dictionary<string, List<string>> dict)
        {
            var valid = new Dictionary<string, List<string>>();
            foreach (var team in dict.Keys)
            {
                if (dict[team].Count > 0)
                {
                    valid[team] = dict[team];
                }
            }            
            return valid.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
        }//returns a sorted dictionary (by descending members count, then by ascending name) of teams with members

        public static List<string> GetDisbandedTeams(Dictionary<string, List<string>> dict)
        {
            List<string> disbanded = new List<string>();
            foreach (var team in dict.Keys)
            {
                if (dict[team].Count == 0)
                {
                    disbanded.Add(team);
                }
            }
            List<string> result = disbanded.OrderBy(x => x).ToList();
            return result;
        }//returns a list of teams without members

        public static bool ContainsPlayer(Dictionary<string, List<string>> dict, string player)
        {
            foreach (var team in dict.Keys)
            {
                if (dict[team].Contains(player))
                {
                    return true;
                }
            }
            return false;
        } //check if players is already in a team

        public static bool IsCaptain(List<Team> teams, string player)
        {
            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].Creator.Equals(player))
                {
                    return true;
                }
            }
            return false;
        } //check if player is a creator of a team

        public static int GetIndexOfTeam(List<Team> teams, string teamName)
        {
            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].TeamName.Equals(teamName))
                {
                    return i;
                }
            }
            return -1;
        } //check if a team already exists

        
        
    }

    class Team
    {
        public string Creator { get; set; }
        public string TeamName { get; set; }

        public Team(string creator, string name)
        {
            this.Creator = creator;
            this.TeamName = name;
        }
    }

    
    

}
