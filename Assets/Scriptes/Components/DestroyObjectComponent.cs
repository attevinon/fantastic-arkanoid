using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FantasticArkanoid
{
    public class DestroyObjectComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _gObjToDestroy;

        public void DestroyObject()
        {
            Destroy(_gObjToDestroy);
        }
    }
}
