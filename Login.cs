namespace JituCourses{
    class Login{
         
        public void LoginUser(){
            System.Console.WriteLine("Proceeding with login ...");

            System.Console.WriteLine("Enter email to login: ");
            string email = Console.ReadLine();

            System.Console.WriteLine("Enter your password");
            string password = Console.ReadLine();

            ValidateUser(email, password);

            
        }

    public bool ValidateUser(string email, string password)
    {
        List<UserDTO> users = ReadUsersFromFile();

        foreach (UserDTO user in users)
        {
            if (user.Email == email && user.Password == password)
            {
                string role = user.Role;

                   switch(role){
                case "Admin":
                    Console.WriteLine($"Welcome back Admin {user.Name}");
                    AdminDash display = new AdminDash();
                    display.adminDisplay();
                    break;
                case "User":
                    Console.WriteLine($"Welcome back {user.Name} to Jitu tutor");
                    UserDash newDash = new UserDash();
                    newDash.userDisplay();
                    break;
            }
            }
        }

        return false;
    }

    private List<UserDTO> ReadUsersFromFile()
    {
        List<UserDTO> users = new List<UserDTO>();

        if (File.Exists("DATA/users.txt"))
        {
            using (StreamReader reader = new StreamReader("DATA/users.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');
                    if (values.Length == 4)
                    {
                        UserDTO user = new UserDTO(values[0], values[1], values[2], values[3]);
                        users.Add(user);
                    }
                }
            }
        }

        return users;
    }

    
    }

}
