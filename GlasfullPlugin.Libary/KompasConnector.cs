using System;
using Kompas6API5;

namespace GlassfullPlugin.Libary
{
    /// <summary>
    /// Класс для подключения к Компас 3D.
    /// </summary>
    public class KompasConnector
    {
        /// <summary>
        /// Интерфейс API КОМПАС 3D.
        /// </summary>
        public KompasObject Kompas { get; set; }
        
        /// <summary>
        /// Запуск Компас 3D.
        /// </summary>
        public void OpenKompas()
        {
            if (Kompas == null)
            {
                //поиск в пространстве COM-объектов объекта со следующим названием.
                var type = Type.GetTypeFromProgID("KOMPAS.Application.5");
                //Создает экземпляр этого приложения и получает на него ссылку. 
                Kompas = (KompasObject)Activator.CreateInstance(type);
            }
            if (Kompas != null)
            {
                //Делаем его видимым.
                Kompas.Visible = true;
                //Передаем управление API. 
                Kompas.ActivateControllerAPI();
            }
        }

        /// <summary>
        /// Закрыть Компас 3D.
        /// </summary>
        public void CloseKompas()
        {
            try
            {
                Kompas.Quit();
                Kompas = null;
            }
            catch
            {
                Kompas = null;
            }
        }
    }
}

