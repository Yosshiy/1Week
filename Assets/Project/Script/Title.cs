using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    
    void Start()
    {
        Observable.EveryUpdate()
            .Where(x => Input.GetKeyDown(KeyCode.Space))
            .Subscribe(x => SceneManager.LoadScene("Select")).AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
