using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextScene : MonoBehaviour
{
    public GameObject textFirst;
    public GameObject textSecond;

    [SerializeField] float firstWait = 5;

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NextScene());
    }



    IEnumerator NextScene()
    {
        textFirst.SetActive(true);
        yield return new WaitForSeconds(firstWait);
        textSecond.SetActive(true);
    }
}
