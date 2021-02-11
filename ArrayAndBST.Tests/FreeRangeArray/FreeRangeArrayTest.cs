using System;
using FreeArray;
using Xunit;

namespace ArrayAndBST.Tests.FreeRangeArray
{
    public class FreeRangeArrayTset 
    {

        //arrange


        //act


        //assert

        [Fact]
        public void FreeArrayConstructor_IntArrayWithRangeMinos1To1WithTheSameElements_FirstElementOfArrayReturnedAs0()
        {
            //arrange
            var Array = new FreeRangeArray<int>(-1, 1);
            var Expected = 0;


            //act
            for (int i = 0; i < Array.endIndex; i++)
            {
                Array[i] = i;
            }

            //assert
            Assert.Equal(Array[0], Expected);

        }


        [Fact]
        public void FreeArrayConstructor_()
        {

        }


        [Fact]
        public void FreeArrayConstructor()
        {

        }



        [Fact]
        public void FreeArrayConstructor__()
        {

        }




    }
}
