namespace Create5000Records
{
    class WriteToFile
    {
        private string path = string.Empty;
        public WriteToFile(string path){
            this.path = path;
        }

        public void addToFile(string command){
            
            using (System.IO.StreamWriter file = 
            new System.IO.StreamWriter(path, true))
            {
                file.WriteLine(command);
            }
        }
        
    }
}
