using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;// interacting with scene change
using UnityEngine.UI;// interacting with GUI element
using UnityEngine.EventSystems; //control the event (button shiz)
public class MenuHandler : MonoBehaviour
{
    public GameObject mainMenu, optionsMenu;
    public bool showOptions;

    public void Loadgame()
    {
        SceneManager.LoadScene(1);
    }
    public void Exitgame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif

        Application.Quit();
    
    }

    public void ToggleOptions()
    {
        OptionToggle();
    }
    bool OptionToggle()
    {
        if(showOptions)//showOptions == true means showOptions is true
        {
            showOptions = false;
            mainMenu.SetActive(true);
            optionsMenu.SetActive(false);
            return true;
        }
        else
        {
            showOptions = true;
            mainMenu.SetActive(false);
            optionsMenu.SetActive(true);
            return false;
        }
                }

}

