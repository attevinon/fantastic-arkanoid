using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FantasticArkanoid.Components
{
    internal class EnterCollisionComponent : MonoBehaviour
    {
        [SerializeField] private string _tag;
        [SerializeField] private UnityEvent _action;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(_tag))
            {
                _action?.Invoke();
            }
        }
    }
}
