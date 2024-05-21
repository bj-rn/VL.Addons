using Stride.Input;
using VL.Lib.Collections;

namespace VL.Stride.Input
{
    public static class InputHelper
    {

        public static IInputSource GetControllers(this IInputSource inputSource, out Spread<IGameControllerDevice> gameControllerDevices)
        {

            var controllers = new SpreadBuilder<IGameControllerDevice>();


            if (inputSource != null)
            {
                foreach (var item in inputSource.Devices)
                {
                    var device = item.Value;

                    if (device is IGameControllerDevice controller)
                        controllers.Add(controller);
                }  
            }

            gameControllerDevices = controllers.ToSpread();

            return inputSource;
        }

    }
}
