using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bavans.Runner.Utils;
namespace Bavans.Runner.World.Platform
{
    public class Pool : MonoBehaviour
    {
        public static Pool singleton;
        public List<PoolItem> itemList;
        public List<GameObject> pooledItemList;
        public  GameObject deathcube;
        // Start is called before the first frame update

        private void Awake()
        {
            singleton = this;
            pooledItemList = new List<GameObject>();
            foreach(PoolItem item in itemList)
            {
                for(int i = 0; i < item.amount; i++)
                {
                    GameObject obj = Instantiate(item.prefab);
                    obj.SetActive(false);
                    pooledItemList.Add(obj);
                }
            }
        }

        public GameObject GetRandomPlatform()
        {
            RunnerUtils.Shuffle(pooledItemList);
            for (int i = 0; i < pooledItemList.Count; i++)
            {
                if (!pooledItemList[i].activeInHierarchy)
                {
                    return pooledItemList[i];
                }
            }
            foreach (PoolItem item in itemList)
            {
                if (item.expandable)
                {
                    GameObject obj = Instantiate(item.prefab);
                    obj.SetActive(false);
                    pooledItemList.Add(obj);
                    return obj;
                }
            }
            return null;
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
