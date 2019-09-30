using UnityEngine;
using RPG.Saving;

namespace RPG.Core
{
    public class Health : MonoBehaviour, ISaveable
    {
        
        bool isDead = false;
        [SerializeField] float healthPoints = 100;

        public bool IsDead()
        {
            return isDead;
        }


        public void TakeDamage(float damage){
            healthPoints = Mathf.Max(healthPoints - damage,0);
            if(healthPoints <=0)
            {
                Die();
            }
        }

        private void Die()
        {
            if(isDead) return;

            GetComponent<Animator>().SetTrigger("die");
            isDead = true;
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }

        public object CaptureState()
        {
            return healthPoints;
        }

        public void RestoreState(object state)
        {
            healthPoints = (float)state;

            if (healthPoints <= 0)
            {
                Die();
            }
        }

    }
}