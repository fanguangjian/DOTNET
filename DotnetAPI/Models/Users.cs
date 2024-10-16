namespace DotnetAPI
{
    public partial class User{
        public  int UserId{ get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public string Email{ get; set; }
        public string Gender{ get; set; }
        public bool Active{ get; set; }
        
        // Actually, the DB table schema can set up not NULL, default ""  
        public User(){
            if(FirstName == null ){
                FirstName = "";
            }
            if(LastName == null ){
                LastName = "";
            }
            if(Email == null ){
                Email = "";
            }
            if(Gender == null ){
                Gender = "";
            }
            
        }
    }
}