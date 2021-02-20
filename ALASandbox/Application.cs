using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
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
            KeyEvent id_fd1697fb6a6948e58074e4764f33c12b = new KeyEvent(eventName:"KeyDown") {InstanceName="id_fd1697fb6a6948e58074e4764f33c12b",Key=Key.A}; /* {"IsRoot":false} */
            PopupWindow id_727a2a63cddd49629a222ccedb6094fd = new PopupWindow() {InstanceName="id_727a2a63cddd49629a222ccedb6094fd",Height=500,Width=500,Resize=SizeToContent.Manual}; /* {"IsRoot":false} */
            // END AUTO-GENERATED INSTANTIATIONS FOR MainDiagram

            // BEGIN AUTO-GENERATED WIRING FOR MainDiagram
            mainWindow.WireTo(UIConfig_mainWindowContents, "iuiStructure"); /* {"SourceType":"MainWindow","SourceIsReference":false,"DestinationType":"UIConfig","DestinationIsReference":false,"Description":"","SourceGenerics":[],"DestinationGenerics":[]} */
            UIConfig_mainWindowContents.WireTo(mainWindowContents, "child"); /* {"SourceType":"UIConfig","SourceIsReference":false,"DestinationType":"Vertical","DestinationIsReference":false,"Description":"","SourceGenerics":[],"DestinationGenerics":[]} */
            mainWindow.WireTo(id_fd1697fb6a6948e58074e4764f33c12b, "eventHandlers"); /* {"SourceType":"MainWindow","SourceIsReference":false,"DestinationType":"KeyEvent","DestinationIsReference":false,"Description":"","SourceGenerics":[],"DestinationGenerics":[]} */
            id_fd1697fb6a6948e58074e4764f33c12b.WireTo(id_727a2a63cddd49629a222ccedb6094fd, "eventHappened"); /* {"SourceType":"KeyEvent","SourceIsReference":false,"DestinationType":"PopupWindow","DestinationIsReference":false,"Description":"","SourceGenerics":[],"DestinationGenerics":[]} */
            // END AUTO-GENERATED WIRING FOR MainDiagram


            _mainWindow = mainWindow;
        }
    }
}