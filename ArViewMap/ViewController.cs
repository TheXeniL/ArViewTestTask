using System;
using CoreGraphics;
using CoreLocation;
using MapKit;
using UIKit;

namespace ArViewMap
{
    public partial class ViewController : UIViewController
    {
        CLLocationManager locationManager = new CLLocationManager();

        protected ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Карту с идентификатором map мы создали в Storyboard, задаем ее параметры при старте приложения
            map.MapType = MKMapType.Standard;
            map.Delegate = new MapDelegate(this); // задаем карте наш делегат для удобного управления
            locationManager.RequestWhenInUseAuthorization(); // запрашиваем доступ к локации пользователя
            map.ShowsUserLocation = true; 

            // Здесь я создаю обработчик клика с задержкой, для размещения пинов на карте
            UILongPressGestureRecognizer longPressGestureRecognizer = new UILongPressGestureRecognizer(LongPressAddPin);
            longPressGestureRecognizer.MinimumPressDuration = 0.5;
            map.AddGestureRecognizer(longPressGestureRecognizer); // добавляем карте обработчик

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }


        // Данная функция служит для получения координат по клику и созданию пина на карте, 
        // к сожалению не успел реализовать необходимые параметры для метки
        public void LongPressAddPin(UILongPressGestureRecognizer gesture){
            if (gesture.State == UIGestureRecognizerState.Ended) {
                var point = gesture.LocationInView(map);
                var coordinate = map.ConvertPoint(point, map);
                Console.WriteLine(coordinate);

                var annotation = new MapAnnotation(coordinate, "Mark1", "Description for mark");
                map.AddAnnotation(annotation);
            }
        }

        // Кнопка для центрировании экрана на пользователе, не успел сделать приближение к координатам пользователя
        partial void ShowLocation_TouchUpInside(UIButton sender)
        {
            map.CenterCoordinate = map.UserLocation.Location.Coordinate;
        }
    }
}
