using FantasticArkanoid.Scriptable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FantasticArkanoid
{
    [RequireComponent(typeof(ParticleSystem))]
    public class BaseBrick : MonoBehaviour
    {
        private ParticleSystem _debrisParticles;

#if UNITY_EDITOR
        public BrickData Data;
#endif
        public void Initialize(BrickData data)
        {
            _debrisParticles = GetComponent<ParticleSystem>();

            ParticleSystem.MainModule mainDebrisParticles = _debrisParticles.main;
            mainDebrisParticles.startColor = new ParticleSystem.MinMaxGradient(data.ParticlesColor);
        }
        public void SpawnDebrisParticles()
        {
            _debrisParticles.Play();
        }

    }
}
