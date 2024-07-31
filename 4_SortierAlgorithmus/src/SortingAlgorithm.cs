using System.Drawing;
using System.Net.Sockets;

namespace Sortier_Algorithmen
{
    internal class SortingAlgorithm
    {
        public List<int> list = new List<int>();
        int[] sorted;
        Random rnd = new Random(DateTime.Now.Millisecond);

        public SortingAlgorithm(List<int> _list)
        {
            list = _list;
        }

        public void Sort(int _sortAlgorithm)
        {
            if (_sortAlgorithm == 1) //Sequential Sort
            {
                var swapped = true;
                while (swapped)
                {
                    swapped = false;
                    for (int i = 0; i <= list.Count - 2; i++)
                    {
                        if (list[i] > list[i + 1])
                        {
                            var temp = list[i];
                            list[i] = list[i + 1];
                            list[i + 1] = temp;

                            swapped = true;
                        }
                    }
                }
            }
            else if (_sortAlgorithm == 2) //Bubble Sort
            {
                var swapped = false;
                for (int i = 0; i < list.Count - 1; i++)
                {
                    for (int j = 0; j < list.Count - 1 - i; j++)
                    {
                        if (list[j] > list[j + 1])
                        {
                            var temp = list[j];
                            list[j] = list[j + 1];
                            list[j + 1] = temp;

                            swapped = true;
                        }
                    }
                    if (!swapped) break;
                }
            }
            else if (_sortAlgorithm == 3) //Insertion Sort
            {
                var temp = 0;
                var n = 0;
                for (int i = 1; i < list.Count; ++i)
                {
                    n = i - 1;
                    temp = list[i];

                    while (n >= 0 && list[n] > temp)
                    {
                        list[n + 1] = list[n];
                        n--;
                    }
                    list[n + 1] = temp;
                }
            }
            else if ( _sortAlgorithm == 4) //Heap Sort
            {
                var n = list.Count;
                for (int i = n / 2 - 1; i >= 0; i--)
                {
                    Heapify(list, n, i);
                }

                for (int i = n - 1; i >= 0; i--)
                {
                    var temp = list[0];
                    list[0] = list[i];
                    list[i] = temp;

                    Heapify(list, i, 0);
                }
            }
            sorted = list.ToArray();
        }

        void Heapify(List<int> _list, int _size, int _index)
        {
            var maxIndex = _index;
            var childL = 2 * _index + 1;
            var childR = 2 * _index + 2;

            if (childL < _size && _list[childL] > _list[maxIndex])
            {
                maxIndex = childL;
            }

            if (childR < _size && _list[childR] > _list[maxIndex])
            {
                maxIndex = childR;
            }

            if (maxIndex != _index)
            {
                var temp = _list[_index];
                _list[_index] = _list[maxIndex];
                _list[maxIndex] = temp;

                Heapify(_list, _size, maxIndex);
            }
        }

        public void Increscent()
        {
            list = sorted.ToList();
        }

        public void Decrescent()
        {
            list = sorted.ToList();
            for (int i = 0; i < list.Count / 2; i++)
            {
                var n = list.Count - 1 - i;
                var temp = list[i];
                list[i] = list[n];
                list[n] = temp;
            }
        }

        public void ZigZag()
        {
            Decrescent();
            int[] i = sorted;
            int[] d = list.ToArray();
            int n = 0;
            for (int j = 0; j < list.Count / 2; j++)
            {
                list[n] = d[j];
                n++;
                list[n] = i[j];
                n++;
            }
            if (list.Count % 2 != 0)
            {
                list[n] = i[n / 2];
            }
        }

        public void Shuffle()
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int n = rnd.Next(i + 1);
                int temp = list[n];
                list[n] = list[i];
                list[i] = temp;
            }
        }

        public void Add(int _toAdd, string _shownAs)
        {
            list.Add(_toAdd); 
            Sort(rnd.Next(1, 5));
            if (_shownAs == "increscent") Increscent();
            else if (_shownAs == "decrescent") Decrescent();
            else if (_shownAs == "zig-zag") ZigZag();
        }
    }
}
