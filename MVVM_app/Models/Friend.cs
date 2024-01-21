using SQLite;
using System;
using Xamarin.Forms;

namespace MVVM_app.Models
{
    [Table("Friends")]
    public class Friend
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateOnly => Date.Date;
}
}
