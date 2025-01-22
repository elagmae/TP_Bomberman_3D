using System;
using System.Threading.Tasks;
using UnityEngine.InputSystem;
public static class VibrationsBehaviour
{
    public static async void Vibrate(float intensity, float duration)
    {
        if (Gamepad.current != null)
        {
            try
            {
                Gamepad.current.SetMotorSpeeds(intensity, intensity);
                await Task.Delay((int)(duration * 1000));
                Gamepad.current.SetMotorSpeeds(0, 0);
            }
            catch (NullReferenceException e)
            {

            }
        }
    }
}

