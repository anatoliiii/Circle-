using System.Text.RegularExpressions;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CirclePointsA
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Play : Page
    {
        Circle _circle1;
        Circle _circle2;
        string sim;
        PointReg _pointReg = new PointReg();
        public Play()
        {
            this.InitializeComponent();
        }

        private void OnResultClicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            TeachingTipCirX1.IsOpen = false;
            TeachingTipCirX2.IsOpen = false;
            TeachingTipCirR1.IsOpen = false;
            TeachingTipCirR2.IsOpen = false;
            if (CircleNull())
            {
                Result();
            }
        }
        private void OnClearClicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {


            Clear();
        }
        internal void Clear()
        {
            resullts.Text = "";
            resullt2.Text = "";
            cirX1.Text = "";
            cirX2.Text = "";
            cirR1.Text = "";
            cirR2.Text = "";
            TeachingTipCirX1.IsOpen = false;
            TeachingTipCirX2.IsOpen = false;
            TeachingTipCirR1.IsOpen = false;
            TeachingTipCirR2.IsOpen = false;

        }

        internal void Result()
        {
            resullts.Text = "";
            resullt2.Text = "";
            double _r1 = 0;
            double _r2 = 0;
            _pointReg.RegEXP(cirX1.Text);
            
            _r1 = cirR1.Value;
            _r2 = cirR2.Value;
            var _x1 = _pointReg._x;
            var _y1 = _pointReg._y;
            _pointReg.RegEXP(cirX2.Text);
            var _x2 = _pointReg._x;
            var _y2 = _pointReg._y;

            _circle1 = new CircleDot(_x1, _y1, _r1);
            _circle2 = new CircleDot(_x2, _y2, _r2);
            CircleDot.CirclePosition(_circle1, _circle2);
            if (CircleDot._circleB)
            {
                resullts.Text = "Точки пересечения:";
                resullt2.Text = "(" + _circle1.Rx + ", " + _circle1.Ry + ")\n" +
                                "(" + _circle2.Rx + ", " + _circle2.Ry + ")\n";
            }
            else if (CircleDot._circleC)
            {
                resullts.Text = "Окружности касаются\n"+ "Точка касания:";
                resullt2.Text = "(" + _circle1.Rx + ", " + _circle1.Ry + ")\n";
            }
            else resullts.Text = CircleDot._state;

            resullts.Visibility = Visibility.Visible;
        }

        private bool CircleNull()
        {
            bool t = true;
            if (Validates(cirX1.Text))
            {
                TeachingTipCirX1.IsOpen = true;
                TeachingTipCirX1.Subtitle = sim;
                t = false;
            }

            if (Validates(cirX2.Text))
            {
                TeachingTipCirX2.IsOpen = true;
                TeachingTipCirX2.Subtitle = sim;
                t = false;
            }

            if (cirR1.Text == "")
            {
                TeachingTipCirR1.IsOpen = true;
                TeachingTipCirR1.Subtitle = "поле не должно быть пустым";
                t = false;
            }

            if (cirR1.Text == "")
            {
                TeachingTipCirR2.IsOpen = true;
                TeachingTipCirR2.Subtitle = "поле не должно быть пустым";
                t = false;
            }

            return t;
        }

        private bool Validates(string s)
        {
            string pattern = @"([-+]?\d+(\.\d+)?)+,+([-+]?\d+(\.\d+)?)+";
            bool t = false;
            if (s == "")
            {
                t = true;
                sim = "поле не должно быть пустым";
            }
            else if (Regex.IsMatch(s, pattern, RegexOptions.IgnoreCase))
            {
                t = false;
            }
            else
            {
                sim = "Введены недопустимые символы";
                t = true;
            }
            return t;
        }
    }
}
