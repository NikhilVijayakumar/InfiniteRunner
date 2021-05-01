using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Bavans.Runner.World
{
    public class TimeManager : MonoBehaviour
    {
        public List<GameObject> time;
        public List<GameObject> skylist;
        private int timeIndex = -1;
        private int score = 0;
        public static TimeManager singleton;
        void Awake()
        {
            singleton = this;
            DisableSky();
            ClearSky();
            SetSkybox();
        }

        private void SetSkybox()
        {
            foreach (GameObject sky in skylist)
            {
                sky.SetActive(false);
            }
            print("Count:" + skylist.Count);
            int index = UnityEngine.Random.Range(0, skylist.Count);
            skylist[index].SetActive(true);            
        }

        private void SetSky()
        {
            DisableSky();
            timeIndex++;
            if(timeIndex >= time.Count || timeIndex < 0)
            {
                timeIndex = 0;
                SetSkybox();
            }            
            time[timeIndex].SetActive(true);
        }

        private void DisableSky()
        {
            foreach (GameObject sky in time)
            {
                sky.SetActive(false);
            }
            
        }

        public void ClearSky()
        {
            timeIndex = -1;
            SetSky();
        }

        public void updateScore(int coin)
        {
            score += coin;
            if (score >= 25)
            {
                SetSky();
                score = 0;
            }

        }

    }
}
