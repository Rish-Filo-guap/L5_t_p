using System.Collections;
using System.Text;

namespace L5_t_p
{
    public partial class Form1 : Form
    {
        List<Station> stations = new List<Station>();
        SearchGraph graph;
        Graphics gr;
        bool stationSelected = false;
        int yscale;
        int xscale;
        int startStationId;
        int endStationId;
        public Form1()
        {

            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            yscale = Height / 36;
            xscale = Width / 26;
            gr = CreateGraphics();
            CreateStations();
            CreateEdges();
            //DrawMap();
            //button1_Click(new object(), new EventArgs());

        }
        public void DrawMap()
        {
            Font font = new Font(DefaultFont, FontStyle.Bold);
            gr.Clear(Color.White);
            yscale = this.Height / 37;
            xscale = this.Width / 26;
            Pen pn = new Pen(Color.Red, 3);// перо: цвет -красный, толщина - 5 пикселей


            Brush brush = new SolidBrush(Color.Black);
            int[] pre = { stations[0].x, stations[0].y, stations[0].id };
            //gr.DrawLine(pn, 100, 100, 10, 10);
            foreach (Station station in stations)

            {
                if (pn.Color != station.color)
                {

                    pn.Color = station.color;
                    pre = [station.x, station.y, station.id];

                }
                //gr.FillEllipse

                gr.DrawEllipse(pn, station.x * xscale + xscale, (station.y + 5) * yscale + yscale, 10, 10);
                gr.DrawLine(pn, station.x * xscale + 5 + xscale, (station.y + 5) * yscale + 5 + yscale, pre[0] * xscale + 5 + xscale, (pre[1] + 5) * yscale + 5 + yscale);
                pre = [station.x, station.y, station.id];


                gr.DrawString(station.name, font, brush, new PointF(station.x * xscale + xscale + 5, (station.y + 5) * yscale + 5 + yscale));
                //gr.DrawString(station.id.ToString(), font, brush, new PointF(station.x * xscale + xscale + 5, (station.y + 5) * yscale + 5 + yscale));

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DrawMap();
        }
        private Station MakeStationFromString(string line) {
            string name = "";
            int pos=0;
            while (line[pos] != ',') {
                name += line[pos];
                pos++;
            }
            pos++;
            string xpos="";
            while (line[pos] != ',')
            {
                xpos += line[pos];
                pos++;
            }
            pos++;
            string ypos = "";
            while (line[pos] != ',')
            {
                ypos += line[pos];
                pos++;
            }
            pos++;
            string color = "";
            while (pos<line.Length)
            {
                color += line[pos];
                pos++;
            }
            return new Station(name, int.Parse(xpos), int.Parse(ypos), Color.FromName(color));
        }
        private void AddEdgesFromString(string line) {
            string left = "";
            int pos = 0;
            while (line[pos] != ',')
            {
                left += line[pos];
                pos++;
            }
            pos++;
            string right = "";
            while (line[pos] != ',')
            {
                right += line[pos];
                pos++;
            }
            pos++;
            string weight = "";
            while (pos < line.Length)
            {
                weight += line[pos];
                pos++;
            }
            graph.AddEdge(int.Parse(left), int.Parse(right), int.Parse(weight));
        }
        private void CreateStations()
        {
            string prpath = AppDomain.CurrentDomain.BaseDirectory + "Info/StationsInfo.txt";
            using (StreamReader sr = new StreamReader(prpath, Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()!) != null)
                {
                   stations.Add(MakeStationFromString(line));
                }
            }
            
            listBox1.Items.Add(prpath);
            


        }

        private void CreateEdges()
        {
            int vertices = 0;
            string prpath = AppDomain.CurrentDomain.BaseDirectory + "Info/EdgesInfo.txt";
            graph = new SearchGraph(File.ReadAllLines(prpath).Length);
            using (StreamReader sr = new StreamReader(prpath, Encoding.Default))

            {
                
                string line;
                while ((line = sr.ReadLine()!) != null)
                {
                    AddEdgesFromString(line);
                    vertices++;
                }
            }

        }
        private void findwayButton_Click(object sender, EventArgs e)
        {

            StartStation.Text = startStationId+" "+ endStationId;
            var list = graph.Dijkstra(startStationId, endStationId);
            WaylenthLabel.Text = list[0].ToString();
            for (int i=1; i<list.Count;i++) {
                
                listBox2.Items.Add(list[i]);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DrawMap();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            double distanse = 20;
            int nearId = -1;

            listBox1.Items.Clear();
            listBox1.Items.Add(e.Location.X.ToString());
            listBox1.Items.Add(e.Location.Y.ToString());
            foreach (Station station in stations)
            {
                var newdis = Math.Sqrt(Math.Pow((station.y + 5) * yscale + yscale - e.Location.Y, 2) +
                                       Math.Pow(station.x * xscale + xscale - e.Location.X, 2));
                if (newdis <= distanse)
                {
                    distanse = newdis;
                    nearId = station.id;
                }
            }
            if (nearId != -1)
            {

                if (stationSelected)
                {

                    EndStation.Text = stations[nearId].name + " " + nearId;
                    stationSelected = false;
                    endStationId = nearId;
                }
                else
                {

                    EndStation.Text = "";
                    StartStation.Text = "";
                    startStationId = 0;
                    endStationId = 0;

                    StartStation.Text = stations[nearId].name + " " + nearId;
                    startStationId = nearId;
                    stationSelected = true;

                }
            }



        }

    }
}
