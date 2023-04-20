using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Foundation;
using Syncfusion.SfPicker.XForms.iOS;
using Syncfusion.XForms.iOS.TextInputLayout;
using UIKit;

namespace MyCaloriesDaily.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]

    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            Syncfusion.XForms.iOS.ProgressBar.SfLinearProgressBarRenderer.Init();
            Syncfusion.XForms.iOS.Border.SfBorderRenderer.Init(); 
            SfTextInputLayoutRenderer.Init();
            SfPickerRenderer.Init();
            new Syncfusion.SfNavigationDrawer.XForms.iOS.SfNavigationDrawerRenderer();
            Syncfusion.SfChart.XForms.iOS.Renderers.SfChartRenderer.Init();
            Syncfusion.SfDataGrid.XForms.iOS.SfDataGridRenderer.Init();
            Syncfusion.XForms.iOS.PopupLayout.SfPopupLayoutRenderer.Init();
            Syncfusion.SfGauge.XForms.iOS.SfGaugeRenderer.Init();
            Syncfusion.XForms.iOS.TabView.SfTabViewRenderer.Init();
            Syncfusion.XForms.iOS.Accordion.SfAccordionRenderer.Init();
            new Syncfusion.XForms.iOS.ComboBox.SfComboBoxRenderer();
            // Add the below line for using SfBorder.
            Syncfusion.XForms.iOS.Border.SfBorderRenderer.Init();
            Syncfusion.XForms.iOS.Border.SfBorderRenderer.Init();
            Syncfusion.XForms.iOS.Buttons.SfButtonRenderer.Init();
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentPath, "stajMyCaloriesDaily.db");
            var libraryPath = Path.Combine(path, "..", "Library");
         
            LoadApplication(new App());
          
            return base.FinishedLaunching(app, options);
        }
    }
}
