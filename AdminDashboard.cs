namespace JituCourses{
    public class AdminDash {

        
        public void adminDisplay(){
           

            Console.WriteLine("1. Add a new Course");
            Console.WriteLine("2. View all Courses");
            Console.WriteLine("3. Delete a Course ");
            Console.WriteLine("4. Update a Course");
            Console.WriteLine("5. View Analytics");

            Console.WriteLine("select way to proceed");
            string selectedOption = Console.ReadLine();

            switch(selectedOption){
                case "1":
                    Console.WriteLine("Proceeding to add new course");
                     AddCourse();
                    break;
                case "2":
                    Console.WriteLine("Proceeding to View all Courses");
                    GetAllCourses();
                    break;
                case "3":
                    Console.WriteLine("Proceeding to Delete a Course");
                    GetAllCourses();
                    System.Console.WriteLine("select name of course to delete");
                    string course =Console.ReadLine();
                    DeleteCourse(course);
                    GetAllCourses();
                    break;
                case "4":
                    Console.WriteLine("Proceeding to Update a Course");
                    break;
                case "5":
                    Console.WriteLine("Proceeding to View Analytics");
                    DisplayPurchasedCourses();
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
                
            }

        }
        List<CourseDTO> newCourseList = new List<CourseDTO> ();
        public void AddCourse(){

            Console.WriteLine("fill in course details");


            Console.WriteLine("Enter course ID");
            string ID = Console.ReadLine();
            Console.WriteLine("Enter course Name");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter course description");
            string Description = Console.ReadLine();
            Console.WriteLine("Enter course Price");
            string Price = Console.ReadLine();

            CourseDTO newCourse = new CourseDTO(ID, Name, Description, Price);
                newCourseList.Add(newCourse);
                SaveCourseToFile(newCourse);
                Console.WriteLine($"{Name} successfully added");

        }

         private void SaveCourseToFile(CourseDTO course)
        {
            using (StreamWriter writer = new StreamWriter("DATA/courses.txt", true))
            {
                writer.WriteLine($"{course.Name},{course.Description},{course.Price}");
            }
        }

        public void GetAllCourses(){

            System.Console.WriteLine("Jitu courses");
            List<CourseDTO> courses = ReadCoursesFromFile("DATA/courses.txt");
            
            for(int x=1; x < courses.Count;)
            foreach (CourseDTO course in courses)          
            {
                Console.WriteLine($"{x++}. Name: {course.Name}, Description: {course.Description}, Price: {course.Price}");

            }
                
        }
        


        static List<CourseDTO> ReadCoursesFromFile(string filePath)
        {
            List<CourseDTO> courses = new List<CourseDTO>();

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] fields = line.Split(',');

                    if (fields.Length == 4)
                    {
                        string id = fields[0];
                        string name = fields[1];
                        string description = fields[2];
                        string price = fields[3];

                        CourseDTO course = new CourseDTO(id, name, description, price);
                        courses.Add(course);
                    }
                }
            }

            return courses;
        }

    private void DisplayPurchasedCourses()
    {
        List<PurchasedCoursesDTO> purchasedCourses = ReadPurchasedCoursesFromFile("DATA/analytics.txt");

        if (purchasedCourses.Count == 0)
        {
            Console.WriteLine("No purchased courses found.");
            return;
        }

        Console.WriteLine("Purchased Courses:");
        // for(int x=1; x < purchasedCourses.Count;)
        foreach (PurchasedCoursesDTO purchasedCourse in purchasedCourses)
        {
            Console.WriteLine($"Course: {purchasedCourse.BuyerName}, {purchasedCourse.CourseName}, Buyers: {purchasedCourse.Buyers}, Total Revenue: {purchasedCourse.TotalRevenue}");
        }
    }
    private List<PurchasedCoursesDTO> ReadPurchasedCoursesFromFile(string filePath)
{
    List<PurchasedCoursesDTO> purchasedCourses = new List<PurchasedCoursesDTO>();

    if (File.Exists(filePath))
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] values = line.Split(',');
                if (values.Length == 4)
                {
                    PurchasedCoursesDTO purchasedCourse = new PurchasedCoursesDTO
                    {
                        BuyerName = values[0],
                        CourseName = values[1],
                        Buyers = int.Parse(values[2]),
                        TotalRevenue = int.Parse(values[3])
                    };
                    purchasedCourses.Add(purchasedCourse);
                }
            }
        }
    }

    return purchasedCourses;
}


    public void DeleteCourse(string courseNameToDelete)
        {
            string filePath = "DATA/courses.txt";

            List<string> lines = new List<string>();

            // Read existing content
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Check if the line contains the course name to delete
                        if (!line.Contains(courseNameToDelete))
                        {
                            lines.Add(line);
                        }
                    }
                }

                // Write modified content back to the file
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (string line in lines)
                    {
                        writer.WriteLine(line);
                    }
                }

                Console.WriteLine($"{courseNameToDelete} deleted successfully.");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }
}