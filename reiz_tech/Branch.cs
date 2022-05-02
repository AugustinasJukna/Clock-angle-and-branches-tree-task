using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reiz_tech
{
    class Branch
    {
        private List<Branch> branches;
        private Branch? Parent; //Parent branch of the current branch
        public int Value { get; private set; }
      
        //Constructor #1
        public Branch(Branch parentBranch, int value)
        {
            Parent = parentBranch;
            Value = value;
            branches = new List<Branch>();
        }
        //Constructor #2
        public Branch(int value)
        {
            Parent = null;
            Value = value;
            branches = new List<Branch>();
        }

        /// <summary>
        /// Adds a new branch to the tree
        /// </summary>
        /// <param name="value">value to give to the branch</param>
        /// <returns>the new branch (important for adding new elements)</returns>
        public Branch AddBranch(int value)
        {
            Branch newBranch = new Branch(this, value);
            branches.Add(newBranch);
            return newBranch;
        }

        public void RemoveBranch(Branch branch)
        {
            branches.Remove(branch);
        }

        /// <summary>
        /// Goes through the whole tree calculating it's height
        /// </summary>
        /// <param name="lastTreeNode">last branch or lowest tree leaf (node)</param>
        /// <param name="counter"> the current height</param>
        public void RecursiveTraverseToRoot(Branch lastTreeNode, ref int counter) 
        {
            if (lastTreeNode.Parent == null)
            {
                return;
            }
            counter++;
            RecursiveTraverseToRoot(lastTreeNode.Parent, ref counter);
        }


        /// <summary>
        /// Helper method for the recursive method above
        /// </summary>
        /// <returns>Tree's height</returns>
        public int CalculateHeight()
        {
            int counter = 0;
            RecursiveTraverseToRoot(this, ref counter);
            return counter;
        }

        /// <summary>
        /// Recreates given tree structure
        /// </summary>
        /// <returns>Returns the last tree branch</returns>
        public static Branch RecreateExampleStructure()
        {

            Branch current = new Branch(0);
            Branch left = current.AddBranch(1);
            left = left.AddBranch(2);
            Branch right = current.AddBranch(3);
            left = right.AddBranch(4);
            Branch middle = right.AddBranch(5);
            right = right.AddBranch(6);
            left = left.AddBranch(7);
            middle = middle.AddBranch(8);
            left = middle.AddBranch(9);
            right = middle.AddBranch(10);
            left = left.AddBranch(11);
            return left;
        }

        /// <summary>
        /// Creates a testing tree of given height and random number of branches in each branch
        /// </summary>
        /// <param name="height">What height the test tree should be</param>
        /// <returns>The last branch of the tree</returns>
        public static Branch TestingTree(int height)
        {
            Random rnd = new Random();
            Branch root = new Branch(0);
            for (int i = 0; i < height; i++)
            {
                int howManyNodes = rnd.Next(1, 10);
                for (int j = 0; j < howManyNodes - 1; j++)
                {
                    root.AddBranch(i);
                }
                root = root.AddBranch(i);
            }
            return root;
        }

    }
}
