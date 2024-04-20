using System.Collections;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using System.Drawing.Drawing2D;

namespace L5_t_p
{
    public partial class Form1 : Form
    {
        List<Station> stations = new List<Station>(); //массив станций
        List<string> allWaysWeight = new List<string>(); //массив всех весов между станциями
        SearchGraph graph; //объект класса поиск по графу
        Graphics map; //карта метро
        BufferedGraphics buffered; //буфер для карты
        BufferedGraphicsContext currentContext;

        bool stationSelected = false; //какая станция выбрана
        int yscale;//масштабирование по у
        int xscale;//масштабирование по х
        int startStationId; //страртовая станция
        int endStationId;//конечная станция
        bool isWayDrawed = false; //нарисован ли путь между станциями
        public Form1()
        {

            InitializeComponent();
            WindowState = FormWindowState.Maximized;//развернуть на полный экран
            yscale = Height / 36;//расчитать коэффициент увеличения по оси у
            xscale = Width / 24;//расчитать коэффициент увеличения по оси х
            map = CreateGraphics();
            currentContext = BufferedGraphicsManager.Current;
            buffered =currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            //DoubleBuffered = true;

            CreateStations();//считать станции из файла
            CreateEdges();//считать пути между станциями из файла

        }
        
        public void DrawMap()//нарисовать карту
        {
            Font font = new Font(DefaultFont, FontStyle.Bold); //шрифт для названия станций
            
            


            buffered.Graphics.Clear(Color.LightGray);//фоновый цвет

            Pen pn = new Pen(Color.Red, 1);//установка типа линии ветки
            Brush brush = new SolidBrush(Color.Black);//устнаовка цвета текста

            int[] pre = { stations[0].x, stations[0].y };//первая точка для построения линии

            foreach (Station station in stations) //цикл отрисовки карты метро

            {
                if (pn.Color != station.color)//изменение цвета при смене ветки
                {

                    pn.Color = station.color;
                    pre = [station.x, station.y, station.id];

                }
                pn.Width = 2;
                buffered.Graphics.DrawEllipse(pn, GetXFromCoord(station.x)-5, GetYFromCoord(station.y)-5, 10, 10);//круг в точке станции
                pn.Width = 1;
                buffered.Graphics.DrawLine(pn, GetXFromCoord(station.x), GetYFromCoord(station.y), GetXFromCoord(pre[0]), GetYFromCoord(pre[1]));//линия между станциями
                pre = [station.x, station.y, station.id];



              


                using (Matrix m = new Matrix())//поворот надписи
                {
                    m.RotateAt(7, new PointF(GetXFromCoord(station.x)+5, GetYFromCoord(station.y)-10));
                    buffered.Graphics.Transform = m;

                    buffered.Graphics.DrawString(station.name, font, brush, new PointF(GetXFromCoord(station.x)+5, GetYFromCoord(station.y)-10));//назавнание станции
                    buffered.Graphics.ResetTransform();
                }

                

            }
            buffered.Render();//генерация в буфере
            buffered.Render(map);//вывод на экран
        }

        private Station MakeStationFromString(string line)//чтение станции из файла
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
        private void AddEdgesFromString(string line)//чтение ребра из файла
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
            //создание списка всех путей
            allWaysWeight.Add(stations[int.Parse(left)].name + " -> " + stations[int.Parse(right)].name + " (" + int.Parse(weight) + ")");
            allWaysWeight.Add(stations[int.Parse(right)].name + " -> " + stations[int.Parse(left)].name + " (" + int.Parse(weight) + ")");

            //добавление ребра в граф
            graph.AddEdge(int.Parse(left), int.Parse(right), int.Parse(weight));
        }
        private void CreateStations()//создание массива станций
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

