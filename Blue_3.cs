using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_3
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int[] _penalty;

            public string Name => _name;
            public string Surname => _surname;
            public int[] PenaltyTimes
            {
                get
                {
                    if (_penalty == null) return null;
                    int[] penalty = new int[_penalty.Length];
                    for (int i = 0; i < penalty.Length; i++)
                    {
                        penalty[i] = _penalty[i];
                    }
                    return penalty;
                }
            }

            public int TotalTime
            {
                get
                {
                    if (_penalty == null || _penalty.Length == 0) return 0;
                    int total_time = 0;
                    for (int i = 0; i < _penalty.Length; i++)
                    {
                        total_time += _penalty[i];
                    }
                    return total_time;
                }
            }

            public bool IsExpelled
            { 
                get
                {
                    for (int i = 0; i < _penalty.Length; i++)
                    {
                        if (_penalty[i] == 10)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _penalty = new int[0];
            }

            public void PlayMatch(int time)
            {
                if (_penalty == null) return;
                int[] newpen = new int[_penalty.Length + 1];
                for (int i = 0; i < newpen.Length - 1; i++)
                {
                    newpen[i] = _penalty[i];
                }
                newpen[newpen.Length - 1] = time;
                _penalty = newpen;
            }

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].TotalTime > array[j + 1].TotalTime)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"{_name} {_surname}: {TotalTime}. IsExpelled: {IsExpelled}");
            }
        }
    }
}
