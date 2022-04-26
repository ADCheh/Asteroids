namespace Enemies.Infrastructure
{
    public interface IDestructionLogic
    {
        void HandleDestruction();

        void AddScore(float score);
    }
}