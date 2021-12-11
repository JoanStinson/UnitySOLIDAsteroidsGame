namespace JGM.Game.Input
{
    public class UserInput : IInputService
    {
        public float Vertical { get; private set; }
        public bool ShootProjectile { get; private set; }

        public void ReadInput()
        {
            Vertical = UnityEngine.Input.GetAxis("Vertical");
            ShootProjectile = UnityEngine.Input.GetButtonDown("Submit");
        }
    }
}