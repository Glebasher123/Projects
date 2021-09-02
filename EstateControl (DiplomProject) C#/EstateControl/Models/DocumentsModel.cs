using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateControl.Models
{
    class DocumentsModel
    {
        public string ФИО { get; set; }
        public string Имя_Документа { get; set; }
        public string Цена_Документа { get; set; }
        public string Тип_Имущества { get; set; }
        public string Улица { get; set; }
        public string Номер_Дома { get; set; }
        public int Номер_Квартиры { get; set; }
        public string Площадь { get; set; }
        public string Цена_Квартиры { get; set; }
        public string Дата_Создания { get; set; }
    }
}
