using EstateControl.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateControl.Models
{
    class EstateModel
    {
        public string Тип { get; set; }
        public int Этаж { get; set; }
        public int Количесвто_Комнат { get; set; }
        public string Площадь { get; set; }
        public int Номер_Квартиры { get; set; }
        public string Номер_Дома { get; set; }
        public string Цена { get; set; }
        public string Город { get; set; }
        public string Улица { get; set; }
        public string Примечания { get; set; }
    }
}
