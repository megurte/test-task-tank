using System;

namespace Interfaces
{
    public interface IInputService
    {
        event Action ChangeWeaponToRight;
        
        event Action ChangeWeaponToLeft;
        
        event Action ShootButtonPressed;
        
        event Action MovementControlUp;
        
        event Action MovementControlDown;
        
        event Action MovementControlRight;
        
        event Action MovementControlLeft;

        event Action StopMovementUp;
        
        event Action StopMovementDown;
        
        event Action StopMovementRight;
        
        event Action StopMovementLeft;
    }
}