using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ExydeToolbox{
    public class FastSceneReload : MonoBehaviour{
        [SerializeField] KeyCode reloadKey = KeyCode.R;

        void Update(){
            if (Input.GetKeyDown (reloadKey)){
                SceneManager.LoadScene ( SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
    
