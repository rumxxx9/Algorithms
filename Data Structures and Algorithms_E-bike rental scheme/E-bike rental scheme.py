from BikeManagement import BikeQueue
from BikeManagement import ReturnBikeQueue
from BikeManagement import BikeMaintenanceQueue
from ClientManagement import ClientQueue

b = BikeQueue()
r = ReturnBikeQueue()
c = ClientQueue()
m = BikeMaintenanceQueue()
bikes = b.head
clients = c.head

def AddNewBike():
    print("\n-----------------------------------")
    print("|         Add New Bike            |")
    print("-----------------------------------\n")
    option = str(input("Do you want to add a new bike?(Y/N): "))
    # Check if add new bike to the BikeQueue
    while option != "N":
        if option == "Y":
            option = str(input("What is the ID of the bike? "))
            # Check if new bike id is unique
            if b.invalidID(option) == -1:
                print("This ID is existed, please try another ID.")
            else:
                # Enqueue the new bike + display
                b.enqueue(option, "Available")
                b.initialiseBikes()
            option = str(input("Do you want to add a new bike?(Y/N): "))
        else:
            # Invalid Input
            print("Invalid Option. Please Try Again.")
            option = str(input("Do you want to add a new bike?(Y/N): "))
    #Go back to Menu
    main()  

def RentBike():
    print("\n-----------------------------------")
    print("|         Rent The Bike           |")
    print("-----------------------------------")
    b.initialiseBikes()
    option = str(input("Please enter the bike ID or main menu(M): "))
    if b.isEmpty() == False:
        # Check If Display Menu
        while option != "M":
            # If the bike ID is in the list
            while b.invalidID(option) == -1:
                bikes = b.head
                # If the selected bike state is available
                while b.invalidState(option) == -1:
                    option = str(input("This bike is currently unavailable.\nPlease enter the bike ID or main menu(M): "))
                    while option == "M":
                        main()
                # Input new client information
                NewClient = str(input("Are you a new client(Y/N): "))
                while NewClient != "N":
                    if NewClient == "Y":
                        ClientID = str(input("Please enter your Client ID: "))
                        while c.checkID(ClientID) == -1:
                            ClientID = str(input("Request is denied because this Client ID is not exist, Please try a new ID: "))
                        ClientName = str(input("Please enter your name: "))
                        ClientMobile = str(input("Please enter your mobile: "))
                        ClientPaymentMethod = str(input("Please enter your payment method: "))
                        # Add new client information to clientManagement
                        c.enqueue(ClientID, ClientName, ClientMobile, ClientPaymentMethod)
                        # Add to ReturnBike
                        r.enqueue(option, "Unavailable")
                        print(f"Thank you for choosing {option}.")
                        # Change rented bike state to unavailable
                        bikes = b.head
                        while (option != bikes.id):
                            bikes = bikes.nextNode
                            if bikes is None:
                                return None
                        bikes.state = "Unavailable"   
                        b.size -= 1                     
                        return RentBike()
                    else:
                        # Invalid input
                        print("Invalid Option. Please Try Again.")
                        NewClient = str(input("Are you a new client(Y/N): "))
                            
                #Search old clients ID
                OldClient = str(input("Welcome Back! Please enter your Client ID: "))
                if c.checkID(OldClient) == -1:
                        r.enqueue(option, "Unavailable")
                        print(f"Thank you for choosing {option}.")
                        # Change rented bike state to unavailable
                        bikes = b.head
                        while (option != bikes.id):
                            bikes = bikes.nextNode
                            if bikes is None:
                                return None
                        bikes.state = "Unavailable"   
                        b.size -= 1                     
                        return RentBike()
            else:
                # Check if the bikeID is exist         
                print("Request is denied because this bike ID is not exist.")
                option = str(input("Please enter the bike ID or main menu(M): "))
    main() 
    
