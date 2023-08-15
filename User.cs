namespace JituCourses{

    public enum Role{
        User = 1,
        Admin = 2
    }
    class UserDTO{
        public string Name { get; set;}
        public string Email { get; set;}
        public string Password { get; set;}
        public string Role { get; set;}

        public UserDTO(string name, string email, string password, string Role) {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.Role = Role;
        }
        }


    }