using System;

namespace ScatterGather
{
    class Program
    {
        public static void Swap<T>(T[] array, int indexfirst, int indexSecond)
        {
            T temp = array[indexfirst];
            array[indexfirst] = array[indexSecond];
            array[indexSecond] = temp;
        }

        public static int NumberBetweenInclusive(Random random, int lowerBoundInclusive, int upperBoundInclusive)
        {
            int count = upperBoundInclusive - lowerBoundInclusive + 1;
            return random.Next(count) + lowerBoundInclusive;
        }

        public static void Shuffle<T>(Random random, T[] array)
        {
            int lastIndex = array.Length - 1;
            for (int currentIndex = 0; currentIndex < lastIndex; ++currentIndex)
            {
                int swapIndex = NumberBetweenInclusive(random, currentIndex, lastIndex);
                Swap(array, currentIndex, swapIndex);
            }
        }

        public static int[] GenrateRandomMap(Random random, int length)
        {
            var result = new int[length];
            for (int i = 0; i < result.Length; ++i)
                result[i] = i;

            Shuffle(random, result);

            return result;
        }

        public static int[] InvertMap(int[] array)
        {
            var result = new int[array.Length];

            for (int i =0; i < array.Length; ++i)
            {
                result[array[i]] = i;
            }

            return result;
        }
        
        static void Scatter<T>(T[] readArray, T[] writeArray, int[] map)
        {
            for (int i = 0; i < writeArray.Length; ++i)
            {
                writeArray[map[i]] = readArray[i];
            }
        }

        static void Gather<T>(T[] readArray, T[] writeArray, int[] map)
        {
            for (int i = 0; i < writeArray.Length; ++i)
            {
                writeArray[i] = readArray[map[i]];
            }
        }

        static int[] GenerateRandomData(Random random, int length)
        {
            var result = new int[length];
            for (int  i = 0; i < result.Length; ++i)
            {
                result[i] = random.Next();
            }
            return result;
        }

        static void ClearCache(Random random)
        {
            GenerateRandomData(random, 1024 * 1024 * 20 / sizeof(int));
        }
        
        static void PrintProgress(string test, int arraySize, int loopCount, long milliseconds)
        {
            const int millsecondsPerNano = 1000000;
            System.Console.WriteLine("Time to {0, 8} {1, 10} items {2, 8} times: {3, 5}ms = {4, 5}ns per integer copy", 
                test,
                arraySize, 
                loopCount, 
                milliseconds,
                (double)milliseconds / arraySize / loopCount  * millsecondsPerNano);
        }

        static void Main(string[] args)
        {
            var random = new Random();
            
            var timer = new System.Diagnostics.Stopwatch();

            System.Console.WriteLine("Press any key to exit");
            while (!System.Console.KeyAvailable)
            {
                int arraySize = 100000000;
                int loopCount = 1;
                while (arraySize > 10 && !System.Console.KeyAvailable)
                {
                    int[] writeArray = new int[arraySize];
                    int[] readArray = GenerateRandomData(random, arraySize);
                    int[] M = GenrateRandomMap(random, arraySize);
                    int[] MPrime = InvertMap(M);

                    ClearCache(random);
                    timer.Reset();
                    timer.Start();
                    for (int j = 0; j < loopCount; j++)
                        Scatter(readArray, writeArray, M);
                    timer.Stop();
                    PrintProgress("Scatter", arraySize, loopCount, timer.ElapsedMilliseconds);
                   
                    ClearCache(random);
                    timer.Reset();
                    timer.Start();
                    for (int j = 0; j < loopCount; j++)
                        Gather(readArray, writeArray, MPrime);
                    timer.Stop();
                    PrintProgress("Gather", arraySize, loopCount, timer.ElapsedMilliseconds);

                    arraySize /= 10;
                    loopCount *= 10;
                }
            }
        }
    }
}
