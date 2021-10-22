using System;
using System.Collections.Generic;
using System.Drawing;

using Routing_Application.Domain;

namespace Routing_Application.DAL
{
    /// <summary>
    /// класс, хранящий топологию
    /// </summary>
    [Serializable()]
    public class Data
    {
        public Network Network { get; set; }          // топология
        public Size FieldSize { get; set; }           // размер Рабочего Поля
        public string FilePath { get; set; }          // путь к файлу
    }
}
