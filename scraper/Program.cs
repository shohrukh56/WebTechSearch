using System;
using System.Net;
using System.IO;

class Program{
    static void Main(string[] args){
        string dell_pc_url = "https://deals.dell.com/en-us/category/desktop-computer-deals";
        string dell_laptop_url = "https://deals.dell.com/en-us/category/laptop-deals";
        string alien_url = "https://www.dell.com/en-us/shop/dell-laptops/sr/laptops/alienware?appliedRefinements=37873";
        //Dell(dell_pc_url, dell_pc_url.Split("/")[5]);
        //Dell(dell_laptop_url, dell_laptop_url.Split("/")[5]);
        Alienware(alien_url, "alienware-laptop-deals");
    }

    static void Dell(string url, string url_name){
        string html = new WebClient().DownloadString(url);
        
        String filename = "dell-" + url_name;
        Console.WriteLine(filename);

        using (StreamWriter writer = new StreamWriter(filename))  {  
            writer.WriteLine(html); 
        }
         
        String[] body = html.Split("/head>");
        String[] x = body[1].Split("d-category-grid");
        String[] products =x[1].Split("sd-ps-title-content");
        Console.WriteLine(products.Length); //all
        using (StreamWriter writer = new StreamWriter(filename+"-items"))  {  
            for (int i = 1; i < products.Length; i += 1){
                String name;
                try{
                    name = products[i].Split(">")[2].Split("<")[0];
                } catch{name = "";}
                Console.WriteLine("name: " + name);
                writer.WriteLine("name: " + name); 

                String old_price;
                try{
                    old_price = products[i].Split("$")[1].Split("<")[0];
                }catch{old_price = "";}
                Console.WriteLine("old price: $" + old_price);
                writer.WriteLine("old price: $" + old_price);

                String current_prize;
                try{
                    current_prize = products[i].Split("Dell Price</span>")[1].Split("$")[1].Split("<")[0];
                }catch{current_prize = "";}
                Console.WriteLine("current prize: $" + current_prize);
                writer.WriteLine("current prize: $" + current_prize);

                String savings;
                try{
                    savings = products[i].Split("Save</span>")[1].Split("$")[1].Split("<")[0];
                }catch{savings = "";}
                Console.WriteLine("savings: $" + savings);
                writer.WriteLine("savings: $" + savings);

                String saving_percentage;
                try{
                    saving_percentage = products[i].Split("Save</span>")[1].Split("(")[1].Split(")")[0];
                }catch{saving_percentage = "";}
                Console.WriteLine("savings % :" + saving_percentage);
                writer.WriteLine("savings % :" + saving_percentage);

                String processor;
                try{
                    processor = products[i].Split("dds_processor\"></span>")[1].Split(">")[1].Split("<")[0]; 
                }catch{processor = "";}
                Console.WriteLine("processor: " + processor);
                writer.WriteLine("processor: " + processor);

                String os;
                os = products[i].Split("dds_disc-system\"></span>")[1].Split(">")[1].Split("<")[0];
                Console.WriteLine("OS: " + os);
                writer.WriteLine("OS: " + os);

                String video_card;
                try {
                    video_card = products[i].Split("dds_video-card\"></span>")[1].Split(">")[1].Split("<")[0];
                }catch{video_card = "";}
                Console.WriteLine("video card: " + video_card);
                writer.WriteLine("video card: " + video_card);

                String hard_drive;
                try{
                    hard_drive = products[i].Split("dds_hard-drive\"></span>")[1].Split(">")[1].Split("<")[0];
                }catch{hard_drive = "";}
                Console.WriteLine("hard drive: " + hard_drive);
                writer.WriteLine("hard drive: " + hard_drive);

                String memory;
                try{
                    memory = products[i].Split("dds_memory\"></span>")[1].Split(">")[1].Split("<")[0];
                }catch{memory = "";}
                Console.WriteLine("memory: " + memory);
                writer.WriteLine("memory: " + memory);

                String screen;
                try{
                    screen = products[i].Split("dds_device-screen-size\"></span>")[1].Split(">")[1].Split("<")[0];
                    
                }catch{screen = "";}
                Console.WriteLine("screen: " + screen);
                Console.WriteLine("\n");

                writer.WriteLine("screen: " + screen + "\n");
            }
        }
    }
    static void Alienware(string url, string url_name) {
        ParseAlienware(url, url_name, false);
        for(int i =2; i < 5;i++){
            String url_ = url + " " + url.Replace("?","?page=" + i +" &");
            //Console.WriteLine(url + " " + url.Replace("?","?page=" + i +" &"));
            Console.WriteLine("\n"+i+"\n");
            ParseAlienware(url_, url_name, true);
        }
    }   
    static void ParseAlienware(string url, string url_name, bool append_){
        String html = new WebClient().DownloadString(url);
        String filename = "" + url_name;
        //Console.WriteLine(filename);

        /*using (StreamWriter writer = new StreamWriter(filename))  {  
            writer.WriteLine(html); 
        }*/
        html = html.Split("data-fast-delivery=''>")[1];
        String[] products = html.Split("article id=\"");
        using (StreamWriter writer = new StreamWriter(filename+"-items", append:append_))  {  
            for (int i = 1; i < products.Length; i += 1){
                String name = products[i].Split("\"ps-title\"")[1].Split("}\">")[1].Split("<")[0];
                Console.WriteLine("name: "+name);
                writer.WriteLine("name: " + name); 

                String current_price = products[i].Split("\"ps-title\"")[1].Split("$")[1].Split("\n")[0].Split("<")[0];
                Console.WriteLine("price : $ "+current_price);
                writer.WriteLine("price: " + current_price); 

                String processor;
                try{
                    processor = products[i].Split("\"ps-title\"")[1].Split("$")[1].Split("specs-label\">")[1].Split("\n")[1].TrimStart();
                }catch{processor = "";}
                writer.WriteLine("processor: " + processor); 

                Console.WriteLine("processor: "+processor);
                String os;

                try{
                    os = products[i].Split("\"ps-title\"")[1].Split("$")[1].Split("specs-label\">")[2].Split("\n")[1].TrimStart();
                }catch{os = "";}
                Console.WriteLine("OS: "+os);
                writer.WriteLine("OS: " + os); 

                String video_card;
                try{
                    video_card = products[i].Split("\"ps-title\"")[1].Split("$")[1].Split("specs-label\">")[3].Split("\n")[1].TrimStart();
                } catch{video_card = "";}
                Console.WriteLine("video card: "+video_card);
                writer.WriteLine("video card: " + video_card); 
                String memory;
                try{memory = products[i].Split("\"ps-title\"")[1].Split("$")[1].Split("specs-label\">")[4].Split("\n")[1].TrimStart();
                }catch{memory = "";}
                Console.WriteLine("memory: "+memory);
                writer.WriteLine("memory: " + memory); 
                String storage;
                try{
                    storage = products[i].Split("\"ps-title\"")[1].Split("$")[1].Split("specs-label\">")[5].Split("\n")[1].TrimStart();
                }catch{storage = "";}
                Console.WriteLine("storage: "+storage);
                writer.WriteLine("storage: " + storage); 

                String screen;
                try{
                    screen = products[i].Split("\"ps-title\"")[1].Split("$")[1].Split("specs-label\">")[6].Split("\n")[1].TrimStart();
                }catch{screen = "";}
                Console.WriteLine("screen: "+screen+"\n\n");
                writer.WriteLine("screen: " + screen+"\n"); 
            }
        }
    }
}