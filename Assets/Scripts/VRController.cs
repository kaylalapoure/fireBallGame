using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class VRController : MonoBehaviour
    {
        private Hand[] _hands;
        [SerializeField] private SteamVR_Action_Boolean _actionButton = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabGrip");
        [SerializeField] private SteamVR_Action_Boolean _grabButton = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabPinch");
        [SerializeField] private GameObject _throwable;

        private bool _spawned = false;

        public void SpawnAndAttach(Hand passedInhand)
        {
            Hand handToUse = passedInhand;
            if (passedInhand == null)
            {
                handToUse = _hands[0];
            }

            if (handToUse == null)
            {
                return;
            }

            GameObject prefabObject = Instantiate(_throwable) as GameObject;
            handToUse.AttachObject(prefabObject, GrabTypes.Pinch);
        }

        // Start is called before the first frame update
        void Start()
        {
            _hands = GetComponentsInChildren<Hand>();
        }

        // Update is called once per frame
        void Update()
        {
            foreach (var hand in _hands)
            {
                if (WasButtonReleased(_actionButton, hand) && IsButtonDown(_grabButton, hand) && !_spawned)
                {
                    SpawnAndAttach(hand);
                    //_spawned = true;
                }
            }
        }

        private bool WasButtonReleased(SteamVR_Action_Boolean button, Hand hand)
        {
            return button.GetStateUp(hand.handType);
        }

        private bool IsButtonDown(SteamVR_Action_Boolean button, Hand hand)
        {
            return button.GetState(hand.handType);
        }


        private bool WasButtonPressed(SteamVR_Action_Boolean button, Hand hand)
        {
            return button.GetStateDown(hand.handType);
        }
    }
}
