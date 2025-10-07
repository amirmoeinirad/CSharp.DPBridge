
// Amir Moeini Rad
// October 2025

// Main Concept: Bridge Design Pattern
// With help from Gemini

// In this pattern, we separate an abstraction from its implementation so that the two can vary independently.
// This is useful when both the abstractions and their implementations may change frequently.

// In this example, the Abstraction will be a RemoteControl and the Implementation will be a Device (like a TV or Radio).

namespace BridgeDP
{
    // Defines the interface for implementation classes.
    internal interface IDevice
    {
        void PowerOn();
        void PowerOff();
        void SetChannel(int channel);
    }


    //-------------------------------------------------


    // Concrete Implementor
    // Implements the Implementor interface with specific functionality.
    internal class Tv : IDevice
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


    //-------------------------------------------------


    // Abstraction Class
    // Holds a reference to the Implementor (IDevice) and defines the high-level logic.
    // In other words, RemoteControl uses IDevice to perform operations. It is independent of the specific device (TV/Radio/etc).
    // If we add new devices such as DVD players, we don't need to change RemoteControl and AdvancedRemoteControl.
    // To summarize, IDevice interface is the bridge that decouples
    // RemoteControl and AdvancedRemoteControl from the specific device implementations.
    internal abstract class RemoteControl
    {
        // The "bridge" or link to the implementation
        // IDevice links the RemoteControl (Abstraction) to TV/Radio (Implementation)
        protected IDevice _device;

        public RemoteControl(IDevice device)
        {
            _device = device;
        }

        public void TogglePower()
        {
            // High-level operation that uses the underlying implementation
            // For simplicity, we'll just power it on here.
            _device.PowerOn();
        }

        // Abstract method for concrete abstractions
        public abstract void NextAction();
    }


    // --- Refined Abstraction Class ---
    // Extends the Abstraction and adds more sophisticated control.
    internal class AdvancedRemoteControl : RemoteControl
    {
        // Again, we use IDevice to link AdvancedRemoteControl to TV/Radio
        public AdvancedRemoteControl(IDevice device) : base(device) { }

        public override void NextAction()
        {
            _device.SetChannel(5);
        }

        public void Mute()
        {
            Console.WriteLine("Mute button pressed.");            
        }
    }


    //-------------------------------------------------


    // Client code
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("The Bridge Design Pattern in C#.NET.");
            Console.WriteLine("------------------------------------\n");


            // 1. Control a TV with an AdvancedRemoteControl
            IDevice tv = new Tv();
            AdvancedRemoteControl advancedTvRemote = new AdvancedRemoteControl(tv);

            Console.WriteLine("--- Controlling TV ---");
            advancedTvRemote.TogglePower(); // Uses the Abstraction (RemoteControl)
            advancedTvRemote.NextAction();  // Uses the Refined Abstraction (AdvancedRemoteControl)
            advancedTvRemote.Mute(); // Specific AdvancedRemoteControl action


            // 2. Control a Radio with the same AdvancedRemoteControl
            IDevice radio = new Radio();
            AdvancedRemoteControl advancedRadioRemote = new AdvancedRemoteControl(radio);

            Console.WriteLine("\n--- Controlling Radio ---");
            advancedRadioRemote.TogglePower(); // Uses the Abstraction (RemoteControl)
            advancedRadioRemote.NextAction();  // Uses the Refined Abstraction (AdvancedRemoteControl)         


            Console.WriteLine("\nDone.");
        }
    }
}
