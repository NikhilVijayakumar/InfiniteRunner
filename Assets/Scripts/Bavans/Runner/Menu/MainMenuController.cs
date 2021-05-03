using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Bavans.Runner.Player;

namespace Bavans.Runner.Menu
{
    public class MainMenuController : MonoBehaviour
    {

        GameObject[] pannelArray;
        GameObject[] buttonArray;
        public void LoadGameScene()
        {
            PlayerController.isDead = false;
            SceneManager.LoadScene("Platform", LoadSceneMode.Single);
        }

        public void QuitGame()
        {    
            Application.Quit();    
        }

        private void Start()
        {

            pannelArray = GameObject.FindGameObjectsWithTag("SubPannel");
            buttonArray = GameObject.FindGameObjectsWithTag("MenuButton");

            foreach(GameObject pannel in pannelArray)
            {
                pannel.SetActive(false);
            }

        }

        public void OpenPannel(Button button)
        {
            foreach (GameObject menuButton in buttonArray)
            {
                if(button.gameObject != menuButton)
                {
                    menuButton.SetActive(false);
                }
              
            }


            button.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }

        public void ClosePannel(Button button)
        {
            button.gameObject.transform.parent.gameObject.SetActive(false);
            foreach (GameObject menuButton in buttonArray)
            {
                menuButton.SetActive(true);
            }
        }

        public void LoadTutorialScene()
        {
            PlayerController.isDead = false;
            SceneManager.LoadScene("LearnToPLay", LoadSceneMode.Single);
        }


    }
}

