class BikeNode:
    # Create BikeNode and set it into id and state
    def __init__(self, id, state, nextNode = None):
        self.id = id
        self.state = state
        self.nextNode = nextNode

class BikeQueue:
    def __init__(self):
        # Initialise rent bikes list
        self.size = 0
        self.head = self.last = None
        # Initialise rent bikes
        self.enqueue("B1", "Available")
        self.enqueue("B2", "Available")
        self.enqueue("B3", "Available")
        self.enqueue("B4", "Available")
        self.enqueue("B5", "Available")
        self.enqueue("B6", "Available")
        self.enqueue("B7", "Available")

    def isEmpty(self):
        # Check empty
        return self.size == 0
    
    def enqueue(self, id, state):
        # Enqueue node to the linked list
        bikes = BikeNode(id, state)
        if self.last is None:
            self.head = self.last = bikes
            self.size += 1
            return
        self.last.nextNode = bikes
        self.last = bikes
        self.size += 1
        
    def dequeue(self):
        # Dequeue node from the linked list
        if self.isEmpty():
            return
        bikes = self.head
        self.head = bikes.nextNode
 
        if(self.head == None):
            self.last = None
        self.size -= 1
        
    def invalidID(self, other):
        # Check if the bike id is in the list
        bikes = self.head
        while (bikes.id != other):
            bikes = bikes.nextNode
            if bikes is None:
                return None
        return -1
        
    def invalidState(self, other):
        #Check if the bike state is available
        bikes = self.head
        while (bikes.id != other):
            bikes = bikes.nextNode
        bikes.id = bikes.id
        bikes.state = bikes.state
        while (bikes.state == "Unavailable"):
            return -1
    
    def deleteBike(self, other):
        # Delete node from linked list by the input id
        if self.isEmpty():
            return
        bikes = self.head
        preBike = bikes
        curBike = bikes.nextNode
        while(curBike != None):
            if curBike.id == other:
                preBike.nextNode = curBike.nextNode
                curBike = preBike.nextNode
            else:
                preBike = preBike.nextNode
                curBike = curBike.nextNode
        self.size -= 1        
        return bikes
    
    def __len__(self):
        return self.size
    
    def initialiseBikes(self):
        # Display bike list
        bikes = self.head
        print(f'\nCurrent quantity of the bikes is {self.size}\n')
        print("-----------------------------------")
        while (bikes != None):
            print(f"     ID = {bikes.id}\n  State = {bikes.state}")
            bikes = bikes.nextNode
            print("-----------------------------------")

class ReturnBikeQueue():
    def __init__(self):
        # Initialise return bikes list
        self.head = None
        self.last = None
        self.size = 0
        
    def isEmpty(self):
        # Check empty
        return self.head == None
    
    def enqueue(self, id, state):
        # Enqueue node to the linked list
        bikes = BikeNode(id, state)
        if self.last is None:
            self.head = self.last = bikes
            self.size += 1
            return
        self.last.nextNode = bikes
        self.last = bikes
        self.size += 1
    
    def dequeue(self):
        # Dequeue node from the linked list
        if self.isEmpty():
            return
        bikes = self.head
        self.head = bikes.nextNode
 
        if(self.head == None):
            self.last = None
        self.size -= 1
    
    def deleteBike(self, other):
        # Delete node from linked list by the input id
        if self.isEmpty():
            return
        bikes = self.head
        preBike = bikes
        curBike = bikes.nextNode
        while(curBike != None):
            if curBike.id == other:
                preBike.nextNode = curBike.nextNode
                curBike = preBike.nextNode
            else:
                preBike = preBike.nextNode
                curBike = curBike.nextNode
        self.size -= 1        
        return bikes
    
    def __len__(self):
        return self.size
    
    def invalidID(self, other):
        # Check if the bike id is in the list
        bikes = self.head
        while (bikes.id != other):
            bikes = bikes.nextNode
            if bikes is None:
                return None
        return -1
    
    def initialiseBikes(self):
        # Display bike list
        bikes = self.head
        print(f'Current quantity of the bikes is {self.size}\n')
        print("-----------------------------------\n")
        while (bikes != None):
            print(f"     ID = {bikes.id}\n  State = {bikes.state}\n")
            bikes = bikes.nextNode
            print("-----------------------------------\n")

class BikeMaintenanceQueue():
    def __init__(self):
        # Initialise bikes maintenance list
        self.head = None
        self.last = None
        self.size = 0
        
    def isEmpty(self):
        # Check empty
        return self.head == None
    
    def enqueue(self, id, state):
        # Enqueue node to the linked list
        bikes = BikeNode(id, state)
        if self.last is None:
            self.head = self.last = bikes
            self.size += 1
            return
        self.last.nextNode = bikes
        self.last = bikes
        self.size += 1
        
    def dequeue(self):
        # Delete node from linked list by the input id
        if self.isEmpty():
            return
        bikes = self.head
        self.head = bikes.nextNode
 
        if(self.head == None):
            self.last = None
        self.size -= 1
    
    def __len__(self):
        return self.size
    
    def invalidID(self, other):
        # Check if the bike id is in the list
        bikes = self.head
        while (bikes.id != other):
            bikes = bikes.nextNode
            if bikes is None:
                return None
        return -1
    
    def deleteBike(self, other):
        # Delete node from linked list by the input id
        if self.isEmpty():
            return
        bikes = self.head
        preBike = bikes
        curBike = bikes.nextNode
        while(curBike != None):
            if curBike.id == other:
                preBike.nextNode = curBike.nextNode
                curBike = preBike.nextNode
            else:
                preBike = preBike.nextNode
                curBike = curBike.nextNode
        self.size -= 1        
        return bikes
    
    def initialiseBikes(self):
        # Display bike list
        bikes = self.head
        print(f'Current quantity of the bikes is {self.size}\n')
        print("-----------------------------------\n")
        while (bikes != None):
            print(f"     ID = {bikes.id}\n  State = {bikes.state}\n")
            bikes = bikes.nextNode
            print("-----------------------------------\n")
