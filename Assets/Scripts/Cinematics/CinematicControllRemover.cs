using UnityEngine.Playables;
using UnityEngine;
using RPG.Core;
using RPG.Control;

namespace RPG.Cinematics
{
    public class CinematicControllRemover : MonoBehaviour
    {
        private GameObject player;

        private void Start() 
        {
            GetComponent<PlayableDirector>().played += DisableControl;
            GetComponent<PlayableDirector>().stopped += EnableControl;
            player = GameObject.FindWithTag("Player");

        }


        private void DisableControl(PlayableDirector pd)
        {
            player.GetComponent<ActionScheduler>().CancelCurrentAction();
            player.GetComponent<PlayerController>().enabled = false;
        }

        private void EnableControl(PlayableDirector pd)
        {
            player.GetComponent<PlayerController>().enabled = true;
        }
    }
}
