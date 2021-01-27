using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuCont : MonoBehaviour
{
   public void LoadHeart(int id)
   {
        StateNameController.modelId = id;
        SceneManager.LoadScene("MainScene");
   }

   public void LoadSkeletal(int id)
   {
        StateNameController.modelId = id;
        SceneManager.LoadScene("MainScene");
   }
}
