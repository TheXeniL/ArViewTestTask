using System;
using CoreLocation;
using MapKit;

namespace ArViewMap
{

    // Здесь я создаю кастомные пины для того, чтобы они позволяли хранить дополнительную информацию по условию задания
    // не успел прочитать про то, как координаты переводить в конкретное местоположение на карте.
    class MapAnnotation : MKAnnotation
    {
        public CLLocationCoordinate2D coord; 
        public string title, subtitle;
        DateTime dateTime; // для определения времени редактирования

        public override CLLocationCoordinate2D Coordinate { get { return coord; } }
        public override void SetCoordinate(CLLocationCoordinate2D value)
        {
            coord = value;
        }
        public override string Title { get { return title; } }
        public override string Subtitle { get { return subtitle; } }
       
        public MapAnnotation(CLLocationCoordinate2D coordinate, string title, string subtitle)
        {
            coord = coordinate;
            this.title = title;
            this.subtitle = subtitle;
            dateTime = DateTime.Now;
        }
    }
}