using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructure.Leetcode
{
    /// <summary>
    /// Leetcode 1011: 在 D 天内送达包裹的能力
    /// 二分搜索的应用
    /// day(k) <= D 的最大days对应的k（最小k）
    /// </summary>
    class ShipWithinDays
    {
        public int ShipWithinDays_(int[] weights, int days)
        {
            int l = weights.Max();
            int r = weights.Sum();
            while (l < r)
            {
                int mid = l + (r - l) / 2;
                if (Day(weights, mid) <= days)
                {
                    r = mid;
                }
                else
                {
                    l = mid + 1;
                }
            }
            return l;
        }

        public int Day(int[] weights, int carry)
        {
            int day = 1;
            int totalWeight = 0;
            foreach (var w in weights)
            {
                totalWeight += w;
                if (totalWeight > carry)
                {
                    day++;
                    totalWeight = w;
                }
            }
            return day;
        }
    }
}
