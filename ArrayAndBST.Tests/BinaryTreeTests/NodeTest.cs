using Xunit;
using System;
using BinaryTreeSpace;
using System.Collections;
using System.Diagnostics;



namespace ArrayAndBST.Tests.BinaryTreeTests
{
    public class NodeTest
    {

        [Fact]

        public void Add_Add3Numbers_AllReturnedInCorrectPosition()
        {
            //arrange
            var First = 2;
            var Second = 1;
            var Third = 3;



            //act
            var node = new Node<int>(First);
            node.Add(Second);
            node.Add(Third);

            //assert
            Assert.Equal(First, node.Data);
            Assert.Equal(Second, node.Left.Data);
            Assert.Equal(Third, node.Right.Data);

        }


        [Fact]
        public void ToString_CreateNodeWithIntNumber_NodeReturnsLikeString()
        {
            //arrange
            var First = 25;
            var Expected = "25";

            //act
            var node = new Node<int>(First);


            //assert
            Assert.Equal(Expected, node.ToString());

        }


        [Fact]
        public void CompareTo_TwoIntNodes1and2_Minus1Returned()
        {
            // arrange
            var First = 1;
            var Second = 2;
            var Expected = -1;


            //act
            var node1 = new Node<int>(First);
            var node2 = new Node<int>(Second);


            //assert
            Assert.Equal(Expected, node1.CompareTo(node2.Data));
        }
    }
}
