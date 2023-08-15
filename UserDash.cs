
namespace JituCourses{
    class UserDash {
        public void userDisplay(){

            System.Console.WriteLine("1. View courses");
            System.Console.WriteLine("2. Purchased courses");


            Console.WriteLine("select way to proceed");
            string selectedOption = Console.ReadLine();

            switch(selectedOption){
                case "1":
                    Console.WriteLine("Proceeding to view all Course");
                     AdminDash viewcources = new AdminDash();
                     viewcources.GetAllCourses();
                     Purchase newPurchase = new Purchase();
                     newPurchase.BuyCourse();
                    break;
                case "2":
                    Console.WriteLine("Proceeding to View Purchased Courses");
                    break;
        }
    }

    public void purchase(){
        
    }
}
}