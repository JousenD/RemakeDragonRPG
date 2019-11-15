using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class DestroyAfterEffect : MonoBehaviour
    {

        [SerializeField] GameObject targettoDestroy = null;

        // Update is called once per frame
        void Update()
        {
            if (!GetComponent<ParticleSystem>().IsAlive())
            {
                if(targettoDestroy != null)
                {
                    Destroy(targettoDestroy);
                }else
                {
                    Destroy(gameObject);
                }       
            }
        }
    }
}

