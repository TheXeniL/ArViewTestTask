// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace ArViewMap
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MapKit.MKMapView map { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton showLocation { get; set; }

        [Action ("ShowLocation_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ShowLocation_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (map != null) {
                map.Dispose ();
                map = null;
            }

            if (showLocation != null) {
                showLocation.Dispose ();
                showLocation = null;
            }
        }
    }
}