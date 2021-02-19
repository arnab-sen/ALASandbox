using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libraries;
using ProgrammingParadigms;
using DomainAbstractions;

namespace ALASandbox
{
    class Application
    {
        private MainWindow _mainWindow;

        [STAThread]
        public static void Main(string[] args)
        {
            Application app = new Application();
            var mainWindow = app.Initialize()._mainWindow;
            mainWindow.CreateUI();
            var windowApp = mainWindow.CreateApp();
            mainWindow.Run(windowApp);
        }

        private Application Initialize()
        {
            Wiring.PostWiringInitialize();
            return this;
        }

        public Application() 
        {
            CreateWiring();
        }

        private void CreateWiring()
        {
            // BEGIN AUTO-GENERATED INSTANTIATIONS FOR MainDiagram
            MainWindow mainWindow = new MainWindow(height:720,width:1280) {InstanceName="mainWindow"}; /* {"IsRoot":false} */
            Vertical mainWindowContents = new Vertical() {InstanceName="mainWindowContents"}; /* {"IsRoot":false} */
            UIConfig UIConfig_mainWindowContents = new UIConfig() {InstanceName="UIConfig_mainWindowContents"}; /* {"IsRoot":false} */
            // END AUTO-GENERATED INSTANTIATIONS FOR MainDiagram

            // BEGIN AUTO-GENERATED WIRING FOR MainDiagram
            mainWindow.WireTo(UIConfig_mainWindowContents, "iuiStructure"); /* {"SourceType":"MainWindow","SourceIsReference":false,"DestinationType":"UIConfig","DestinationIsReference":false,"Description":"","SourceGenerics":[],"DestinationGenerics":[]} */
            UIConfig_mainWindowContents.WireTo(mainWindowContents, "child"); /* {"SourceType":"UIConfig","SourceIsReference":false,"DestinationType":"Vertical","DestinationIsReference":false,"Description":"","SourceGenerics":[],"DestinationGenerics":[]} */
            // END AUTO-GENERATED WIRING FOR MainDiagram


            _mainWindow = mainWindow;
        }
    }
}