using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructure.Leetcode
{
    /// <summary>
    /// Leetcode 875：爱吃香蕉的珂珂
    /// 二分搜索的应用
    /// 速度和时间具有单调性
    /// EatingTime() <=H 的最大time（对应最小速度）
    /// </summary>
    class MinEatingSpeed
    {
        public int MinEatingSpeed_(int[] piles, int h)
        {
            int l = 1; 
            int r = piles.Max();
            while (l < r)
            {
                int mid = l + (r - l) / 2;
                if (EatingTime(piles, mid) <= h)
                {
                    r = mid;
                }
                else
                {
                    l = mid + 1; // 速度慢了，需要吃更多
                }
            }
            return l;
        }

        private double EatingTime(int[] piles, int speed)
        {
            double h = 0;
            for (int i = 0; i < piles.Length; i++)
            {
                double t = (double)piles[i] / speed;
                h += Math.Ceiling(t);
            }
            return h;
        }
    }
}
