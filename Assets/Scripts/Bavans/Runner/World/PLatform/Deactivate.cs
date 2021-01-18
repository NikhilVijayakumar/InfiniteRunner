using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Bavans.Runner.World.Platform
{
  
    public class Deactivate : MonoBehaviour
    {
        private float deactivateTime = 4.0f;
        bool dSchedule = false;
        private void OnCollisionExit(Collision player)
        {
            if(player.gameObject.tag == "Player" && !dSchedule)
            {
                Invoke("SetInactive", deactivateTime);
                dSchedule = true;
            }
        }
        private void SetInactive()
        {
            this.gameObject.SetActive(false);
            dSchedule = false;
        }
    }
}

