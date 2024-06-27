using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    [SerializeField] private BodyPart[] _bodyParts;
    [SerializeField] private Animator _animator;

    public void MakeDynamic()
    {
        _animator.enabled = false;
        foreach (BodyPart part in _bodyParts)
        {
            part.MakeDynamic();
        }
    }

}