        private void CreateEdges()//создание массива ребер
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
        private int GetXFromCoord(int x) {//расчет х координаты для рисования фигур
            return x * xscale + -5;
        }
        private int GetYFromCoord(int y) {//расчет у координаты для рисовани фигур
            return (y + 5) * yscale - 5 + yscale;
        }
        private void FindWay() {//поиск и отрисовка пути
            if (startStationId != -1 && endStationId != -1 && endStationId != startStationId)
            {
                Point pre;
                Pen pn;
                listBox2.Items.Clear();
                    pn = new Pen(Color.Gold, 3);
                
                var list = graph.Dijkstra(startStationId, endStationId);//расчитать список станций на пути
                pre = new Point(GetXFromCoord(stations[list[0][0]].x) - 15, GetYFromCoord(stations[list[0][0]].y));
                map.DrawEllipse(pn, GetXFromCoord(stations[list[0][0]].x) - 15, GetYFromCoord(stations[list[0][0]].y) - 15, 30, 30);//начало пути
                listBox2.Items.Add(stations[list[0][0]].name);//написать название станции

                if (list.Count != 0)
                {
                    for (int i = 0; i < list.Count - 1; i++)
                    {
                        pn.Color = stations[list[i][1]].color;
                        Thread.Sleep(150);
                        if (new Point(GetXFromCoord(stations[list[i][1]].x) - 15, GetYFromCoord(stations[list[i][1]].y))==pre)
                            map.DrawEllipse(pn, GetXFromCoord(stations[list[i][1]].x) - 18, GetYFromCoord(stations[list[i][1]].y) - 18, 36, 36);//выделить станцию на пути
                        else 
                            map.DrawEllipse(pn, GetXFromCoord(stations[list[i][1]].x) - 15, GetYFromCoord(stations[list[i][1]].y) - 15, 30, 30);//выделить станцию на пути
                        listBox2.Items.Add(list[i][2]);//вывести дистанцию между станциями
                        listBox2.Items.Add(stations[list[i][1]].name);//вывести имя станции
                        pre = new Point(GetXFromCoord(stations[list[i][1]].x) - 15, GetYFromCoord(stations[list[i][1]].y));
                    }
                }
                WaylenthLabel.Text = (list[list.Count - 1][0]).ToString();//вывести длину всего пути
                isWayDrawed = true;
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DrawMap();//нарисвовать карту при загрузке формы
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (isWayDrawed)
            {
                isWayDrawed = false;
            }
            double distanse = 20;//максимальное расстояние от точки клика до станции
            int nearId = -1;//выбранная станция
            Pen pn = new Pen(Color.Purple, 3);

            foreach (Station station in stations)
            {
                //рассточние между станцией и точкой клика
                var newdis = Math.Sqrt(Math.Pow(GetYFromCoord(station.y) - e.Location.Y, 2) +
                                       Math.Pow(GetXFromCoord(station.x) - e.Location.X, 2));
                
                if (newdis <= distanse)//нахождение близжайшей станции
                {
                    distanse = newdis;
                    nearId = station.id;

                }
            }
            if (nearId != -1)
            {
                
                if (stationSelected)//выбрана станция конца
                {
                    EndStation.Text = stations[nearId].name;
                    //stationSelected = false;
                    endStationId = nearId;
                    map.DrawEllipse(pn, GetXFromCoord(stations[nearId].x)-15, GetYFromCoord(stations[nearId].y)-15, 30, 30);
                    
                    FindWay();//нарисовать маршрут
                }
                else//выбрана станция начала
                {

                    EndStation.Text = "";//сбросить имя конечной станции
                    StartStation.Text = "";//сбросить имя начальной станции

                    startStationId = -1;//сбросить индекс начальной станции
                    endStationId = -1;//сбросить индекс конечной станции
                    DrawMap();//убрать отрисованный маршрут
                    pn.Color = Color.Purple;
                    map.DrawEllipse(pn, GetXFromCoord(stations[nearId].x)-15, GetYFromCoord(stations[nearId].y)-15, 30, 30);//выделить начальную станцию

                    StartStation.Text = stations[nearId].name;//вывести имя начальной станции
                    startStationId = nearId; //записать индекс начальной станции
                }
                stationSelected = !stationSelected;//изменить флаг начальной или конечной станции
            }



        }

        private void ShowAllWeight_Button_Click(object sender, EventArgs e)//вывести список всех путей между станциями
        {

            Form2 allweight = new Form2();
            foreach (var way in allWaysWeight) { 
                allweight.listBox1.Items.Add(way);//добавить список всех путей
            }
            
            allweight.listBox1.Sorted = true;//отсортировать список
            allweight.ShowDialog();//вывести диалог с формой
        }
    }
}
