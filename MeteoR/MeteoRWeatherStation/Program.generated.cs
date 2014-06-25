//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MeteoRWeatherStation {
    using Gadgeteer;
    using GTM = Gadgeteer.Modules;
    
    
    public partial class Program : Gadgeteer.Program {
        
        /// <summary>The Barometer module using socket 2 of the mainboard.</summary>
        private Gadgeteer.Modules.Seeed.Barometer barometer;
        
        /// <summary>The TemperatureHumidity module using socket 3 of the mainboard.</summary>
        private Gadgeteer.Modules.Seeed.TemperatureHumidity temperatureHumidity;
        
        /// <summary>The UsbClientSP module using socket 8 of the mainboard.</summary>
        private Gadgeteer.Modules.GHIElectronics.UsbClientSP usbClientSP;
        
        /// <summary>The GasSense module using socket 4 of the mainboard.</summary>
        private Gadgeteer.Modules.GHIElectronics.GasSense gasSense;
        
        /// <summary>This property provides access to the Mainboard API. This is normally not necessary for an end user program.</summary>
        protected new static GHIElectronics.Gadgeteer.FEZCerberus Mainboard {
            get {
                return ((GHIElectronics.Gadgeteer.FEZCerberus)(Gadgeteer.Program.Mainboard));
            }
            set {
                Gadgeteer.Program.Mainboard = value;
            }
        }
        
        /// <summary>This method runs automatically when the device is powered, and calls ProgramStarted.</summary>
        public static void Main() {
            // Important to initialize the Mainboard first
            Program.Mainboard = new GHIElectronics.Gadgeteer.FEZCerberus();
            Program p = new Program();
            p.InitializeModules();
            p.ProgramStarted();
            // Starts Dispatcher
            p.Run();
        }
        
        private void InitializeModules() {
            this.barometer = new GTM.Seeed.Barometer(2);
            this.temperatureHumidity = new GTM.Seeed.TemperatureHumidity(3);
            this.usbClientSP = new GTM.GHIElectronics.UsbClientSP(8);
            this.gasSense = new GTM.GHIElectronics.GasSense(4);
        }
    }
}
