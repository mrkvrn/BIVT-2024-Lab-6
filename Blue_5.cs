﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_5
    {
        public struct Sportsman
        {
            private string _name;
            private string _surname;
            private int _place;

            public string Name => _name;
            public string Surname => _surname;
            public int Place => _place;

            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _place = 0;
            }

            public void SetPlace(int place)
            {
                if (place <= 0 || _place > 0) return;
                _place = place;
            }

            public void Print()
            {
                Console.WriteLine($"{_name} {_surname}: {_place} place");
            }
        }
        public struct Team
        {
            private string _name;
            private Sportsman[] _sportsmen;

            private int index;

            public string Name => _name;
            public Sportsman[] Sportsmen => _sportsmen;

            public int SummaryScore
            {
                get
                {
                    if (_sportsmen == null || _sportsmen.Length == 0) return 0;
                    int summary_score = 0;
                    for (int i = 0; i < _sportsmen.Length; i++)
                    {
                        if (_sportsmen[i].Place == 1) summary_score += 5;
                        if (_sportsmen[i].Place == 2) summary_score += 4;
                        if (_sportsmen[i].Place == 3) summary_score += 3;
                        if (_sportsmen[i].Place == 4) summary_score += 2;
                        if (_sportsmen[i].Place == 5) summary_score += 1;
                    }
                    return summary_score;
                }
            }

            public int TopPlace
            {
                get
                {
                    if (_sportsmen == null || _sportsmen.Length == 0) return 0;
                    int top_place = 18;
                    for (int i = 0; i < _sportsmen.Length; i++)
                    {
                        if (_sportsmen[i].Place < top_place && _sportsmen[i].Place > 0) top_place = _sportsmen[i].Place;
                    }
                    return top_place;
                }
            }


            public Team(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[6];
                index = 0;
            }

            public void Add(Sportsman sportsman)
            {
                if (_sportsmen == null || _sportsmen.Length == 0 || index >= _sportsmen.Length) return;
                _sportsmen[index] = sportsman;
                index++;
            }

            public void Add(Sportsman[] sportsmen)
            {
                if (sportsmen == null || sportsmen.Length == 0 || _sportsmen == null || _sportsmen.Length == 0 || index >= _sportsmen.Length) return;
                int count = 0;
                while (index < _sportsmen.Length && count < sportsmen.Length)
                {
                    _sportsmen[index] = sportsmen[count];
                    count++;
                    index++;
                }
            }

            public static void Sort(Team[] teams)
            {
                if (teams == null || teams.Length == 0) return;
                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length - i - 1; j++)
                    {
                        if (teams[j].SummaryScore < teams[j + 1].SummaryScore)
                        {
                            (teams[j], teams[j + 1]) = (teams[j + 1], teams[j]);
                        }
                        else if (teams[j].SummaryScore == teams[j + 1].SummaryScore && teams[j].TopPlace > teams[j + 1].TopPlace)
                        {
                            (teams[j], teams[j + 1]) = (teams[j + 1], teams[j]);
                        }
                    }
                }

            }
            public void Print()
            {
                for (int i = 0; i < _sportsmen.Length; i++)
                {
                    Console.WriteLine($"Team: {_name}, SummaryScore: {SummaryScore}, TopPlace: {TopPlace}");
                }
                
            }
        }
    }
}
