namespace L5_t_p
{
    public partial class Form1 : Form
    {
        List<Station> stations = new List<Station>();
        Graphics gr;

        int yscale;
        int xscale;
        public Form1()
        {

            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            yscale = Height / 36;
            xscale = Width / 26;
            gr = CreateGraphics();
            CreateStations();
            
            //DrawMap();
            //button1_Click(new object(), new EventArgs());

        }
        public void DrawMap()
        {
            Font font = new Font(DefaultFont, FontStyle.Bold);
            gr.Clear(Color.White);
            yscale = this.Height / 36;
            xscale = this.Width / 26;
            Pen pn = new Pen(Color.Red, 3);// перо: цвет -красный, толщина - 5 пикселей


            Brush brush = new SolidBrush(Color.Black);
            Point pre = new Point(stations[0].x, stations[0].y);
            //gr.DrawLine(pn, 100, 100, 10, 10);
            foreach (Station station in stations)

            {
                if (pn.Color != station.color)
                {

                    pn.Color = station.color;
                    pre = new Point(station.x, station.y);

                }
                //gr.FillEllipse

                gr.DrawEllipse(pn, station.x * xscale + xscale, (station.y + 5) * yscale + yscale, 10, 10);
                gr.DrawLine(pn, station.x * xscale + 5 + xscale, (station.y + 5) * yscale + 5 + yscale, pre.X * xscale + 5 + xscale, (pre.Y + 5) * yscale + 5 + yscale);
                pre = new Point(station.x, station.y);


                gr.DrawString(station.name, font, brush, new PointF(station.x * xscale+ xscale + 5, (station.y + 5) * yscale + 5 + yscale));

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DrawMap();
        }
        private void CreateStations()
        {
            stations.Add(new Station("Kit Kat", 2, 8, Color.Green));
            stations.Add(new Station("Safaa Hegaz", 3, 9, Color.Green));
            stations.Add(new Station("Maspero", 4, 10, Color.Green));
            stations.Add(new Station("Nasser", 5, 10, Color.Green));
            stations.Add(new Station("Attaba", 6, 10, Color.Green));
            stations.Add(new Station("Bab El Shaaria", 7, 10, Color.Green));
            stations.Add(new Station("El Geish", 8, 10, Color.Green));
            stations.Add(new Station("Abdou Pasha", 9, 9, Color.Green));
            stations.Add(new Station("Abbassia", 10, 8, Color.Green));
            stations.Add(new Station("Fair Zone", 11, 7, Color.Green));
            stations.Add(new Station("Cairo Stadium", 12, 6, Color.Green));
            stations.Add(new Station("Koleyet El Banat", 13, 5, Color.Green));
            stations.Add(new Station("Al Ahram", 14, 4, Color.Green));
            stations.Add(new Station("Haroun", 15, 3, Color.Green));
            stations.Add(new Station("Heliopolis Square", 16, 2, Color.Green));
            stations.Add(new Station("Alf Maskan", 17, 1, Color.Green));
            stations.Add(new Station("El Shams Club", 18, 0, Color.Green));
            stations.Add(new Station("El-Nozha", 19, -1, Color.Green));
            stations.Add(new Station("Hesham Barakat", 20, -2, Color.Green));
            stations.Add(new Station("Qobaa", 21, -3, Color.Green));
            stations.Add(new Station("Omar Ibn El-Khattab", 22, -4, Color.Green));
            stations.Add(new Station("El Haykestep", 23, -5, Color.Green));
            stations.Add(new Station("Adly Mansour", 24, -5, Color.Green));

            stations.Add(new Station("Shobra El Kheima", 6, 2, Color.Red));
            stations.Add(new Station("Koliet El-Zeraa", 6, 3, Color.Red));
            stations.Add(new Station("Mezallat", 6, 4, Color.Red));
            stations.Add(new Station("Khalafawy", 6, 5, Color.Red));
            stations.Add(new Station("Sainte Teresa", 6, 6, Color.Red));
            stations.Add(new Station("Road El-Farag", 6, 7, Color.Red));
            stations.Add(new Station("Massara", 6, 8, Color.Red));
            stations.Add(new Station("Al Shohadaa", 6, 9, Color.Red));
            stations.Add(new Station("Attaba", 6, 10, Color.Red));
            stations.Add(new Station("Naguib", 6, 11, Color.Red));
            stations.Add(new Station("Sadat", 5, 11, Color.Red));
            stations.Add(new Station("Opera", 4, 11, Color.Red));
            stations.Add(new Station("Dokki", 3, 11, Color.Red));
            stations.Add(new Station("Bohooth", 2, 11, Color.Red));
            stations.Add(new Station("Cairo University", 1, 12, Color.Red));
            stations.Add(new Station("Faisal", 1, 13, Color.Red));
            stations.Add(new Station("Giza", 1, 14, Color.Red));
            stations.Add(new Station("Omm el Misryeen", 1, 15, Color.Red));
            stations.Add(new Station("Sakiat Mekki", 1, 16, Color.Red));
            stations.Add(new Station("El Mounib", 1, 17, Color.Red));

            stations.Add(new Station("New El-Marg", 15, -5, Color.Blue));
            stations.Add(new Station("El-Marg", 15, -4, Color.Blue));
            stations.Add(new Station("Ezbet El-Nakhl", 15, -3, Color.Blue));
            stations.Add(new Station("Ain Shams", 15, -2, Color.Blue));
            stations.Add(new Station("El-Matareyya", 15, -1, Color.Blue));
            stations.Add(new Station("Helmeyet El-Zaitoun", 15, 0, Color.Blue));
            stations.Add(new Station("Hadayeq El-Zaitoun", 14, 1, Color.Blue));
            stations.Add(new Station("Saray El-Qobba", 13, 2, Color.Blue));
            stations.Add(new Station("Hammamat El-Qobba", 12, 3, Color.Blue));
            stations.Add(new Station("Kobri El-Qobba", 11, 4, Color.Blue));
            stations.Add(new Station("Manshiet El-Sadr", 10, 5, Color.Blue));
            stations.Add(new Station("El-Demerdash", 9, 6, Color.Blue));
            stations.Add(new Station("Ghamra", 8, 7, Color.Blue));
            stations.Add(new Station("Al Shohadaa", 6, 9, Color.Blue));
            stations.Add(new Station("Ahmed Orabi", 5, 9, Color.Blue));
            stations.Add(new Station("Nasser", 5, 10, Color.Blue));
            stations.Add(new Station("Sadat", 5, 11, Color.Blue));
            stations.Add(new Station("Saad Zaghloul", 5, 12, Color.Blue));
            stations.Add(new Station("El-Sayeda Zeinab", 5, 13, Color.Blue));
            stations.Add(new Station("El-Malek El-Saleh", 5, 14, Color.Blue));
            stations.Add(new Station("Mar Girgis", 6, 15, Color.Blue));
            stations.Add(new Station("El-Zahraa'", 7, 16, Color.Blue));
            stations.Add(new Station("Dar El-Salam", 8, 17, Color.Blue));
            stations.Add(new Station("Hadayeq El-Maadi", 9, 18, Color.Blue));
            stations.Add(new Station("Maadi", 10, 19, Color.Blue));
            stations.Add(new Station("Thakanat El-Maadi", 11, 20, Color.Blue));
            stations.Add(new Station("Tora El-Balad", 12, 21, Color.Blue));
            stations.Add(new Station("Kozzika", 12, 22, Color.Blue));
            stations.Add(new Station("Tora El-Asmant", 12, 23, Color.Blue));
            stations.Add(new Station("El-Maasara", 12, 24, Color.Blue));
            stations.Add(new Station("Hadayeq Helwan", 12, 25, Color.Blue));
            stations.Add(new Station("Wadi Hof", 12, 26, Color.Blue));
            stations.Add(new Station("Helwan University", 12, 27, Color.Blue));
            stations.Add(new Station("Ain Helwan", 12, 28, Color.Blue));
            stations.Add(new Station("Helwan", 12, 29, Color.Blue));


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DrawMap();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //label1.Text += "#";
            double distanse = 20;
            int nearId = -1;
            string tn="";
            listBox1.Items.Clear();
            listBox1.Items.Add(e.Location.X.ToString());
            listBox1.Items.Add(e.Location.Y.ToString());
            foreach (Station station in stations) {
                var newdis = Math.Sqrt(Math.Pow((station.y + 5) * yscale + yscale - e.Location.Y,2) + Math.Pow(station.x * xscale + xscale - e.Location.X,2));
                if (newdis <= distanse){
                    distanse = newdis;
                    nearId = station.id;
                    tn = station.name;
                }
            }
            if (nearId != -1) { 
            listBox1.Items.Add(stations[nearId].name);
            listBox1.Items.Add(tn);
            }
        }

       
    }
}
