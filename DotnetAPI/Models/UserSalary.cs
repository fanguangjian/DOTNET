namespace DotnetAPI.Models
{
    public partial class UserSalary{
        public  int UserId{ get; set; }
        public string Salary{ get; set; }
       
        
        // Actually, the DB table schema can set up not NULL, default ""  
        public UserSalary(){
            if(Salary == null ){
                Salary = "";
            }           
            
        }
    }
}