namespace JituCourses{
    public class CourseDTO{
        // public int Id { get; set;};
        public string ID{ get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Price { get; set; }

        public CourseDTO ( string id, string name, string description, string price){
        this.Name = name;
        this.Description = description;
        this.Price = price;
        this.ID = id;
        }

        

        
    }

    
}