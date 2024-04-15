using System.Collections;
using System.Text;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace L5_t_p
{
    public partial class Form1 : Form
    {
        List<Station> stations = new List<Station>();
        List<string> allWaysWeight = new List<string>();
        SearchGraph graph;
        Graphics map;
        bool stationSelected = false;
        int yscale;
        int xscale;
        int startStationId;
        int endStationId;
        bool isWayDrawed = false;
        public Form1()
        {

            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            yscale = Height / 36;
            xscale = Width / 26;
           map= CreateGraphics();
            CreateStations();
            CreateEdges();
            //DrawMap();
            //button1_Click(new object(), new EventArgs());

        }
        public void DrawMap()
        {
            Font font = new Font(DefaultFont, FontStyle.Bold);
            map.Clear(Color.LightGray);
            yscale = this.Height / 37;
            xscale = this.Width / 26;
            Pen pn = new Pen(Color.Red, 1);// перо: цвет -красный, толщина - 5 пикселей


            Brush brush = new SolidBrush(Color.Black);
            int[] pre = { stations[0].x, stations[0].y };

            foreach (Station station in stations)

            {
                if (pn.Color != station.color)
                {

                    pn.Color = station.color;
                    pre = [station.x, station.y, station.id];

                }
                //map.FillEllipse
                pn.Width = 2;
                map.DrawEllipse(pn, station.x * xscale + xscale/2, (station.y + 5) * yscale + yscale, 10, 10);
                pn.Width = 1;
                map.DrawLine(pn, station.x * xscale + 5 + xscale/2, (station.y + 5) * yscale + 5 + yscale, pre[0] * xscale + 5 + xscale/2, (pre[1] + 5) * yscale + 5 + yscale);
                pre = [station.x, station.y, station.id];



                map.DrawString(station.name, font, brush, new PointF(station.x * xscale + xscale/2 + 5, (station.y + 5) * yscale + 5 + yscale));


            }

        }

        private Station MakeStationFromString(string line)
        {
            string name = "";
            int pos = 0;
            while (line[pos] != ',')
            {
                name += line[pos];
                pos++;
            }
            pos++;
            string xpos = "";
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
            while (pos < line.Length)
            {
                color += line[pos];
                pos++;
            }
            return new Station(name, int.Parse(xpos), int.Parse(ypos), Color.FromName(color));
        }
        private void AddEdgesFromString(string line)
        {
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
            allWaysWeight.Add(stations[int.Parse(left)].name + " -> " + stations[int.Parse(right)].name + " (" + int.Parse(weight) + ")");
            allWaysWeight.Add(stations[int.Parse(right)].name + " -> " + stations[int.Parse(left)].name + " (" + int.Parse(weight) + ")");
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
            if (startStationId != -1 && endStationId != -1 && endStationId != startStationId)
            {

                DrawMap();
                listBox2.Items.Clear();
                Pen pn = new Pen(Color.Gold, 3);
                var list = graph.Dijkstra(startStationId, endStationId);

                map.DrawEllipse(pn, stations[list[0][0]].x * xscale + -10 + xscale/2, (stations[list[0][0]].y + 5) * yscale - 10 + yscale, 30, 30);
                listBox2.Items.Add(stations[list[0][0]].name);

                if (list.Count != 0)
                {
                    for (int i = 0; i < list.Count - 1; i++)
                    {
                        pn.Color = stations[list[i][1]].color;
                        map.DrawEllipse(pn, stations[list[i][1]].x * xscale + -10 + xscale/2, (stations[list[i][1]].y + 5) * yscale - 10 + yscale, 30, 30);
                        listBox2.Items.Add(list[i][2]);
                        listBox2.Items.Add(stations[list[i][1]].name);
                    }
                }
                WaylenthLabel.Text = (list[list.Count - 1][0]).ToString();
                isWayDrawed = true;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DrawMap();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (isWayDrawed)
            {
                DrawMap();
                isWayDrawed = false;
            }
            double distanse = 20;
            int nearId = -1;
            Pen pn = new Pen(Color.Purple, 3);

            foreach (Station station in stations)
            {
                var newdis = Math.Sqrt(Math.Pow((station.y + 5) * yscale + yscale - e.Location.Y, 2) +
                                       Math.Pow(station.x * xscale + xscale/2 - e.Location.X, 2));
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

                    EndStation.Text = stations[nearId].name;
                    stationSelected = false;
                    endStationId = nearId;
                    map.DrawEllipse(pn, stations[nearId].x * xscale + -10 + xscale / 2, (stations[nearId].y + 5) * yscale - 10 + yscale, 30, 30);
                }
                else
                {

                    EndStation.Text = "";
                    StartStation.Text = "";
                    startStationId = -1;
                    endStationId = -1;
                    DrawMap();
                    map.DrawEllipse(pn, stations[nearId].x * xscale + -10 + xscale / 2, (stations[nearId].y + 5) * yscale - 10 + yscale, 30, 30);

                    StartStation.Text = stations[nearId].name;
                    startStationId = nearId;
                    stationSelected = true;

                }
            }



        }

        private void ShowAllWeight_Button_Click(object sender, EventArgs e)
        {

            Form2 allweight = new Form2();
            foreach (var way in allWaysWeight) { 
                allweight.listBox1.Items.Add(way);
                //allweight.listBox1.Items.Add(way.Key.ToString() + " -> "+ way.Value[0].Item1.ToString()+" ("+ way.Value[0].Item2+")");
            }
            
            allweight.listBox1.Sorted = true;
            allweight.ShowDialog();
        }
    }
}
