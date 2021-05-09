using DeleteMeHeaps;
using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    public class HeapsUnitTest
    {
        [Fact]
        public void TestForEmptyHeap()
        {
            Comparer<int> comparer = Comparer<int>.Create((x, y) => x.CompareTo(y));
            Heaps<int> heaps = new Heaps<int>(comparer);
            //Heaps<int> heaps = new Heaps<int>();
            Assert.Equal(0, heaps.Count);
            Assert.True(heaps.isEmpty);
        }

        [Fact]
        public void TestForPushCountIncreasing()
        {
            Comparer<int> comparer = Comparer<int>.Create((x, y) => x.CompareTo(y));
            Heaps<int> heaps = new Heaps<int>(comparer);
            //Heaps<int> heaps = new Heaps<int>();
            heaps.Push(5);
            Assert.Equal(1, heaps.Count);
            Assert.True(heaps.Contains(5));
        }

        [Theory]
        [InlineData(0, true)]
        [InlineData(3, false)]
        [InlineData(10000, false)]

        public void HeapCountTheory(int count, bool empty)
        {
            Comparer<int> comparer = Comparer<int>.Create((x, y) => x.CompareTo(y));
            Heaps<int> heaps = new Heaps<int>(comparer);
            // Heaps<int> heap= new Heaps<int>();

            for (int i = 0; i < count; i++)
            {
                heaps.Push(i);
            }

            Assert.Equal(heaps.isEmpty, empty);
            Assert.Equal(heaps.Count, count);
        }

        [Fact]
        public void TestForHeapSort()
        {
            Comparer<int> comparer = Comparer<int>.Create((x, y) => x.CompareTo(y));
            Heaps<int> heaps = new Heaps<int>(comparer);

            Random random = new Random(3);

            List<int> initialValues = new List<int>();

            for (int i = 0; i < 8; i++)
            {
                int randomlyGeneratedValue = random.Next(0, 100);

                initialValues.Add(randomlyGeneratedValue);
                heaps.Push(randomlyGeneratedValue);
            }

            List<int> removedValues = new List<int>();
            while (heaps.Count > 0)
            {
                removedValues.Add(heaps.Pop());
            }

            initialValues.Sort();

            Assert.True(initialValues.SequenceEqual(removedValues));
        }

    }
}
