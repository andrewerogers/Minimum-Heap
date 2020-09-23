using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> array = new List<int>(){ 4, 1, 5, 10, 3, 7, 888, 9, -10, 299 };

            Console.WriteLine("Original array: ");
            print(array.ToArray());
            heap minHeap = new heap(array);
            Console.WriteLine("Heap / Priority Queue: ");
            print(minHeap.heapArray.ToArray());
        }

        // Standard implementation of a heap. Supports insert, remove, and peek.
        public class heap
        {
            public List<int> heapArray = new List<int>();

            public heap(List<int> array)
            {
                heapArray = buildHeap(array);
            }

            public List<int> buildHeap(List<int> array)
            {
                for (int i = array.Count - 1; i >= 0; i--)
                {
                    heapify(array, i);
                }

                return array;
            }

            public void heapify(List<int> heap, int nodeIdx)
            {
                int leftIdx = 2 * nodeIdx + 1;
                int rightIdx = 2 * nodeIdx + 2;
                int minIdx = nodeIdx;

                if (leftIdx < heap.Count && heap[leftIdx] < heap[minIdx])
                {
                    minIdx = leftIdx;
                }
                if (rightIdx < heap.Count && heap[rightIdx] < heap[minIdx])
                {
                    minIdx = rightIdx;
                }

                // check to see if nodes are out of order
                if (minIdx != nodeIdx)
                {
                    int temp = heap[minIdx];
                    heap[minIdx] = heap[nodeIdx];
                    heap[nodeIdx] = temp;

                    // recursively call on affected subtree
                    heapify(heap, minIdx);
                }
            }

            public void siftUp(int currentIdx, List<int> heap)
            {
                bool isSorted = false;

                while (!isSorted)
                {
                    int parentIdx = GetParent(currentIdx);

                    if (heap[currentIdx] < heap[parentIdx])
                    {
                        // swap nodes 
                        int temp = heap[currentIdx];
                        heap[currentIdx] = heap[parentIdx];
                        heap[parentIdx] = temp;
                    }
                    else
                    {
                        isSorted = true;
                    }

                    currentIdx = parentIdx;
                }
            }

            // Grabbed from C# heap
            public int GetParent(int i)
            {
                double element = i;
                int index = (int)System.Math.Floor((element - 1) / 2);

                if (index < 0)
                {
                    return 0;
                }

                return index;
            }

            public int Peek()
            {
                if (heapArray.Count > 0)
                {
                    return heapArray[0];
                }
                else
                {
                    return -1;
                }
            }

            public int Remove()
            {
                if (heapArray.Count > 0)
                {
                    int temp = heapArray[0];
                    heapArray[0] = heapArray[heapArray.Count - 1];
                    heapArray.RemoveAt(heapArray.Count - 1);
                    heapify(heapArray, 0);
                    return temp;
                }
                else
                {
                    return -1;
                }
            }

            public void Insert(int value)
            {
                heapArray.Add(value);
                siftUp(heapArray.Count - 1, heapArray);
            }
        }

        

        private static void print(int[] array)
        {
            for(int i=0;i<array.Length;i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
