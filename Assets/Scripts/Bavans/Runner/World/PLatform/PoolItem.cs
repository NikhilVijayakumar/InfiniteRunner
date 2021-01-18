using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Bavans.Runner.World.Platform
{
    [System.Serializable]
    public class PoolItem 
    {
        public GameObject prefab;
        public int amount;
        public bool expandable;
    }
}
