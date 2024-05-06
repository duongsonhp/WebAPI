namespace College.Models
{
    public class Student
    {
        /// <summary>
        /// Mã số sinh viên
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Tên
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Họ và tên đệm
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Ngày tháng năm sinh
        /// </summary>
        public DateTime BornDate { get; set; }
    }
}
