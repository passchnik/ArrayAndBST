using Xunit;
using System;
using BinaryTreeSpace;
using System.Collections;

namespace ArrayAndBST.Tests
{
    public class BinaryTreeTest : IDisposable
    {
        private BinaryTree<int> tree;

        public BinaryTreeTest()
        {
            tree = new BinaryTree<int>();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(tree);
        }

        [Fact]

        public void Add_1and2and3_1and2and3ReturnedInCorrectPosition()
        {
            //arrange

            var FirstNode = 1;
            var SecondNode = 2;
            var ThirdNode = 3;

            //act
            tree.Add(FirstNode);
            tree.Add(SecondNode);
            tree.Add(ThirdNode);

            //assert
            Assert.Equal(FirstNode, tree.Root.Data);
            Assert.Equal(SecondNode, tree.Root.Right.Data);
            Assert.Equal(ThirdNode, tree.Root.Right.Right.Data);
            
            //Assert.Throws

        }

        [Fact]

        public void Find_Add1Number_1Returned()
        {
            //arrange

            int FirstNode = 1;
            

            //act
            tree.Add(FirstNode);
            

            //assert
            Assert.Equal(FirstNode, tree.Find(FirstNode).Data);
            
        }

        [Fact]
        public void GetEnumerator_First5Numbers_AreCorrect()
        {
            //arrange

            var array = new int[5];

            for (int i = 0; i < array.Length; i++)
                array[i] = i;



            //act
            for (int i = 0; i < array.Length; i++)
            {
                tree.Add(array[i]);
            }


            //assert
            
            foreach(var i in tree)
            {
                Assert.Equal(i, array[i]);
            }
        }

        [Fact]

        public void Find_Add3Numbers_ThirdReturned()
        {
            //arrange

            var FirstNode = 1;
            var SecondNode = 2;
            var ThirdNode = 3;

            //act
            tree.Add(FirstNode);
            tree.Add(SecondNode);
            tree.Add(ThirdNode);

            //assert
            
            Assert.Equal(ThirdNode.ToString(), tree.Find(3).ToString());
        }

        

        
    }
}
