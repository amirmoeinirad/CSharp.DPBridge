
// Amir Moeini Rad
// October 2025

// Main Concept: The Bridge Design Pattern

// In this pattern, we separate an abstraction from its implementation so that the two can vary independently.

// In this example, the Abstraction is a RemoteControl class and the Implementations are Device classes (like a TV/Radio).

namespace BridgeDP
{
    // Interface Implementer
    internal interface IDevice
    {
        void PowerOn();
        void PowerOff();
        void SetChannel(int channel);
    }    


    // Concrete Implementor    
    internal class TV : IDevice
    {
        public void PowerOn()
        {
            Console.WriteLine("TV is ON.");
        }

        public void PowerOff()
        {
            Console.WriteLine("TV is OFF.");
        }

        public void SetChannel(int channel)
        {
            Console.WriteLine($"TV set to channel {channel}.");
        }
    }


    // Concrete Implementor
    internal class Radio : IDevice
    {
        public void PowerOn()
        {
            Console.WriteLine("Radio is ON.");
        }

        public void PowerOff()
        {
            Console.WriteLine("Radio is OFF.");
        }

        public void SetChannel(int channel)
        {
            Console.WriteLine($"Radio tuned to frequency {channel}.");
        }
    }


    // Abstraction
    // RemoteControl uses IDevice to perform operations. It is independent of the specific device (TV/Radio).
    // The Abstraction class doesn't know whether the Implementation class is TV or Radio.
    internal abstract class RemoteControl
    {
        // The Bridge Link
        // _device links the RemoteControl (Higher-Level Abstraction) to TV/Radio (Lower-Level Implementation)
        protected IDevice _device;

        public RemoteControl(IDevice device)
        {
            _device = device;
        }

        public void PowerOnDevice()
        {                      
            _device.PowerOn();
        }

        public void PowerOffDevice()
        {
            _device.PowerOff();
        }

        public abstract void ChangeChannel();
    }


    // Refined Abstraction
    internal class AdvancedRemoteControl : RemoteControl
    {        
        public AdvancedRemoteControl(IDevice device) : base(device) { }

        public override void ChangeChannel()
        {
            _device.SetChannel(5);
        }

        public void Mute()
        {
            Console.WriteLine("Mute button pressed.");        
        }
    }    


    // Client
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("The Bridge Design Pattern in C#.NET.");
            Console.WriteLine("------------------------------------\n");

            
            IDevice tv = new TV();
            AdvancedRemoteControl advancedTvRemote = new(tv);

            Console.WriteLine("--- Controlling TV ---");
            advancedTvRemote.PowerOnDevice();
            advancedTvRemote.ChangeChannel();
            advancedTvRemote.Mute();


            // Control a Radio with the same AdvancedRemoteControl
            IDevice radio = new Radio();
            AdvancedRemoteControl advancedRadioRemote = new(radio);

            Console.WriteLine("\n--- Controlling Radio ---");
            advancedRadioRemote.PowerOnDevice();
            advancedRadioRemote.ChangeChannel();
            advancedRadioRemote.PowerOffDevice();


            Console.WriteLine("\nDone.");
        }
    }
}
