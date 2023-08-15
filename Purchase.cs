namespace JituCourses
{
    public class Purchase
    {
        public List<CourseDTO> courses = ReadCoursesFromFile("DATA/courses.txt");
        private int balance = 0; // Initialize balance to 0
        
        public void BuyCourse()
        {
            Console.WriteLine("Select course to purchase:");
            string courseToBuy = Console.ReadLine();

            CourseDTO selectedCourse = courses.Find(course => course.ID == courseToBuy);

            if (selectedCourse != null)
            {
                int coursePrice = int.Parse(selectedCourse.Price);

                while (balance < coursePrice)
                {
                    Console.Write($"Top-up amount: ");
                    string topUpInput = Console.ReadLine();

                    if (int.TryParse(topUpInput, out int topUpAmount))
                    {
                        balance += topUpAmount;
                        Console.WriteLine($"Current balance: {balance}");
                        Console.WriteLine($"Please top up {coursePrice - balance} to process your payment");

                    }
                    else
                    {
                        Console.WriteLine("Invalid amount. Please enter a valid numeric value.");
                    }
                }

                Console.WriteLine($"Proceed to pay for: {selectedCourse.Name} course");
                Payment(selectedCourse);
            }
            else
            {
                Console.WriteLine("Course not found.");
            }
        }

        // Simulated payment method
        private void Payment(CourseDTO selectedCourse)
        {
            int coursePrice = GetCoursePrice(selectedCourse.ID);
            Console.WriteLine("1. Confirm payment");
            Console.WriteLine("2. Cancel");

            // var courseName = GetCourseName(courseId);

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                if (balance >= coursePrice)
                {
                    Console.WriteLine($"Payment successfull, Thanks for enrolling");
                    balance -= coursePrice;
                    UpdatePurchasedCourses(selectedCourse, coursePrice);
                }
                else
                {
                    Console.WriteLine($"Insufficient balance. Please top up.{coursePrice}");
                }
            }
            else if (choice == "2")
            {
                Console.WriteLine("Payment cancelled.");
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        private int GetCoursePrice(string courseId)
        {
            CourseDTO course = courses.Find(c => c.ID == courseId);
            if (course != null)
            {
                return int.Parse(course.Price);
            }
            return 0;
        }

        static List<CourseDTO> ReadCoursesFromFile(string filePath)
        {
            List<CourseDTO> courses = new List<CourseDTO>();

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
                            CourseDTO course = new CourseDTO(values[0], values[1], values[2], values[3]);
                            courses.Add(course);
                        }
                    }
                }
            }

            return courses;
        }

        private void UpdatePurchasedCourses(CourseDTO selectedCourse, int coursePrice)
    {
        List<PurchasedCoursesDTO> purchasedCourses = ReadPurchasedCoursesFromFile("DATA/analytics.txt");
        
        PurchasedCoursesDTO purchasedCourse = purchasedCourses.Find(course => course.CourseName == selectedCourse.Name);
        System.Console.Write("your name:");
        var BuyerName = Console.ReadLine();
        
        if (purchasedCourse != null)
        {
            purchasedCourse.Buyers++;
            purchasedCourse.TotalRevenue += coursePrice;
        }
        else
        {
            purchasedCourse = new PurchasedCoursesDTO
            {
                BuyerName = BuyerName,
                CourseName = selectedCourse.Name,
                Buyers = 1,
                TotalRevenue = coursePrice
            };
               purchasedCourses.Add(purchasedCourse);
        }

        SavePurchasedCoursesToFile(purchasedCourses);

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

private void SavePurchasedCoursesToFile(List<PurchasedCoursesDTO> purchasedCourses)
{
    using (StreamWriter writer = new StreamWriter("DATA/analytics.txt"))
    {
        foreach (PurchasedCoursesDTO purchasedCourse in purchasedCourses)
        {
            string line = $"{purchasedCourse.BuyerName}, {purchasedCourse.CourseName},{purchasedCourse.Buyers},{purchasedCourse.TotalRevenue}";
            writer.WriteLine(line);
        }
    }
}

    }
}
