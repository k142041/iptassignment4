using System;
using System.IO;

namespace Create5000Records
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string path = @"C:\Users\ibtehaj\Documents\Visual Studio 2015\C#\Create5000Records\RECORDS.txt";
            WriteToFile obj = new WriteToFile(path);
            // obj.addToFile("TEST");

            string iQuery = "INSERT INTO [temp].[dbo].[Product]"
                            +"([ProductName],[ProductDescription]"
                            +",[ProductPrice],[Active],"
                            +"[otherAttributes],[PrimaryCategoryId]) VALUES";

    //         INSERT INTO [temp].[dbo].[Product]
    //        ([ProductName],[ProductDescription]
    //        ,[ProductPrice],[Active],[otherAttributes],[PrimaryCategoryId])
    //  VALUES
    //        (<ProductName, varchar(50),>
    //        ,<ProductDescription, varchar,>
    //        ,<ProductPrice, nchar(10),>
    //        ,<Active, bit,>
    //        ,<otherAttributes, xml,>
    //        ,<PrimaryCategoryId, int,>)
            int k = 1;
            for(int i = 0 ; i < 50000 ; i++){            
                        //Product Name
                        var lines = File.ReadAllLines(@"C:\Users\ibtehaj\Downloads\prodName.json");
                        var r = new Random();
                        var randomLineNumber = r.Next(0, lines.Length - 1);
                        string ProductName = lines[randomLineNumber];
                        // var line = lines[randomLineNumber];
                        
                        //Product Description
                        lines = File.ReadAllLines(@"C:\Users\ibtehaj\Downloads\prodDesc.json");
                        r = new Random();
                        randomLineNumber = r.Next(0, lines.Length - 1);
                        string ProductDescription = lines[randomLineNumber];

                        //Product Price
                        lines = File.ReadAllLines(@"C:\Users\ibtehaj\Downloads\prodPrice.json");
                        r = new Random();
                        randomLineNumber = r.Next(0, lines.Length - 1);
                        string ProductPrice = lines[randomLineNumber];

            //      ACTIVE
                        int Active = r.Next(0,2);

            //      OTHER ATTRIBUTES
                        lines = File.ReadAllLines(@"C:\Users\ibtehaj\Downloads\prodColor.json");
                        r = new Random();
                        randomLineNumber = r.Next(0, lines.Length - 1);
                        var color = lines[randomLineNumber];

                        //  RANDOM SIZE
                        string[] size = {"S","M","L","XL","XXL"};
                        string randomSize = size[r.Next(0,size.Length-1)];
                        // Random Dimentions
                        
                        lines = File.ReadAllLines(@"C:\Users\ibtehaj\Downloads\prodDimention.json");
                        r = new Random();
                        randomLineNumber = r.Next(0, lines.Length - 1);
                        string ProductDimention = lines[randomLineNumber];

                        string xmlFormat = "<root>"
                                            +"<attributes>"
                                            +"<color>"+color+"</color>"
                                            +"<size>"+randomSize+"</size>"
                                            +"<dimensions>"+ProductDimention+"</dimensions>"
                                            +"</attributes>"
                                            +"</root>";


            // RANDOM PrimaryCatagoryId

                        int PrimaryCategoryId = r.Next(1,13);
                        string st = " ('"+ProductName+"', '"+ProductDescription+"', '"+ProductPrice+"', "+Active+", '"+xmlFormat+"', "+PrimaryCategoryId+")";
                        string finalString = iQuery+st;
                        // Console.WriteLine("Name: "+ProductName+"\nDescription: "+ProductDescription+"\nPRICE: "+ProductPrice
                        //                 +"Active: "+Active+"\nPrimary catagory id: "+PrimaryCategoryId
                        //                 +"\nXML:\n"+xmlFormat);
                        // Console.WriteLine(finalString);
                        obj.addToFile(finalString);
                        if(k == 1000 ){
                            obj.addToFile("\nGO");
                            k=1;
                        }
                      k++;                  
            }


        }
    }
}
