using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Leetcode
{
    /// <summary>
    /// Leetcode 804：唯一摩斯密码
    /// 集合的应用
    /// 有序集合 -> 基于搜索树实现的（SortedSet）
    /// 无序集合 -> 基于哈希表实现的（HashSet）
    /// </summary>
    public class UniqueMorse
    {
        public　int UniqueMorseRepresentations(string[] words)
        {
            string[] codes = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };

            SortedSet<string> set = new SortedSet<string>();
            foreach (var word in words)
            {
                var res = new StringBuilder();
                for (int i = 0; i < word.Length; i++)
                {
                    res.Append(codes[word[i] - 'a']);
                }
                set.Add(res.ToString());
            }

            foreach (var s in set)
            {
                Console.WriteLine(s);
            }

            return set.Count;
        }
    }
}
