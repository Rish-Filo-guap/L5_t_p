namespace L5_t_p
{
    public class Station //класс для хранения информации о станции
    {
        static int idCounter = 0; //счетчик индексов
        public int id;//индекс станции
        public string name;//название 
        public int x;//х координата
        public int y;//н координата
        public Color color;//цвет линии
        private static int GetId() { //расчет индекса
        return idCounter++;
        }
        public Station(string name,int x, int y, Color color)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            id = GetId();
            this.color = color;
        }
    }

}
