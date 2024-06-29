using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobmGuide : MonoBehaviour
{
    private float _timer = 5f;

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0 )
        {
            _timer = 0;
            gameObject.SetActive(false);
        }
    }
}
