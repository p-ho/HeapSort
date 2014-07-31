using System;

namespace HeapSort
{
	public class MainClass
	{
		public static void Main (string[] args)
		{
			int[] mykeys = new int[] {
				1,
				2,
				3,
				30,
				1,
				66,
				19,
				14,
				18,
				8,
				24,
				15,
				32,
				43,
				22,
				28,
				21,
				63,
				27,
				86,
				58,
				73,
				46,
				58,
				73,
				47,
				26,
				59,
				74,
				36,
				59,
				23,
				12
			};

			printArray (mykeys);

			//buildMaxHeap (mykeys);

			heapSort (mykeys);

			printArray (mykeys);

		}

		private static void heapSort<T> (T[] array) where T : IComparable<T>
		{
			int heapSize = array.Length;

			buildMaxHeap (array);

			for (int i = heapSize-1; i >= 1; i--)
			{
				swap (array, i, 0);
				heapSize--;
				sink (array, heapSize, 0);
			}
		}

		private static void buildMaxHeap<T> (T[] array) where T : IComparable<T>
		{
			int heapSize = array.Length;

			for (int i = (heapSize/2) - 1; i >= 0; i--)
			{
				sink (array, heapSize, i);
			}
		}

		private static void sink<T> (T[] array, int heapSize, int toSinkPos) where T : IComparable<T>
		{
			if (getLeftKidPos (toSinkPos) >= heapSize)
			{
				// No left kid => no kid at alll
				return;
			}


			int largestKidPos;
			bool leftIsLargest;

			if (getRightKidPos (toSinkPos) >= heapSize || array [getRightKidPos (toSinkPos)].CompareTo (array [getLeftKidPos (toSinkPos)]) < 0)
			{
				largestKidPos = getLeftKidPos (toSinkPos);
				leftIsLargest = true;
			} else
			{
				largestKidPos = getRightKidPos (toSinkPos);
				leftIsLargest = false;
			}
			


			if (array [largestKidPos].CompareTo (array [toSinkPos]) > 0)
			{
				swap (array, toSinkPos, largestKidPos);

				if (leftIsLargest)
				{
					sink (array, heapSize, getLeftKidPos (toSinkPos));

				} else
				{
					sink (array, heapSize, getRightKidPos (toSinkPos));
				}
			}

		}

		private static void swap<T> (T[] array, int pos0, int pos1)
		{
			T tmpVal = array [pos0];
			array [pos0] = array [pos1];
			array [pos1] = tmpVal;
		}

		private static int getLeftKidPos (int parentPos)
		{
			return (2 * (parentPos + 1)) - 1;
		}

		private static int getRightKidPos (int parentPos)
		{
			return 2 * (parentPos + 1);
		}

		private static void printArray<T> (T[] array)
		{
			char sep = '[';

			foreach (T t in array)
			{
				Console.Write (sep + t.ToString ());
				sep = ' ';
			}

			Console.WriteLine ("]");
		}
	}

}
