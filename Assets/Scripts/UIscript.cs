using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIscript : MonoBehaviour
{

    public void LoadScene(string sceneName_passedTime)
    {
        //the value inputed is diveded into two, the scene name which the script loads and the amount of days that pass because of the transition
        //the values are divided by a "," 
        string[] splitParameters = sceneName_passedTime.Split(',');

        string sceneName = splitParameters[0];
        int passedTime = int.Parse(splitParameters[1]);

        if (passedTime == 1)
        {
            Pet.Instance.motivate();
        }

        calendarManager.Instance.progressTime(passedTime);
        SceneManager.LoadScene(sceneName);


    }

    public void MutationActivation()
    {
        Pet.Instance.mutateElemental();
    }

}
