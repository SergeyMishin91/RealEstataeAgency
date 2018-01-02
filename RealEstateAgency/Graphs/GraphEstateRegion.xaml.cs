namespace RealEstateAgency.Graphs
{
    using DAL;
    using Model;
    using Repository;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for GraphEstateRegion.xaml
    /// </summary>
    public partial class GraphEstateRegion : Window
    {
        public GraphEstateRegion()
        {
            InitializeComponent();
        }

        IBuyerRepository buyerRepo = new BuyerRepository();
        List<Buyer> buyers = new List<Buyer>();

        IOwnerRepository ownerRepository = new OwnerRepository();
        List<Owner> owners = new List<Owner>();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var buyer in buyerRepo.GetAll())
            {
                buyers.Add(buyer);
            }

            foreach (var owner in ownerRepository.GetAll())
            {
                owners.Add(owner);
            }

            int buyersCount = buyers.Count;
            int ownersCount = owners.Count;

            int[] data = new int[2] { buyersCount, ownersCount }; 
            var sum = data.Sum();
            var angles = data.Select(d => d * 2.0 * Math.PI / sum);

            var radius = 100.0;

            var startAngle = 0.0;

            var centerPoint = new Point(radius, radius);
            var xyradius = new Size(radius, radius);



            foreach (var angle in angles)
            {
                var endAngle = startAngle + angle;

                var startPoint = centerPoint;
                startPoint.Offset(radius * Math.Cos(startAngle), radius * Math.Sin(startAngle));

                var endPoint = centerPoint;
                endPoint.Offset(radius * Math.Cos(endAngle), radius * Math.Sin(endAngle));

                var angleDeg = angle * 180.0 / Math.PI;

                Path p = new Path()
                {
                    Stroke = Brushes.Black,
                    Fill = Brushes.Green,
                    Data = new PathGeometry(
                            new PathFigure[]
                            {
                                new PathFigure( centerPoint, 
                                new PathSegment[]
                                {
                                    new LineSegment(startPoint, isStroked: true),
                                    new ArcSegment(endPoint, xyradius,
                                                   angleDeg, angleDeg > 180,
                                                   SweepDirection.Clockwise, isStroked: true)
                                },
                            closed: true)
                            })
                };
                container.Children.Add(p);

                startAngle = endAngle;
            }
        }
    }
}
