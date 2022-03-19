using System.Collections.Generic;

    public class Solution {
        public bool IsValid(string s){
            Stack<char> stack = new Stack<char>();
            foreach (var c in s)
            {
                if (c == '{' || c == '[' || c == '(')
                {
                    stack.Push(c);
                }
                else {
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    char topChar = stack.Pop();
                    if (c == '}' && topChar != '{')
                    {
                        return false;
                    }
                    if (c == ']' && topChar != '[')
                    {
                        return false;
                    }
                    if (c == ')' && topChar != '(')
                    {
                        return false;
                    }
                }
            }
            return stack.Count == 0 ? true : false;
        }
    }