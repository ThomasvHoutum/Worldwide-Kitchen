using UnityEngine;

namespace Characters
{
    public class Player1 : BaseCharacter
    {
        private KeyCode jump = KeyCode.W;

        private void Start()
        {
            SwitchCharacter(this, "Selection Player 1");    
        }

        void Update()
        {
            UpdateMovement(jump, "Horizontal1", "Vertical1");
        }

        private void FixedUpdate()
        {
            FixedMovement(jump);
        }
    }
}
