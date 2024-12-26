namespace DTO.Employee
{
    public class UserAccountDTO
    {
        public string Username { get; set; } = null!;

        public string? Password { get; set; }

        public string? EmployeeId { get; set; }

        public virtual EmployeeDTO? Employee { get; set; }
    }
}
