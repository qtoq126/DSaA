using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
///  Leetcode 349: 两个数组的交集
/// </summary>
namespace DataStructure.Leetcode
{
    public class IntersectionOfTwoArrays
    {
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            var hs = new HashSet<int>(); // 无序要求可用HashSet
            foreach (var n in nums1)
            {
                hs.Add(n);
            }

            var list = new List<int>();
            foreach (var n in nums2)
            {
                if (hs.Contains(n))
                {
                    list.Add(n);
                    hs.Remove(n);
                }
            }
            return list.ToArray();
        }
    }
}
