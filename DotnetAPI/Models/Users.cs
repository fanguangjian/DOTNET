namespace DotnetAPI
{
    public partial class Users{
        public  int UserId{ get; set; }
        public string FirstName{ get; set; }
        public string Lastname{ get; set; }
        public string Email{ get; set; }
        public string Gender{ get; set; }
        public bool Active{ get; set; }
        
        // Actually, the DB table schema can set up not NULL, default ""  
        public Users(){
            if(FirstName == null ){
                FirstName = "";
            }
            if(Lastname == null ){
                Lastname = "";
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