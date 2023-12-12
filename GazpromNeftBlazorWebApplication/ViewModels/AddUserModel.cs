using System.ComponentModel;

namespace GazpromNeftBlazorWebApplication.ViewModels
{
    public class AddUserModel
    {
        [DisplayName("Имя")]
        public string FirstName { get; set; } = string.Empty;
        [DisplayName("Фамилия")]
        public string LastName { get; set; } = string.Empty;
        [DisplayName("Отчество")]
        public string Patronymic { get; set; } = string.Empty;
        [DisplayName("Электронная почта")]
        public string Email { get; set; } = string.Empty;
        [DisplayName("Телефон")]
        public string Phone { get; set; } = string.Empty;
    }
}
