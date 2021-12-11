namespace JGM.Game.Input
{
    public interface IInputService
    {
        float Vertical { get; }
        bool ShootProjectile { get; }

        void ReadInput();
    }
}