def ReturnBike():
    print("\n-----------------------------------")
    print("|          Return Bikes           |")
    print("-----------------------------------\n")
    # Dislay the return bikes list
    r.initialiseBikes()
    # Check if the returnBike list is empty
    if r.isEmpty() == False:
        returnBike = str(input("Enter Bike ID to return the bike or main menu(M): "))
        while returnBike != "M":
            # Check if the input bikeID is exist
            while r.invalidID(returnBike) == -1:
                # Delete selected returnBike from retunBike list by dequeue
                if r.size <= 2:
                        r.dequeue()
                        print("-----------------------------------")
                        # Check if it goes to the maintenance list
                        maintenance = str(input("Does this bike need maintenance?(Y/N): "))
                        while maintenance != "N":
                            if maintenance == "Y":
                                m.enqueue(returnBike, "Unavailable")
                                ReturnBike()
                            print("Invalid Option. Please Try Again.")
                            maintenance = str(input("Does this bike need maintenance?(Y/N): "))
                        # If the selected returnBike does not go to maintenance list 
                        bikes = b.head
                        while (returnBike != bikes.id):
                            bikes = bikes.nextNode
                            if bikes is None:
                                return None
                        # Return it to the rent list and set state to available
                        bikes.state = "Available"   
                        b.size += 1
                        ReturnBike()
                else:
                    # Delete selected returnBike from retunBike list
                    r.deleteBike(returnBike)
                    print("-----------------------------------")
                    # Check if it goes to the maintenance list
                    maintenance = str(input("Does this bike need maintenance?(Y/N): "))
                    while maintenance != "N":
                        if maintenance == "Y":
                            m.enqueue(returnBike, "Unavailable")
                            ReturnBike()
                        print("Invalid Option. Please Try Again.")
                        maintenance = str(input("Does this bike need maintenance?(Y/N): "))
                    # If the selected returnBike does not go to maintenance list
                    bikes = b.head
                    while (returnBike != bikes.id):
                        bikes = bikes.nextNode
                        if bikes is None:
                            return None
                    # Return it to the rent list and set state to available
                    bikes.state = "Available"   
                    b.size += 1
                    ReturnBike()   
            else:
                # Check valid input
                print("Invalid Option. Please Try Again.")
                returnBike = str(input("Enter Bike ID to return the bike or main menu(M): "))
        main()
        
    option = str(input("Enter M go back to main menu: "))
    if option != "M":
        print("Invalid Option. Please Try Again.")
        option = str(input("Enter M go back to main menu: "))
    main()

def ClientManagement():
    print("\n-----------------------------------")
    print("|        Client Management        |")
    print("-----------------------------------\n")
    # Dislay the client list
    c.displayClients()
    # Check if the client list is empty
    if c.isEmpty() == False:
        deleteClient = str(input("Enter Client ID to delete the client information or main menu(M): "))
        while deleteClient != "M":
            # Check if input client id is exist
            while c.checkID(deleteClient) == -1:
                if c.size <= 2:
                    # Delete client information by dequeue
                    c.dequeue()
                    ClientManagement()
                else:
                    # Delete client information
                    c.deleteClient(deleteClient)
                    ClientManagement()
            deleteClient = str(input("This ID is not existed, please try another ID: "))
        main()
    option = str(input("Enter M go back to main menu: "))
    if option != "M":
        print("Invalid Option. Please Try Again.")
        option = str(input("Enter M go back to main menu: "))
    main()

def BikeMaintenance():
    print("\n-----------------------------------")
    print("|         Bike Maintenance        |")
    print("-----------------------------------\n")
    # Dislay the Bike Maintenance list
    m.initialiseBikes()
    if m.isEmpty() == False:
        bikeM = str(input("Enter bike ID to return bike to the rent list or back to main menu(M): "))
        while bikeM != "M":
            # Check if the input bikeID is exist
            while m.invalidID(bikeM) == -1:
                # Delete selected bike from bikeMaintenance list by dequeue
                if m.size <= 2:
                    m.dequeue()
                    print("-----------------------------------")
                    # Delete selected bike from the rent bike list
                    b.deleteBike(bikeM)
                    # Enqueue the selected bite to the rent list/End
                    b.enqueue(bikeM, "Available")
                    b.size += 1
                    BikeMaintenance()
                else:
                    # Delete selected bike from bikeMaintenance list
                    m.deleteBike(bikeM)
                    print("-----------------------------------")
                    # Delete selected bike from the rent bike list
                    b.deleteBike(bikeM)
                     # Enqueue the selected bite to the rent list/End
                    b.enqueue(bikeM, "Available")
                    b.size += 1
                    BikeMaintenance()  
            else:
                # Check valid input
                print("Invalid Option. Please Try Again.")
                bikeM = str(input("Enter Bike ID to return the bike or main menu(M): "))
        main()
    option = str(input("Enter M go back to main menu: "))
    if option != "M":
        print("Invalid Option. Please Try Again.")
        option = str(input("Enter M go back to main menu: "))
    main()

def init():
    # Print the MainMenu option
    print("\n-----------------------------------")
    print("| Welcome to E-bike Rental Scheme |")
    print("-----------------------------------\n")
    print(" [1] Rent the Bike")
    print(" [2] Return the Bike")
    print(" [3] Add New Bike")
    print(" [4] Bike Maintenance")
    print(" [5] Client Management")
    print(" [0] Exit")
    print("\n-----------------------------------\n")

def main():
    # Main menu options
    init()
    while True:
        option = str(input("Enter Your Option: "))
        while option != "0":
            if option == "1":
                RentBike()
                break
            elif option == "2":
                ReturnBike()
                break
            elif option == "3":
                AddNewBike()
                break
            elif option == "4":
                BikeMaintenance()
                break
            elif option == "5":
                ClientManagement()
                break
            else:
                print("Invalid Option. Please Try Again.")
            option = str(input("Enter Your Option: "))
        exit()

if __name__=="__main__":
    main()