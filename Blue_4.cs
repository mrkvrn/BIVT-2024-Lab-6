using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_6.Blue_4;

namespace Lab_6
{
    public class Blue_4
    {
        public struct Team
        {
            private string _name;
            private int[] _scores;

            public string Name => _name;
            public int[] Scores
            {
                get
                {
                    if (_scores == null) return null;
                    int[] scores = new int[_scores.Length];
                    for (int i = 0; i < _scores.Length; i++)
                    {
                        scores[i] = _scores[i];
                    }
                    return scores;
                }
            }

            public int TotalScore
            {
                get
                {
                    if (_scores == null) return 0;
                    int total_score = 0;
                    for (int i = 0; i < _scores.Length; i++)
                    {
                       total_score += _scores[i];
                    }
                    return total_score;
                }
            }

            public Team(string name)
            {
                _name = name;
                _scores = new int[0];
            }

            public void PlayMatch(int result)
            {
                if (_scores == null) return;
                int[] newres = new int[_scores.Length + 1];
                for (int i = 0; i < newres.Length - 1; i++)
                {
                    newres[i] = _scores[i];
                }
                newres[newres.Length - 1] = result;
                _scores = newres;
            }

            public void Print()
            {
                Console.WriteLine($"{_name}: {TotalScore}");
            }
        }

        public struct Group
        {
            private string _name;
            private Team[] _teams;

            private int index;

            public string Name => _name;
            public Team[] Teams => _teams;

            public Group(string name)
            {
                _name = name;
                _teams = new Team[12];
                index = 0;
            }

            public void Add(Team team)
            {
                if (_teams == null || _teams.Length == 0 || index >= _teams.Length) return;
                _teams[index] = team;
                index++;

            }

            public void Add(Team[] teams)
            {
                if (teams == null || teams.Length == 0 || _teams == null || _teams.Length == 0 || index >= _teams.Length) return;
                int count = 0;
                while (index < _teams.Length && count < teams.Length)
                {
                    _teams[index] = teams[count];
                    count++;
                    index++;
                }
            }

            public void Sort()
            {
                if (_teams == null || _teams.Length == 0) return;
                for (int i = 0; i < _teams.Length; i++)
                {
                    for (int j = 0; j < _teams.Length - i - 1; j++)
                    {
                        if (_teams[j].TotalScore < _teams[j+1].TotalScore)
                        {
                            (_teams[j], _teams[j + 1]) = (_teams[j + 1], _teams[j]);
                        }
                    }    
                }
            }

            public static Group Merge(Group group1, Group group2, int size)
            {
                Group group3 = new Group("Финалисты");
                int half = size / 2;
                int i = 0;
                int j = 0;
                while (i < half && j < half)
                {
                    if (group1.Teams[i].TotalScore >= group2.Teams[j].TotalScore)
                    {
                        group3.Add(group1.Teams[i]);
                        i++;
                    }
                    else
                    {
                        group3.Add(group2.Teams[j]);
                        j++;
                    }
                }
                while (i < half)
                {
                    group3.Add(group1.Teams[i]);
                    i++;
                }
                while (j < half)
                {
                    group3.Add(group1.Teams[j]);
                    j++;
                }
                return group3;
            }

            public void Print()
            {
                Console.WriteLine(_name);
                for (int i = 0; i < index; i++)
                {
                    _teams[i].Print();
                }
            }
        }
    }
}
