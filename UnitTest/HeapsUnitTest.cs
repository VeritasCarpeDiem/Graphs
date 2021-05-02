using DeleteMeHeaps;
using System;
using Xunit;


namespace UnitTest
{
    public class HeapsUnitTest
    {
        [Fact]
        public void TestForEmptyHeap()
        {
            Heaps<int> heaps = new Heaps<int>();
            Assert.Equal(0, heaps.Count);
            Assert.True(heaps.isEmpty);
        }

        [Fact]
        public void TestForPushCountIncreasing()
        {
            Heaps<int> heaps = new Heaps<int>();
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
            Heaps<int> heap= new Heaps<int>();

            for (int i = 0; i < count; i++)
            {
                heap.Push(i);
            }

            Assert.Equal(heap.isEmpty, empty);
            Assert.Equal(heap.Count, count);
        }


    }
}
