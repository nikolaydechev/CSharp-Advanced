using System;
using System.Collections.Generic;

namespace _07.BalancedParantheses
{
    public class BalancedParantheses
    {
        public static void Main()
        {
            var input = Console.ReadLine().ToCharArray();

            var stack = new Stack<char>();
            var parantheses = new Dictionary<char, char>();

            parantheses.Add('{', '}');
            parantheses.Add('(', ')');
            parantheses.Add('[', ']');

            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            bool balanced = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (parantheses.ContainsKey(input[i]))
                {
                    stack.Push(input[i]);
                }
                else if (input[i] != parantheses[stack.Peek()])
                {
                    balanced = false;
                    break;
                }
                else if (input[i] == parantheses[stack.Peek()])
                {
                    stack.Pop();
                }
            }

            if (balanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }


            // OTHER SOLUTION:
            // " Main(){...} "

            //char[] input = Console.ReadLine().ToCharArray();
            //Stack<char> parenthesesStack = new Stack<char>();
            //Dictionary<char, char> parentheses = new Dictionary<char, char> { { '{', '}' }, { '[', ']' }, { '(', ')' } };

            //bool isBalanced = true;

            //if (input.Length % 2 != 0)
            //{
            //    Console.WriteLine("NO");
            //    return;
            //}
            //for (int i = 0; i < input.Length; i++)
            //{
            //    if (parentheses.ContainsKey(input[i]))  // opening parenthesis
            //        parenthesesStack.Push(input[i]);
            //    else if (parenthesesStack.Count == 0 || input[i] != parentheses[parenthesesStack.Peek()])   // non-matching opening & closing parentheses
            //    {
            //        isBalanced = false;
            //        break;
            //    }
            //    else if (input[i] == parentheses[parenthesesStack.Peek()])  // matching opening & closing parentheses
            //        parenthesesStack.Pop();
            //}
            //Console.WriteLine(isBalanced ? "YES" : "NO");
        }
    }
}
