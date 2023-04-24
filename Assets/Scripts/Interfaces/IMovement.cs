namespace Interfaces
{
    public interface IMovement
    {
        void Move(float arg2);
    }
    
    public interface IMovement<in T>
    {
        void Move(T arg1, float arg2);
    }
    
    public interface IMovement<in T1, in T2>
    {
        void Move(T1 arg1, T2 arg2, float arg3);
    }
}