using System;
using MapKit;
using UIKit;

namespace ArViewMap
{
    // Данный делегат необходим для реадктирования отображения информации пинов, по умолчанию у нас есть только text и subtext,
    // здесь я пытался сделать что при клике на пин высвечивается информация и иконка для перехода к меню редактирования
    public class MapDelegate : MKMapViewDelegate
    {
        
        protected string annotationIdentifier = "BasicAnnotation";
        UIButton detailButton;
        ViewController parent;

        public MapDelegate(ViewController parent)
        {
            this.parent = parent;
        }


        public override MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
        {
            // берем вьювшку из очереди
            MKAnnotationView annotationView = mapView.DequeueReusableAnnotation(annotationIdentifier);

            // если ее нет, то создаем новую
            if (annotationView == null)
                annotationView = new MKPinAnnotationView(annotation, annotationIdentifier);

            else 
                annotationView.Annotation = annotation;

            // задаем параметры для отображения
            annotationView.CanShowCallout = true;
            (annotationView as MKPinAnnotationView).AnimatesDrop = true;
            (annotationView as MKPinAnnotationView).PinColor = MKPinAnnotationColor.Red;
            annotationView.Selected = true;

            // Добавляем кнопку информации
            detailButton = UIButton.FromType(UIButtonType.DetailDisclosure);
            detailButton.TouchUpInside += (s, e) =>
            {
                // Здесь должна была быть логика для перехода в меню редактирования пина, не успел реализовать, для проверки я использовал алерт
                Console.WriteLine("Clicked");
                var detailAlert = UIAlertController.Create((annotation as MapAnnotation).title, (annotation as MapAnnotation).subtitle + annotation.Coordinate.Latitude + " " + annotation.Coordinate.Longitude, UIAlertControllerStyle.Alert);
                detailAlert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

                parent.PresentViewController(detailAlert, true, null);
            };

            annotationView.RightCalloutAccessoryView = detailButton;
            return annotationView;
        }

    }
}