using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AquarelleBot.API.Telegram.Model
{

    /// <summary>
    /// Персонал
    /// </summary>
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PersonId { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string FirsName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Аватарка
        /// </summary>
        public byte Avatar { get; set; }
        
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Список должностей
        /// </summary>
        public Position Position { get; set; }
        /// <summary>
        /// Идентификатор списка должностей
        /// </summary>
        public long PositionId { get; set; }
        /// <summary>
        /// День рожденья
        /// </summary>
        public DateTime BirthDay { get; set; }


    }


    /// <summary>
    /// Список должностей
    /// </summary>
    public class Position
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PositionId { get; set; }
        /// <summary>
        /// Название должности
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Описание должности
        /// </summary>
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public List<Person> Person { get; set; }
    }

    /// <summary>
    /// Компания
    /// </summary>
    public class Company
    {
        /// <summary>
        /// Компания
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CompanyId { get; set; }
        /// <summary>
        /// Название компании
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ID тип компании: подрядчик, арендатор и т.д.
        /// </summary>
        public long TypeCompanyId { get; set; }
        /// <summary>
        /// Тип компании: подрядчик, арендатор и т.д.
        /// </summary>
        public TypeCompany TypeCompany { get; set; }

    }


    /// <summary>
    /// Тип компании: подрядчик, арендатор и т.д.
    /// </summary>
    public class TypeCompany
    {
        /// <summary>
        /// ID тип компании: подрядчик, арендатор и т.д.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TypeCompanyId { get; set; }
        /// <summary>
        /// Тип компании: подрядчик, арендатор и т.д.
        /// </summary>
        public string Name { get; set; }
    }
}
