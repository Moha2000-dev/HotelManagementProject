namespace HotelManagementProject
{
    internal class Program
    {
        static int[] roomNumber = new int[100];
        static double[] roomRate = new double[100];
        static bool[] isReserved = new bool[100];
        static string[] guestName = new string[100];
        static int[] nigths = new int[100];
        static DateTime[] checkInDate = new DateTime[100];
        static int roomCount = 0;  
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Hotel Management System");
            while (true)
            {
                Console.WriteLine("1. Add Room");
                Console.WriteLine("2. View Rooms");
                Console.WriteLine("3. Reserve Room");
                Console.WriteLine("4. View Reserved Rooms");
                Console.WriteLine("5. Search by Guest Name");
                Console.WriteLine("6. Find Maximum Cost Room");
                Console.WriteLine("7. Cancel Reservation by Room Number");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice: ");
                Console.WriteLine();
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        addRoom();
                        break;
                    case 2:
                        viewRooms();
                        break;
                    case 3:
                        reserveRoom();
                        break;
                    case 4:
                        viweReserevedRooms();
                        break;
                    case 5:
                        searchByGuestName();
                        break;
                    case 6:
                        maxCost();
                        break;
                    case 7:
                        cancelByRoomNumber();
                        break;
                    case 8:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }
        // --------------------------------------------------Method to add a room------------------------------------------------
        static void addRoom()
        {
            try
            {
                Console.WriteLine("Enter Room Number: ");
                int roomNum = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Room Rate: ");
                double roomR = double.Parse(Console.ReadLine());
                
                if (roomR > 100)
                {
                    Console.WriteLine("Room Rate must be less than 100 ");
                    return;


                }
                else
                {
                    for (int i = 0; i < roomCount; i++)
                    {
                        if (roomNumber[i] == roomNum)
                        {
                            Console.WriteLine("Room already exists");
                            break;
                        }
                    }
                    roomNumber[roomCount] = roomNum;
                    roomRate[roomCount] = roomR;
                    isReserved[roomCount] = false;
                    roomCount++;
                    Console.WriteLine("Room added successfully");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
      
        
        }
        
        //--------------------------view method-------------------------------------------------------
        static void viewRooms()
        {
            for (int i = 0; i < roomCount; i++)
            {
                if (isReserved[i] == false)
                {

                    Console.WriteLine("the  avilbel room number is   " + roomNumber[i]);
                    Console.WriteLine();
                }
                else { 
                 
                    Console.WriteLine("Guest Name: " + guestName[i]);
                    Console.WriteLine("The totoal cost is " + (nigths[i] * roomRate[i]) );
                    Console.WriteLine();

                }
            }
        }

        // -------------------------------Method to reserve a room-----------------------------------
        static void reserveRoom()
        {
            try
            {
                Console.WriteLine("Enter Room Number: ");
                int roomNum = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Guest Name: ");
                string guestN = Console.ReadLine();
                Console.WriteLine("Enter Number of Nights: ");
                int nights = int.Parse(Console.ReadLine());
                for (int i = 0; i < roomCount; i++)
                {
                    if (nights >= 1)
                    {
                        if (roomNumber[i] == roomNum)
                        {
                            if (isReserved[i] == false)
                            {
                                isReserved[i] = true;
                                guestName[i] = guestN;
                                checkInDate[i] = DateTime.Now;
                                nigths[i] = nights;
                                Console.WriteLine("Room reserved successfully");
                            }
                            else
                            {
                                Console.WriteLine("Room is already reserved");
                            }
                            return;
                        }
                    }
                    else {
                        Console.WriteLine("cannot reserv less han one nigth ");
                    }

                }
                Console.WriteLine("Room not found");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }


        // -------------------------------Method to view reserved rooms-----------------------------------
        static void viweReserevedRooms()
        {
            for (int i = 0; i < roomCount; i++)
            {
                if (isReserved[i] == true)
                {
                    Console.WriteLine("Gust name  :" + guestName[i]);
                    Console.WriteLine("Room munbe is : " + roomNumber[i]);
                    Console.WriteLine("Room number of nigths " + nigths[i]);
                    Console.WriteLine("Rate is  : " + roomRate[i]);
                    Console.WriteLine("The cost is  : " + (nigths[i] * roomRate[i]));


                }
                else if (isReserved[i] == false)
                {
                    Console.WriteLine("Room is not reserved");
                }




            }

            // -------------------------------Method to search by guest name-----------------------------------
        }
        static void searchByGuestName() {
            Console.WriteLine("pless enter the guset name");
            string guestneedName = Console.ReadLine();
            bool found = false;
            for (int i = 0; i < roomCount; i++) {
                if (guestName[i] == guestneedName)
                {
                    Console.WriteLine("Gust name  :" + guestName[i]);
                    Console.WriteLine("Room munbe is : " + roomNumber[i]);
                    Console.WriteLine("Room number of nigths " + nigths[i]);
                    Console.WriteLine("Rate is  : " + roomRate[i]);
                    Console.WriteLine("The cost is  : " + (nigths[i] * roomRate[i]));
                    found = true;
                    break;

                }
                

                
                
          
            }
            if (!found)
            {
                Console.WriteLine("Guest not found");
            }


        }
        // -------------------------------Method to find maximum cost room-----------------------------------
        static void maxCost()
        {
            double[] cost = new double[100];
            double max = 0; 
            for (int i = 0; i < roomCount; i++)
            {
                double totalCost = nigths[i] * roomRate[i]; 
                cost[i] = totalCost;
                if (cost[i] > max)
                {
                    max = cost[i];
                }
            }
            for (int i = 0; i < roomCount; i++)
            {
                if (cost[i] == max)
                {
                    Console.WriteLine("Gust name  :" + guestName[i]);
                    Console.WriteLine("Room munbe is : " + roomNumber[i]);
                    Console.WriteLine("Room number of nigths " + nigths[i]);
                    Console.WriteLine("Rate is  : " + roomRate[i]);
                    Console.WriteLine("The cost is  : " + (nigths[i] * roomRate[i]));
                }
            }

//-------------------add the cancel method ----------------------------------------------------------
        }static void cancelByRoomNumber() {
            Console.WriteLine("Enter Room Number: ");
            int roomNum = int.Parse(Console.ReadLine());
            for (int i = 0; i < roomCount; i++)
            {
                if (roomNumber[i] == roomNum)
                {
                    isReserved[i] = false;
                    guestName[i] = null;
                    checkInDate[i] = DateTime.MinValue;
                    nigths[i] = 0;
                    Console.WriteLine("Room reservation cancelled successfully");
                    return;
                }
            }
            Console.WriteLine("Room not found");





        }


    }




}
