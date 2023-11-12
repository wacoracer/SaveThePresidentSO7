using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextScene1 : MonoBehaviour
{
    public GameObject textFirst;
    public GameObject textSecond;
    public GameObject textThird;

    [SerializeField] float firstWait = 3;
    [SerializeField] float secondWait = 2;
    [SerializeField] float thirdWait = 2;

    
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
        yield return new WaitForSeconds(secondWait);
        textThird.SetActive(true);
        yield return new WaitForSeconds(thirdWait);

        SceneManager.LoadScene("Game");
    }
}
