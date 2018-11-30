using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHand
{
    //public class CardPlayCollection : Set<CardPlay>
    //{

    //}
    //class Set<T>
    //{
    //    private List<T>[] buckets = new List<T>[100];

    //    public void Insert(T item) {
    //        int bucket = GetBucket(item.GetHashCode());
    //        if (Contains(item, bucket))
    //            return;
    //        if (buckets[bucket] == null)
    //            buckets[bucket] = new List<T>();
    //        buckets[bucket].Add(item);
    //    }
    //    public bool Contains(T item) {
    //        return Contains(item, GetBucket(item.GetHashCode()));
    //    }

    //    private int GetBucket(int hashcode)
    //    {     
    //        unchecked { return (int)((uint)hashcode % (uint)buckets.Length); }
    //    }

    //    private bool Contains(T item, int bucket) { if (buckets[bucket] != null) foreach (T member in buckets[bucket]) if (member.Equals(item)) return true; return false; }
    //}
}