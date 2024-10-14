namespace DotnetAPI
{
    public partial class UserJobInfo{
        public  int UserId{ get; set; }
        public string JobTitle{ get; set; }
        public string Department{ get; set; }
        
        // Actually, the DB table schema can set up not NULL, default ""  
        public UserJobInfo(){
            if(JobTitle == null ){
                JobTitle = "";
            }
            if(Department == null ){
                Department = "";
            }           
            
        }
    }
}