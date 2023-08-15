namespace JituCourses{
    class  Register{
        List<UserDTO> newUserList = new List<UserDTO>();

        public void NewUser(List<UserDTO> users){
            Console.WriteLine("fill in the details to create your account");

            Console.WriteLine("Enter your name");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter your email");
            string Email = Console.ReadLine();
            Console.WriteLine("Enter your password");
            string Password = Console.ReadLine();
            
            Console.Write("Add Role (User/Admin): ");
            string role = Console.ReadLine();
                UserDTO NewUser = new UserDTO(Name, Email, Password, role);
                newUserList.Add(NewUser);
                SaveUserToFile(NewUser);
                Console.WriteLine($"{Name} your account created successfully! Confirm your details email:{Email}, role:{role}");
                System.Console.WriteLine("Please login to access our courses");
                Login newLogin = new Login();
                newLogin.LoginUser();
        }

         private void SaveUserToFile(UserDTO user)
        {
            using (StreamWriter writer = new StreamWriter("DATA/users.txt", true))
            {
                writer.WriteLine($"{user.Name},{user.Email},{user.Password},{user.Role}");
            }
        }
        
    }
}