using Routing_Application.Domain;
using Routing_Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routing_Application.DAL
{
    public class FieldToolKit
    {
        /* Делегаты управления */
        public Action UpdateField { get; set; }                         // ссылка на метод ctlPicBox.Invalidate()
        public Action<bool> SwitchCalcButton { get; set; }              // ссылка на методо, управляющий кнопкой Recalculate

        public FieldToolKit() { }

        public FieldToolKit(Action UpdateField) 
        {
            this.UpdateField = UpdateField;
            this.SwitchCalcButton = SwitchCalcButton;
        }
    }
}
